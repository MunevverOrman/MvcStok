using MvcStok.Models.Entity;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MvcStok.Controllers
{
    public class CategoryController : Controller
    {
        
        MvcDbStokEntities db = new MvcDbStokEntities();
       
        public ActionResult Index(int sayfa=1)
        {
            //var degerler= db.TBLKATEGORILER.ToList();
            var degerler = db.TBLKATEGORILER.ToList().ToPagedList(sayfa, 4); //sayfalama işlemi için
            return View(degerler);
        }


        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(TBLKATEGORILER p1)
        {
            if(!ModelState.IsValid)
            {
                return View("CreateCategory");
            }
            db.TBLKATEGORILER.Add(p1); //Ado.net deki insert into gibi düşünebiliriz
            db.SaveChanges();
            return View();

        }
        public ActionResult DeleteCategory(int id)
        { 
            var kategori = db.TBLKATEGORILER.Find(id); //tblkategorıler tablosundan id ye göre bul  
            db.TBLKATEGORILER.Remove(kategori); //bulduğun kategoriyi sil
            db.SaveChanges(); //değişiklikleri kaydet
            return RedirectToAction("Index"); //index sayfasına yönlendir

        }
        public ActionResult GetCategory(int id)
                    {
            var ktgr = db.TBLKATEGORILER.Find(id);
            return View("GetCategory", ktgr);
        }
        public ActionResult UpdateCategory(TBLKATEGORILER P1)
        { 
            var ktgr = db.TBLKATEGORILER.Find(P1.KATEGORIID); //TBLKATEGORILER içinden P1 in KATEGORIID sine göre bul
            ktgr.KATEGORIAD= P1.KATEGORIAD; //bulduğun kategorinin adını P1 in KATEGORIAD ı ile değiştir
            db.SaveChanges(); //değişiklikleri kaydet
            return RedirectToAction("Index"); //index sayfasına yönlendir

        }
    }
}




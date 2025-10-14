using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcStok.Models.Entity;
namespace MvcStok.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        MvcDbStokEntities db = new MvcDbStokEntities();
       
        public ActionResult Index()
        {
            var degerler = db.TBLURUNLER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult CreateProduct()
        { 
            List<SelectListItem> degerler=(from i in db.TBLKATEGORILER.ToList()
                                           select new SelectListItem
                                             {
                                                  Text = i.KATEGORIAD,
                                                  Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(TBLURUNLER p1)
        { 
            var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == p1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            p1.TBLKATEGORILER = ktg;
            db.TBLURUNLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteProduct(int id)
        { 
            var urun =db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult GetProduct(int id)
        { 
            var urun= db.TBLURUNLER.Find(id);
            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("GetProduct", urun);

        }
        public ActionResult UpdateProduct(TBLURUNLER p1)
        {
            var urun = db.TBLURUNLER.Find(p1.URUNID);
            urun.URUNAD = p1.URUNAD; 
            urun.MARKA=p1.MARKA;
            urun.FIYAT = p1.FIYAT;
            urun.STOK = p1.STOK;
            //urun.URUNKATEGORI=p1.URUNKATEGORI; //kategoriyi güncellerken bunu kullanmayacağız. Aşağıda doğru olanı yapacağız.çünkü liste içinden seçilen kategori id sini alacağız
            var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == p1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            urun.URUNKATEGORI = ktg.KATEGORIID;
            db.SaveChanges();
            return RedirectToAction("Index");




        }
    }
}
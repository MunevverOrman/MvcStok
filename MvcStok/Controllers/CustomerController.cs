using System.Linq;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        MvcDbStokEntities db=new MvcDbStokEntities();
        
        public ActionResult Index()
        {
            var degerler =db.TBLMUSTERILER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult CreateCustomer()
        {
            return View();
        }
        [HttpPost] 
        public ActionResult CreateCustomer(TBLMUSTERILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateCustomer");
            }
            db.TBLMUSTERILER.Add(p1);
            db.SaveChanges();
            return View();

        }
        public ActionResult DeleteCustomer(int id)
        {
            var musterı = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(musterı);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCustomer(int id)
        { 
            var musterı=db.TBLMUSTERILER.Find(id);
            return View("GetCustomer", musterı);

        }
        public ActionResult UpdateCustomer(TBLMUSTERILER P1)
        {
            var musterı = db.TBLMUSTERILER.Find(P1.MUSTERIID);
            musterı.MUSTERIAD = P1.MUSTERIAD;
            musterı.MUSTERISOYAD = P1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}  
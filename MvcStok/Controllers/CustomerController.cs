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
    }
}
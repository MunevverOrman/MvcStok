using MvcStok.Models.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MvcStok.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        MvcDbStokEntities db = new MvcDbStokEntities();
       
        public ActionResult Index()
        {
            var degerler= db.TBLKATEGORILER.ToList();
            return View(degerler);
        }
    }
}
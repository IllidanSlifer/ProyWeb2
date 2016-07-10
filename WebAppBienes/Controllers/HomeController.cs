using System.Web.Mvc;
using System.Web;

namespace IdentitySample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //[Authorize /*(Roles="Admin")*/ ]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        //[Authorize (Roles ="User")]
        //[Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        
    }
}

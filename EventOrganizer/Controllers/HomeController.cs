using System.Web.Mvc;

namespace EventOrganizer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}

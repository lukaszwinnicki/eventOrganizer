using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using EventOrganizer.Models;
using EventOrganizer.ViewModels;

namespace EventOrganizer.Controllers
{
    public class HomeController : Controller
    {
        public static List<User> Users = new List<User>();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register(RegisterViewModel viewModel)
        {
            if (UserAuthenticated(viewModel.Email, viewModel.Password))
            {
                FormsAuthentication.SetAuthCookie("registereduser", false);

                return RedirectToAction("Index", "StartPage");
            }

            return View("Index", viewModel);
        }

        bool UserAuthenticated(string userName, string password)
        {
            //Write here the authentication code (it can be from a database, predefined users,, etc)
            return true;
        }
    }
}

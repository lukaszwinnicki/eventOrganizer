using System.Collections.Generic;
using System.Linq;
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
            return View(new IndexViewModel());
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", new IndexViewModel
                                         {
                                             RegistrationViewModel = viewModel
                                         });
            }

            Users.Add(new User { Email = viewModel.Email, Password = viewModel.Password });

            if (UserAuthenticated(viewModel.Email, viewModel.Password))
            {
                FormsAuthentication.SetAuthCookie(viewModel.Email, viewModel.Remember);

                return RedirectToAction("Groups");
            }

            return View("Index", new IndexViewModel
                                     {
                                         RegistrationViewModel = viewModel
                                     });
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", new IndexViewModel
                                         {
                                             LoginViewModel = model
                                         });
            }
            if (UserAuthenticated(model.Email, model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.Email, model.Remember);

                return RedirectToAction("Groups");
            }
            return View("Index", new IndexViewModel
            {
                LoginViewModel = model
            });
        }

        [HttpPost]
        public ActionResult IsValidUser(LoginViewModel viewModel)
        {
            var isValid = UserAuthenticated(viewModel.Email, viewModel.Password);

            return isValid ? Json(new {IsValid = true, Url = Url.Action("Groups")}) : Json(new { IsValid = false, ErrorMessage = "sadsadaq" });
        }

        [Authorize]
        public ActionResult Groups()
        {
            return View();
        }

        bool UserAuthenticated(string userName, string password)
        {
            if (Users.All(x => x.Email != userName))
                return false;
            return Users.Single(x => x.Email == userName).Password == password;
        }
    }
}

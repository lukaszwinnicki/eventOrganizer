using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using EventOrganizer.Models;
using EventOrganizer.Resources;
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
            if (Users.Any(x => x.Email == viewModel.Email))
            {
                ModelState.AddModelError("Email", ValidationMessages.EmailExists);
                return View("Index", new IndexViewModel { RegistrationViewModel = viewModel });
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
        public ActionResult IsValidUser(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { IsValid = false, ErrorMessage = ValidationMessages.IncorrectLoginOrPassword });
            }

            var isValid = UserAuthenticated(viewModel.Email, viewModel.Password);

            if (isValid)
            {
                FormsAuthentication.SetAuthCookie(viewModel.Email, viewModel.Remember);
            }
            return isValid
                       ? Json(new { IsValid = true, Url = Url.Action("Groups") })
                       : Json(new { IsValid = false, ErrorMessage = ValidationMessages.IncorrectLoginOrPassword });
        }

        [Authorize]
        public ActionResult Groups()
        {
            return View("Groups", new GroupsViewModel
                {
                    User = new User { Email = "test@test.com", Password = "Password", PhotoUrl = "/Content/Images/bejdzi.jpg", Name = "Paweł", Surname = "Bejger" },
                    Groups = new List<Group> { 
                        new Group { Description = "Short description", Name = "Beer lovers 1" },
                        new Group { Description = "Short description", Name = "Beer lovers 2" },
                        new Group { Description = "Short description", Name = "Beer lovers 3" },
                        new Group { Description = "Short description", Name = "Beer lovers 4" },
                        new Group { Description = "Short description", Name = "Beer lovers 5" },
                        new Group { Description = "Short description", Name = "Beer lovers 6" },
                        new Group { Description = "Short description", Name = "Beer lovers 7" },
                        new Group { Description = "Short description", Name = "Beer lovers 8" }
                    }
                });
        }

        bool UserAuthenticated(string userName, string password)
        {
            if (Users.All(x => x.Email != userName))
                return false;
            return Users.Single(x => x.Email == userName).Password == password;
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}

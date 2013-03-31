using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using EventOrganizer.Web.Models;
using EventOrganizer.Web.Resources;
using EventOrganizer.Web.Services;
using EventOrganizer.Web.Services.Abstract;
using EventOrganizer.Web.ViewModels;

namespace EventOrganizer.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGroupService _groupService;
        private readonly IUserService _userService;

        public HomeController(IGroupService groupService, IUserService userService)
        {
            _groupService = groupService;
            _userService = userService;
        }

        public ActionResult Index()
        {
            return System.Web.HttpContext.Current.User.Identity.IsAuthenticated
                       ? (ActionResult) RedirectToAction("Groups")
                       : View(new IndexViewModel());
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
            if (_userService.IsEmailAvailable(viewModel.Email))
            {
                ModelState.AddModelError("Email", ValidationMessages.EmailExists);
                return View("Index", new IndexViewModel { RegistrationViewModel = viewModel });
            }

            _userService.Save(new User { Email = viewModel.Email, Password = viewModel.Password });

            if (_userService.CanAuthorize(viewModel.Email, viewModel.Password))
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

            var isValid = _userService.CanAuthorize(viewModel.Email, viewModel.Password);

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
                    User = new User
                        {
                            Email = "test@test.com", 
                            Password = "Password", 
                            PhotoUrl = "/Content/Images/bejdzi.jpg", 
                            Name = "Paweł", 
                            Surname = "Bejger"
                        },
                    Groups = _groupService.GetGropus(User.Identity.Name).ToList()
                });
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}

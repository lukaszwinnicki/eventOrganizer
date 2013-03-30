using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;
using EventOrganizer.Web.Models;
using EventOrganizer.Web.Services.Abstract;

namespace EventOrganizer.Web.Controllers
{
    public class ImageUploaderController : Controller
    {
        private readonly IUserService _userService;

        public ImageUploaderController(IUserService userService)
        {
            _userService = userService;
        }

        public static void CopyStream(Stream input, Stream output)
        {
            var buffer = new byte[8 * 1024];
            int len;
            while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, len);
            }
        }

        public ActionResult UploadImage(long userId, HttpPostedFileBase file)
        {
            User user = _userService.GetUser(userId);

            string root = HttpContext.Server.MapPath("~/Content");

            try
            {
                string userImageDirectory = string.Format("{0}/UserImages/{1}", root, userId);
                if (!Directory.Exists(userImageDirectory))
                {
                    Directory.CreateDirectory(userImageDirectory);
                }

                string imagePath = string.Format("{0}/{1}", userImageDirectory, file.FileName);
                using (FileStream output = System.IO.File.OpenWrite(imagePath))
                {
                    CopyStream(file.InputStream, output);
                }

                string relativeImagePath = string.Format("/Content/UserImages/{0}/{1}", userId, file.FileName);
                user.PhotoUrl = relativeImagePath;
                _userService.Update(user);

                return new ContentResult { Content = relativeImagePath };
            }
            catch (Exception e)
            {
                return new ContentResult { Content = e.Message };
            }
        }
    }
}
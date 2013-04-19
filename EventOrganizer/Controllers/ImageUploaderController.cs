using System;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Mvc;
using EventOrganizer.Web.Models;
using EventOrganizer.Web.Services.Abstract;

namespace EventOrganizer.Web.Controllers
{
    public class ImageUploaderController : Controller
    {
        private readonly IUserService _userService;
        private readonly IEventService _eventService;

        public ImageUploaderController(IUserService userService, IEventService eventService)
        {
            _userService = userService;
            _eventService = eventService;
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
                string relativeThumbnailPath = string.Format("/Content/UserImages/{0}/thumbnail/{1}", userId, file.FileName);
                var myBitmap = new Bitmap(imagePath);
                Image myThumbnail = myBitmap.GetThumbnailImage(40, 40, null, IntPtr.Zero);

                string thumbnailDirectory = string.Format("{0}/thumbnail", userImageDirectory);
                string thumbnailUrl = string.Format("{0}/{1}", thumbnailDirectory, file.FileName);

                if (!Directory.Exists(thumbnailDirectory))
                {
                    Directory.CreateDirectory(thumbnailDirectory);
                }

                myThumbnail.Save(thumbnailUrl);

                user.PhotoUrl = relativeImagePath;
                user.ThumbnailUrl = relativeThumbnailPath;

                _userService.Update(user);

                return new ContentResult { Content = relativeImagePath };
            }
            catch (Exception e)
            {
                return new ContentResult { Content = e.Message };
            }
        }

        public ActionResult UploadEventImage(int eventId, HttpPostedFileBase file)
        {
            if (_eventService.GetEvent(eventId) == null)
                throw new Exception(string.Format("Event with id={0} doesnt exist", eventId));

            string root = HttpContext.Server.MapPath("~/Content");

            try
            {
                string userImageDirectory = string.Format("{0}/EventImages/{1}", root, eventId);
                if (!Directory.Exists(userImageDirectory))
                {
                    Directory.CreateDirectory(userImageDirectory);
                }

                string imagePath = string.Format("{0}/{1}", userImageDirectory, file.FileName);
                using (FileStream output = System.IO.File.OpenWrite(imagePath))
                {
                    CopyStream(file.InputStream, output);
                }

                string relativeImagePath = string.Format("/Content/EventImages/{0}/{1}", eventId, file.FileName);
                _eventService.UpdatePhoto(eventId, relativeImagePath);

                return new ContentResult { Content = relativeImagePath };
            }
            catch (Exception e)
            {
                return new ContentResult { Content = e.Message };
            }
        }
    }
}
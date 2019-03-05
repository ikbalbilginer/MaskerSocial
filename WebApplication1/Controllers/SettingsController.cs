using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SettingsController : Controller
    {
        MaskerContext db = new MaskerContext();
        // GET: Settings
        

        public ActionResult AddImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddImage(HttpPostedFileBase image)
        {
            
                int userid = ((User)Session["user"]).UserId;
                User user = db.Users.Where(u => u.UserId == userid).FirstOrDefault();
                UserImage userimage = new UserImage();

                if (image != null)
                {
                    userimage.Image = new byte[image.ContentLength];
                    image.InputStream.Read(userimage.Image, 0, image.ContentLength);
                }

                user.UserImage = userimage;
                db.SaveChanges();

                return RedirectToAction("Edit","Users");
        }
        
    }
}
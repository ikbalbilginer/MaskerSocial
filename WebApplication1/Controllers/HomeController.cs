using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        MaskerContext db = new MaskerContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string NickName, string Password)
        {
            var enteredUser = db.Users.FirstOrDefault(u => u.NickName == NickName && u.Password == Password);

            if (enteredUser != null)
            {
                Session.Add("user", enteredUser);

                string _username = enteredUser.NickName;
                return RedirectToAction("UserProfile","User",new { username = _username });
            }

            return View();
        }

        
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }
    }
}
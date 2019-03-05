using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BadgeController : Controller
    {
        MaskerContext db = new MaskerContext();
        // GET: Badge
        public ActionResult MyBadges()
        {
            int userid = ((User)Session["user"]).UserId;
            User user = db.Users.Where(u => u.UserId == userid).FirstOrDefault();

            List<Badge> badges = user.Badges.OrderByDescending(b => b.BadgeDate).ToList();

            return View(badges);
        }

        [HttpPost]
        public void DeleteBadge(int badgeid)
        {
            Badge badge = db.tblBadge.Where(b => b.Id == badgeid).FirstOrDefault();
            db.tblBadge.Remove(badge);

            db.SaveChanges();
        }
    }
}
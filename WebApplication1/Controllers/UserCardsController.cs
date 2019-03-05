using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserCardsController : Controller
    {
        MaskerContext db = new MaskerContext();
        Random rnd = new Random();

        // GET: UserCards
        public ActionResult Index()
        {
            List<int> ids = db.Users.Select(u => u.UserId).ToList();
            List<User> threeUser = new List<User>();

            if ((User)Session["user"] != null)
            {
                int s = ((User)Session["user"]).UserId;
                ids.Remove(s);
                List<int> following = ((User)Session["user"]).Following.Select(u => u.UserId).ToList();
                ids.RemoveAll(a => following.Any(f => f == a));

                int Id1 = ids[rnd.Next(ids.Count)];
                ids.Remove(Id1);
                int Id2 = ids[rnd.Next(ids.Count)];
                ids.Remove(Id2);
                int? Id3 = ids[rnd.Next(ids.Count)];

                threeUser.Add(db.Users.Where(u => u.UserId == Id1).FirstOrDefault());
                threeUser.Add(db.Users.Where(u => u.UserId == Id2).FirstOrDefault());
                threeUser.Add(db.Users.Where(u => u.UserId == Id3.Value).FirstOrDefault());
            }

            return View(threeUser);
        }

        [HttpPost]
        public void Follow(int userid, int id)
        {
            var takipedilecekuser = db.Users.FirstOrDefault(x => x.UserId == id);
            var takipeden = db.Users.FirstOrDefault(x => x.UserId == userid);
            takipeden.Following.Add(takipedilecekuser);

            Badge fb = new Badge();
            fb.BadgeDate = DateTime.Now;
            fb.FollowerNickName = takipeden.NickName;
            fb.Kind = Kind.Follow;

            takipedilecekuser.Badges.Add(fb);

            db.SaveChanges();
        }

        [HttpPost]
        public void Unfollow(int userid, int id)
        {
            var takiptenCikilacakUser = db.Users.FirstOrDefault(x => x.UserId == id);
            db.Users.FirstOrDefault(x => x.UserId == userid).Following.Remove(takiptenCikilacakUser);

            db.SaveChanges();
        }

        public ActionResult UserPics()
        {
            List<User> userlist;
            userlist = db.Users.Take(10).ToList();
            return View(userlist);
        }

       
    }
}
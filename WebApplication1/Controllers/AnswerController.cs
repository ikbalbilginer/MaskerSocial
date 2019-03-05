using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AnswerController : Controller
    {
        MaskerContext db = new MaskerContext();
        // GET: Answer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QACard(User Model)
        {
            List<Question> questions = Model.Questions.Where(q => q.Answer != null).ToList();
            return View(questions);
        }

        [HttpPost]
        public void LikeAdd(int answerid)
        {
            int sessionid = ((User)Session["user"]).UserId;
            User user = db.Users.Find(sessionid);

            user.LikedAnswers.Add(db.Answers.Where(q=>q.AnswerId==answerid).FirstOrDefault());

            db.SaveChanges();

            Badge lb = new Badge();
            lb.BadgeDate = DateTime.Now;
            lb.LikedAnswer = db.Answers.Where(q => q.AnswerId == answerid).FirstOrDefault();
            lb.Kind = Kind.Like;

            user.Badges.Add(lb);

            db.SaveChanges();
        }

        [HttpPost]
        public void LikeRemove(int answerid)
        {
            int sessionid = ((User)Session["user"]).UserId;

            Answer answer= db.Answers.Where(q=>q.AnswerId==answerid).FirstOrDefault();

            User user = db.Users.Find(sessionid);
            user.LikedAnswers.Remove(answer);

            db.SaveChanges();
        }

    }
}
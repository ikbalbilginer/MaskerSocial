using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        MaskerContext db = new MaskerContext();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        //Yeni user ekleme action
        [HttpPost]
        public ActionResult Index(User newUser)
        {
            if (ModelState.IsValid)
            {
                //Üyelik başarılıysa Login Panele gidiyoruz.
                MaskerContext db = new MaskerContext();
                db.Users.Add(newUser);
                db.SaveChanges();

                return RedirectToAction("Login", "Home");
            }
            ViewBag.basarisiz = "İşlem başarısız";
            return View();
        }

        
        [HttpGet]
        [Route("{username}")]
        public ActionResult UserProfile(string username)
        {
            if (username == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User selectedUser = db.Users.FirstOrDefault(x => x.NickName == username);
            TempData["userCurrent"] = selectedUser==null?0:selectedUser.UserId;
            if ((User)Session["user"] != null)
            {
                int userid = ((User)Session["user"]).UserId;
                Session["user"] = db.Users.Where(u => u.UserId == userid).FirstOrDefault();
            }
            
            return View(selectedUser);
        }

        [HttpGet]
        public ActionResult Flow()
        {
            int _userid = ((User)Session["user"]).UserId;
            User user = db.Users.Where(u => u.UserId == _userid).FirstOrDefault();

            List<Question> questions = new List<Question>();

            foreach (User item in user.Following)
            {
                foreach (Question question in item.Questions)
                {
                    if (question.Answer != null)
                    {
                        questions.Add(question);
                    }
                }
            }

            questions = questions.OrderBy(q => q.Answer.AnswerDate).ToList();

            return View(questions);
        }

        [HttpGet]
        public ActionResult BigUserCard(int user_id)
        {
            var _user = db.Users.FirstOrDefault(x => x.UserId == user_id);
            return PartialView(_user);
        }

        [HttpGet]
        public ActionResult QuestionBox()
        {
            //ViewBag.list = db.Questions.Where(x => x.UserId == id).ToList();
            return View();
        }

        [HttpPost]
        public JsonResult QuestionBox(string Que, int UserId)
        {
            Question question = new Question();
            question.Que = Que;
            //question.UserId = UserId;

            db.Users.FirstOrDefault(x => x.UserId == UserId).Questions.Add(question);

            db.SaveChanges();

            return Json("bunu görüyorsan sevinebilirsin", JsonRequestBehavior.AllowGet);
        }

        public ActionResult AnsweringPage()
        {
            int userid = ((User)Session["user"]).UserId;
            User user = db.Users.Where(u => u.UserId == userid).FirstOrDefault();
            List<Question> questions = user.Questions.Where(q => q.Answer == null).ToList();

            return View(questions);
        }

        [HttpPost]
        public JsonResult AnsweringPage(string answer,int questionid)
        {
            Answer ans = new Answer();
            ans.Ans = answer;
            ans.AnswerDate = DateTime.Now.Date;

            Question que = db.Questions.Where(qq => qq.QuestionId == questionid).FirstOrDefault();
            que.Answer = ans;
            db.Entry(que).State = System.Data.Entity.EntityState.Modified;
            
            db.SaveChanges();
        
            return Json("Cevap eklendi", JsonRequestBehavior.AllowGet);
        }




    }
}
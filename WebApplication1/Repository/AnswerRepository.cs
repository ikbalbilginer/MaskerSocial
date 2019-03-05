using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class AnswerRepository
    {
        MaskerContext db = new MaskerContext();

        public void Create(Answer answer)
        {
            db.Answers.Add(answer);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            
        }
    }
}
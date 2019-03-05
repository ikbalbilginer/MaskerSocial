using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Question
    {
        public int QuestionId { get; set; }

        public string Que { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual Answer Answer { get; set; }

        public DateTime QuestionDate { get; set; }

        public Question()
        {
            QuestionDate = DateTime.Now;
        }
    }
}
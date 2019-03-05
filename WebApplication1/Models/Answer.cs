using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Answer
    {
        [Key, ForeignKey("Question")]
        public int AnswerId { get; set; }

        public string Ans { get; set; }

        public DateTime AnswerDate { get; set; }

        public virtual Question Question { get; set; }

        public virtual List<Badge> BadgesOfAnswer { get; set; }

        public virtual List<User> Users { get; set; }

        public int likeCount { get { return Users.Count; } }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public enum Kind
    {
        Follow,
        Like
    }

    public class Badge
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime BadgeDate { get; set; }
        public Kind Kind { get; set; }
        public string FollowerNickName { get; set; }

        public virtual Answer LikedAnswer{ get; set; }
    }
   
}
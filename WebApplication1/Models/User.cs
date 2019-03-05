using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Surname { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }

        [MaxLength(50)]
        public string NickName { get; set; }

        public bool Gender { get; set; }

        public string ImageURL { get; set; }

        public virtual List<Question> Questions { get; set; }

        public virtual List<User> Following { get; set; }

        public virtual List<User> Followers { get; set; }

        public virtual List<Answer> LikedAnswers { get; set; }

        public virtual List<Badge> Badges { get; set; }

        public int UserImageId { get; set; }
        public virtual UserImage UserImage { get; set; }

    }
}
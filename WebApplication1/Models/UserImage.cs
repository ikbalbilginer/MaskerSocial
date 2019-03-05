using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UserImage
    {
        [Key, ForeignKey("User")]
        public int UserId { get; private set; }
        public User User { get; set; }

        public byte[] Image { get; set; }
    }
}
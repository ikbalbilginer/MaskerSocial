using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class MaskerContext : DbContext
    {
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Badge> tblBadge { get; set; }

        public virtual DbSet<UserImage> UserImages { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u=>u.Followers).WithMany(v=>v.Following)
                .Map(w => w.ToTable("User_Follow").MapLeftKey("UserId").MapRightKey("FollowerID"));

            modelBuilder.Entity<Question>()
                .HasRequired<User>(q => q.User)
                .WithMany(u => u.Questions)
                .HasForeignKey<int>(q => q.UserId);
            
            modelBuilder.Entity<Question>()
                .HasOptional(q => q.Answer)
                .WithRequired(a => a.Question);

            modelBuilder.Entity<UserImage>()
                .HasRequired(u => u.User);


            base.OnModelCreating(modelBuilder);
        }



    }

    
}
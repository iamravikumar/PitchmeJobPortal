using Microsoft.AspNet.Identity.EntityFramework;
using Pitchme.Models.Implementation;
using PitchMe.Models.Implementation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchMe.Models
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("PitchMeDBConnection", throwIfV1Schema: false)
        {

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
        }

        //public System.Data.Entity.DbSet<Pitchme.Models.Implementation.JobSubscription> JobSubscriptions { get; set; }
        public DbSet<Company> Companies { get; set; }

        public System.Data.Entity.DbSet<Pitchme.Models.Implementation.Job> Jobs { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<EducationBackground> EducationBackgrounds { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
    }
}

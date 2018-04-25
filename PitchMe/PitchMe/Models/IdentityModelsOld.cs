using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Pitchme.Models.Implementation;
//using Pitchme.Models.Implementation;
//using PitchMe.Models.Implementation;

namespace PitchMe.Models
{

    public class ApplicationDbContext1 : IdentityDbContext<User>
    {
        /*
        public ApplicationDbContext1()
            : base("PitchMeDBConnection", throwIfV1Schema: false)
        {
            
        }

        public static IdentityModels Create()
        {
            return new IdentityModels();
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

        */
    }
}
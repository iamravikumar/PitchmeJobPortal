using System.ComponentModel;
using Pitchme.Models.Contracts;
using System;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using PitchMe.Models.Implementation;

namespace Pitchme.Models.Implementation
{
    [Serializable]
    public class User : IdentityUser
    {
        public bool IsCompanyUser { get; set; }
        public virtual IList<JobApplication> jobApplications { get; set; }
        public virtual IList<Subscription> jobSubscriptions { get; set; }
        public virtual IList<Job> FavouriteJobs { get; set; }
        public virtual Resume Resume { get; set; }

        public string checkId
        {
            get
            { 
                return Id;
            }
            set { }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

   

}

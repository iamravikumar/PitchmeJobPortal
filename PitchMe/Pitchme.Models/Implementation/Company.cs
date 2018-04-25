using System.ComponentModel;
using Pitchme.Models.Contracts;
using System;
using System.Collections.Generic;

namespace Pitchme.Models.Implementation
{
    [Serializable]
    public class Company : Entity, ICompany
    {
        public string UserId { get; set; }

        public virtual string Name { get; set; }
        public virtual string Location { get; set; }
        public virtual string Description { get; set; }
        public string ProfileImageUri { get; set; } = "~/assets/images/job/4.png";
        [DisplayName("Phone Number")]
        public virtual string ContactNumberOne { get; set; }
        [DisplayName("Alternate Phone Number")]
        public virtual string ContactNumberTwo { get; set; }
        public virtual IList<Job> Jobs { get; set; }
    }
}

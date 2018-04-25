using System;
using Pitchme.Models.Enums;
using Pitchme.Models.Contracts;
using PitchMe.Models.Contracts;
using PitchMe.Models.Implementation;

namespace Pitchme.Models.Implementation
{
    [Serializable]
    public class Job : Entity, IJob
    {
        public virtual int NumberOfApplicants { get; set; }

        public virtual string Title { get; set; }        
        public virtual string Description { get; set; }        
        public virtual string State { get; set; }
        public decimal MinimumSalary { get; set; }
        public decimal MaximumSalary { get; set; }
        public bool IsSalaryNegotiable { get; set; }        
        public virtual string RequiredSkills { get; set; }
        public virtual string Country { get; set; }        
        public virtual string Responsibilities { get; set; }

        public DateTime DatePosted { get; set; }
        public virtual DateTime ApplicationDeadline { get; set; }                
        public virtual JobType Type { get; set; }
        public virtual ExperienceLevel ExperienceLevel { get; set; }
        public virtual JobStatus JobStatus { get; set; }

        public virtual long CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public virtual long JobCategoryId { get; set; }
        public virtual JobCategory JobCategory { get; set; }

        //public virtual ICompany Company { get; set; }
        //public virtual long YearsOfExperience { get; set; }
        //public virtual string MinimumQualification { get; set; }
        //public virtual string Specialization { get; set; }
        //public virtual string Location { get; set; }
        //public virtual string Objectives { get; set; }
        //public virtual RenumerationRange Renumeration { get; set; }
    }
}

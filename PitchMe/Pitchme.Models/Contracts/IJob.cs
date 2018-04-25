using System;
using Pitchme.Models.Enums;
using Pitchme.Models.Implementation;
using PitchMe.Models.Implementation;

namespace Pitchme.Models.Contracts
{
    public interface IJob : IEntity
    {
        int NumberOfApplicants { get; set; }
        string Title { get; set; }        
        string RequiredSkills { get; set; }
        string Description { get; set; }                
        string State { get; set; }
        string Country { get; set; }        
        string Responsibilities { get; set; }
        DateTime DatePosted { get; set; }
        DateTime ApplicationDeadline { get; set; }

        JobType Type { get; set; }
        ExperienceLevel ExperienceLevel { get; set; }
        long CompanyId { get; set; }
        Company Company { get; set; }
        long JobCategoryId { get; set; }
        JobCategory JobCategory { get; set; }

        //RenumerationRange Renumeration { get; set; }
        //long YearsOfExperience { get; set; }
        //ICompany Company { get; set; }
        //string Location { get; set; }
        //string Objectives { get; set; }
        //string MinimumQualification { get; set; }
        //string Specialization { get; set; }
    }
}

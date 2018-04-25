using Pitchme.Models.Contracts;
using PitchMe.Models.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchMe.Models.Contracts
{
    interface IResume : IEntity
    {
        string FullName { get; set; }
        string AdditionalInformation { get; set; }
        string ProfileImageUri { get; set; }
        string CareerObjective { get; set; }
        string SkillsAndQualifications { get; set; }

        string FatherName { get; set; }
        string MotherName { get; set; }
        DateTime DateOfBirth { get; set; }
        string PlaceOfBirth { get; set; }
        string Nationality { get; set; }
        string Address { get; set; }
        string Declaration { get; set; }
        string Gender { get; set; }

        List<WorkExperience> WorkExperiences { get; set; }
        IList<EducationBackground> EducationBackgrounds { get; set; }
        IList<Language> Languages { get; set; }
    }
}

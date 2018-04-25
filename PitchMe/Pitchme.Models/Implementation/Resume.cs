using Pitchme.Models.Enums;
using Pitchme.Models.Implementation;
using PitchMe.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchMe.Models.Implementation
{
    public class Resume : Entity, IResume
    {
        public string FullName { get; set; }
        public string AdditionalInformation { get; set; }
        public string ProfileImageUri { get; set; }
        public string CareerObjective { get; set; }
        public string SkillsAndQualifications { get; set; }

        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }
        public string Declaration { get; set; }
        public string Gender { get; set; }

        public virtual List<WorkExperience> WorkExperiences { get; set; }
        public virtual IList<EducationBackground> EducationBackgrounds { get; set; }
        public virtual IList<Language> Languages { get; set; }

        //public User User { get; set; }
    }

    
    
}

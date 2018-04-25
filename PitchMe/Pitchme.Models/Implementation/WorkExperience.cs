using Pitchme.Models.Implementation;
using PitchMe.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchMe.Models.Implementation
{
    public class WorkExperience : Entity, IWorkExperience
    {
        public string CompanyName { get; set; }
        public string Designation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string JobDescription { get; set; }
        public virtual long ResumeId { get; set; }
    }
}

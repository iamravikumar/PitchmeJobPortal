using Pitchme.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchMe.Models.Contracts
{
    public interface IWorkExperience : IEntity
    {
         string CompanyName { get; set; }
         string Designation { get; set; }
         DateTime StartDate { get; set; }
         DateTime EndDate { get; set; }
         string JobDescription { get; set; }
         long ResumeId { get; set; }
    }
}

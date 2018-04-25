using Pitchme.Models.Implementation;
using PitchMe.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchMe.Models.Implementation
{
    public class EducationBackground : Entity, IEducationBackground
    {
        public string InstitutionNamme { get; set; }
        public string DegreeAwarded { get; set; }
        public string Description { get; set; }
        //public virtual long ResumeId { get; set; }
        //[ForeignKey("ID")]
        public virtual Resume Resume { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

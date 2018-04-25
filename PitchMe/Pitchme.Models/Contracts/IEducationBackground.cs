using Pitchme.Models.Contracts;
using PitchMe.Models.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchMe.Models.Contracts
{
    public interface IEducationBackground : IEntity
    {
        string InstitutionNamme { get; set; }
        string DegreeAwarded { get; set; }
        string Description { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        Resume Resume { get; set; }
    }
}

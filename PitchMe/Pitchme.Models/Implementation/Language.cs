using Pitchme.Models.Implementation;
using PitchMe.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchMe.Models.Implementation
{
    public class Language : Entity, ILanguage
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public virtual long ResumeId { get; set; }
    }
}

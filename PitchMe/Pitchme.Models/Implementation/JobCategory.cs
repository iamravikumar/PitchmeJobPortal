using Pitchme.Models.Implementation;
using PitchMe.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchMe.Models.Implementation
{
    public class JobCategory: Entity, IJobCategory
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual IList<Job> Jobs { get; set; }
    }
}

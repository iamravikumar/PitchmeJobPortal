using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitchme.Models.Enums;
using Pitchme.Models.Contracts;

namespace Pitchme.Models.Implementation
{
    [Serializable]
    public class JobApplication : Entity, IJobApplication
    {
        public virtual User user { get; set; }
        public virtual Job job { get; set; }
        //public virtual ICompany company { get; set; }
        public virtual string pitchLocation { get; set; }
        public virtual string cvLocation { get; set; }
        public virtual ApplicationStatus applicationStatus { get; set; }
        public virtual bool Subscribed { get; set; }
    }
}

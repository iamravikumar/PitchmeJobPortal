using Pitchme.Models.Contracts;
using Pitchme.Models.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchMe.Models.Contracts
{
    public interface IJobCategory:IEntity
    {
        string Name { get; set; }
        string Description { get; set; }
        IList<Job> Jobs { get; set; }
    }
}

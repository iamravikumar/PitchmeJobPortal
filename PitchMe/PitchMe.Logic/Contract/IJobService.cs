using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitchme.Models.Implementation;
using System.Linq.Expressions;

namespace PitchMe.Services.Contract
{
    public interface IJobService
    {
        void PostJob(Job job);

        IEnumerable<Job> FindJob(Dictionary<string, object> dict);
        void ChangeStatus(long jobId, int status);
    }
}

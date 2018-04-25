using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitchme.Models.Implementation;
using System.Linq.Expressions;

namespace PitchMe.Services.Contract
{
    public interface IJobApplicationService
    {
        void PostJobApplication(JobApplication jobApplication);

        IEnumerable<JobApplication> FindJobApplication(Dictionary<string, object> dict);
        string GetMessage(string code);
    }
}

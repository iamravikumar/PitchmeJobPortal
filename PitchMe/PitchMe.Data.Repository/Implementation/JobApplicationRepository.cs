using Pitchme.Models.Implementation;
using PitchMe.Data.Repository.Contract;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
//using PitchMe.Data.Implementation;

namespace PitchMe.Data.Repository.Implementation
{
    public class JobApplicationRepository : Repository<JobApplication>, IJobApplicationRepository
    {
        public JobApplicationRepository(DbContext dbContext) : base(dbContext)
        {
        }
        public List<User> GetApplicants(long jobId)
        {
            return this.Find(j => j.job.ID == jobId).ToList().Select(j => j.user).ToList();
        }
    }
}

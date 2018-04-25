using Pitchme.Models.Implementation;
using PitchMe.Data.Repository.Contract;
using PitchMe.Models.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchMe.Data.Repository.Implementation
{
    public class JobCategoryRepository : Repository<JobCategory>, IJobCategoryRepository
    {
        public JobCategoryRepository(System.Data.Entity.DbContext dbContext) : base(dbContext)
        {

        }
    }
}

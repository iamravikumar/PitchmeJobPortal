using Pitchme.Models.Implementation;
using PitchMe.Data.Repository.Contract;
using PitchMe.Data.Implementation;

namespace PitchMe.Data.Repository.Implementation
{
    public class JobRepository : Repository<Job>, IJobRepository
    {
        protected static System.Data.Entity.DbContext _dbContext; //Get instance from container
        public JobRepository(System.Data.Entity.DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}

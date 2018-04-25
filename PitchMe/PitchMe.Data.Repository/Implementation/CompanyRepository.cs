using Pitchme.Models.Implementation;
using PitchMe.Data.Repository.Contract;
using System.Collections.Generic;
using System.Collections;
using PitchMe.Data.Implementation;
using PitchMe.Data.Contract;
using System.Linq;

namespace PitchMe.Data.Repository.Implementation
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(System.Data.Entity.DbContext dbContext) : base(dbContext)
        {
            
        }
        public Company GetCompanyByUserId(string userId)
        {
            return base.Find(c => string.Compare(c.UserId, userId, true) == 0).FirstOrDefault();            
        }
    }
}

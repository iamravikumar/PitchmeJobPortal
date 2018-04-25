using Pitchme.Models.Implementation;
using PitchMe.Data.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchMe.Data.Repository.Implementation
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(System.Data.Entity.DbContext ctx) : base(ctx)
        {

        }
    }
}

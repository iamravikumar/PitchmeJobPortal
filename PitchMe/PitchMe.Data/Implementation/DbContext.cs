using PitchMe.Data.Contract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitchme.Models.Implementation;

namespace PitchMe.Data.Implementation
{
    public class DbContext : IDbContext
    {
        public DbContext(string dbConnectionStringOrName) 
            : base (dbConnectionStringOrName)
        {
        }
    }
}

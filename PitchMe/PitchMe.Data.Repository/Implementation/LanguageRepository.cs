using PitchMe.Data.Repository.Contract;
using PitchMe.Models.Implementation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchMe.Data.Repository.Implementation
{
    public class LanguageRepository : Repository<Language>, ILanguageRepository
    {
        public LanguageRepository(DbContext ctx) : base(ctx)
        {

        }
    }
}

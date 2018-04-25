using Pitchme.Models.Implementation;
using PitchMe.Data.Repository.Contract;
using PitchMe.Data.Implementation;
using System.Linq;
using PitchMe.Models.Implementation;

namespace PitchMe.Data.Repository.Implementation
{
    public class JobSubscriptionRepository : Repository<Subscription>, IJobSubscriptionRepository
    {
        protected static System.Data.Entity.DbContext _dbContext; //Get instance from container
        public JobSubscriptionRepository(System.Data.Entity.DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public bool HasActivePeriodicSubscription(string userID)
        {
            return base.Find(x => x.User.checkId == userID 
                && x.SubscriptionType == Pitchme.Models.Enums.SubscriptionType.Periodic
                &&
                (x as PeriodicSubscription).SubscriptionExpiration >= System.DateTime.Now).Any();
        }
        public bool HasActiveSingleSubscription(string userID)
        {
            return base.Find(x => x.User.checkId == userID && (x.SubscriptionType == Pitchme.Models.Enums.SubscriptionType.Single && (x as SingleSubscription).IsActive == true)).Any();
        }

        public PeriodicSubscription GetActivePeriodicSubscription(string userID)
        {
            return base.Find(x => x.User.checkId == userID
            && x.SubscriptionType == Pitchme.Models.Enums.SubscriptionType.Periodic
             &&
                (x as PeriodicSubscription).SubscriptionExpiration >= System.DateTime.Now).FirstOrDefault() as PeriodicSubscription;
        }
        public SingleSubscription GetActiveSingleSubscription(string userID)
        {
            return base.Find(x => x.User.checkId == userID && (x.SubscriptionType == Pitchme.Models.Enums.SubscriptionType.Single && (x as SingleSubscription).IsActive == true)).FirstOrDefault() as SingleSubscription;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Pitchme.Models.Implementation;
using PitchMe.Models.Implementation;

namespace PitchMe.Data.Repository.Contract
{
    public interface IJobSubscriptionRepository : IRepository<Subscription>
    {
        bool HasActivePeriodicSubscription(string userID);
        bool HasActiveSingleSubscription(string userID);
        PeriodicSubscription GetActivePeriodicSubscription(string userID);
        SingleSubscription GetActiveSingleSubscription(string userID);
    }
}

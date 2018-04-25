using Pitchme.Models.Enums;
using Pitchme.Models.Implementation;
using PitchMe.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchMe.Models.Implementation
{
    public class PeriodicSubscription : Subscription
    {          
        public virtual DateTime? SubscriptionExpiration { get; set; }
        public virtual int NumberOfMonths { get; set; }
    }
}

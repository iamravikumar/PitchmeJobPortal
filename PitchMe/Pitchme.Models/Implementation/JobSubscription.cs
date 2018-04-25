using System;
using Pitchme.Models.Enums;
using Pitchme.Models.Contracts;

namespace Pitchme.Models.Implementation
{
    [Serializable]
    public class JobSubscriptionOld : Entity, IJobSubscriptionOld
    {
        public virtual User user { get; set; }
        public virtual IJobApplication jobApplication { get; set; }
        public virtual DateTime subscriptionDate { get; set; }
        public virtual DateTime? subscriptionExpiration { get; set; } //This is made nullable as it isnt needed for single job subscription
        public virtual SubscriptionType subscriptionType { get; set; }
        public virtual int NumberOfMonths { get; set; }
        public virtual string PhoneNumber { get; set; }
    }
}

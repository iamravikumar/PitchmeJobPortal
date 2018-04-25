using System;
using Pitchme.Models.Enums;

namespace Pitchme.Models.Contracts
{
    public interface IJobSubscriptionOld : IEntity
    {
        IJobApplication jobApplication { get; set; }
        DateTime subscriptionDate { get; set; }
        DateTime? subscriptionExpiration { get; set; } //This is made nullable as it isnt needed for single job subscription
        SubscriptionType subscriptionType { get; set; }
        int NumberOfMonths { get; set; }
        string PhoneNumber { get; set; }
    }
}

using Pitchme.Models.Contracts;
using Pitchme.Models.Enums;
using Pitchme.Models.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchMe.Models.Contracts
{
    public interface ISubscription : IEntity
    {
        string PhoneNumber { get; set; }
        SubscriptionType SubscriptionType { get; set; }
        User User { get; set; }
        decimal Amount { get; set; }
    }
}

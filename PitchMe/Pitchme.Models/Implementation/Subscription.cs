using Pitchme.Models.Contracts;
using Pitchme.Models.Enums;
using Pitchme.Models.Implementation;
using PitchMe.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchMe.Models.Implementation
{
    public class Subscription : Entity, ISubscription
    {
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public SubscriptionType SubscriptionType { get; set; }
        public User User { get; set; }
        public decimal Amount { get; set; }
    }
}

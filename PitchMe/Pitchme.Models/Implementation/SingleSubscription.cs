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
    public class SingleSubscription : Subscription
    {
        public bool IsActive { get; set; }
        public long JobApplicationId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitchme.Models.Implementation;

namespace PitchMe.Services.Contract
{
    public interface IJobSubscriptionService
    {
        //Call the IJobSubscription Repository interface from the Service Locator

        /// <summary>
        /// Checks if the requesting user has an active job subscription. Applies to subscription made to cover a period
        /// </summary>
        /// <param name="user"></param>
        /// <returns>True/ False</returns>
        bool CheckPeriodicSubscriptionStatus(User user);

        bool CheckSingleSubscriptionStatus(User user);

        /// <summary>
        /// Called to activate subscription for a period. This adds an entry to the subscription table.
        /// Ensures job applicatons are posted if subscription is active
        /// </summary>
        /// <param name="user"></param>
        /// <param name="noOfMonths"></param>
        /// <returns>True/ False</returns>
        Task<string> SubscribeForAPeriod(User user, int noOfMonths, string phone);

        /// <summary>
        /// Called to activate subscription for a single job application posting. This adds an entry to the subscription table.
        /// </summary>
        /// <param name="jobSubscription"></param>
        /// <returns>True/ False</returns>
        Task<string> MakeSingleJobSubscription(User user, string phone, long jobApplicationId);
    }
}

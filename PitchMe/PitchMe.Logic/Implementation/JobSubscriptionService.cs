using PitchMe.Services.Contract;
using Pitchme.Models.Implementation;
using PitchMe.Data.Repository.Implementation;
using System;
using System.Threading.Tasks;
using PitchMe.Models.Implementation;
using Pitchme.Models.Enums;
using PitchMe.Data.Repository.Contract;

namespace PitchMe.Services.Implementation
{
    public class JobSubscriptionService : IJobSubscriptionService
    {
        //private JobSubscriptionRepository _jobSubscriptionRepository; //Get container instance
        IUnitOfWork uow;
        public JobSubscriptionService(IUnitOfWork _uow)
        {
            uow = _uow;
        }
        public bool CheckPeriodicSubscriptionStatus(User user)
        {
            return uow.jobSubscriptionRepository.HasActivePeriodicSubscription(user.checkId);
        }
        public bool CheckSingleSubscriptionStatus(User user)
        {
            return uow.jobSubscriptionRepository.HasActiveSingleSubscription(user.checkId);
        }

        public async Task<string> SubscribeForAPeriod(User user, int noOfMonths, string phone)
        {
            decimal monthlyCharge = 2000;
            decimal amount = monthlyCharge * noOfMonths;
            if(!(await ConfirmPhoneNumberAsync(phone)))
            {
                return "Error confirming phone number";
            }
            if (!(await DebitPhoneAsync(phone,amount)))
            {
                return "Transaction failed";
            }


            try
            {
                Subscription newEntry = new PeriodicSubscription
                {
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    SubscriptionType = SubscriptionType.Periodic,
                    NumberOfMonths = noOfMonths,
                    PhoneNumber = phone,
                    SubscriptionExpiration = DateTime.Now.AddMonths(noOfMonths),
                    User = user
                };                

                uow.jobSubscriptionRepository.Add(newEntry);
                uow.Save();
                return "Success";
            }
            catch (Exception ex)
            {
                return "Error saving subscription, please contact admin";
            }
        }
        private async Task<bool> ConfirmPhoneNumberAsync(string phone)
        {
            return true;
        }
        private async Task<bool> DebitPhoneAsync(string phone, decimal amount)
        {
            return true;
        }

        public async Task<string> MakeSingleJobSubscription(User user, string phone, long jobApplicationId)
        {
            //To be done in the controller 

            try
            {
                decimal constantCharge = 100m;
                if (!(await ConfirmPhoneNumberAsync(phone)))
                {
                    return "Error confirming phone number";
                }
                if (!(await DebitPhoneAsync(phone, constantCharge)))
                {
                    return "Transaction failed";
                }

                Subscription newEntry = new SingleSubscription
                {
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    SubscriptionType = Pitchme.Models.Enums.SubscriptionType.Single,
                    IsActive = true,
                    PhoneNumber = phone,
                    User = user,
                    Amount = constantCharge,
                    JobApplicationId = jobApplicationId
                };

                uow.jobSubscriptionRepository.Add(newEntry);
                uow.Save();
                return "Success";
            }
            catch (Exception ex)
            {
                //Log
                return "Error saving subscription, please contact admin";
            }
        }
    }
}

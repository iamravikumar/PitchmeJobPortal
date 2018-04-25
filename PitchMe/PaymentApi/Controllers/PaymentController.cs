using PitchMe.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PaymentApi.Controllers
{
    public class PaymentController : ApiController
    {
        public List<string[]> GetBillingInfo()
        {
            List<string[]> billingInfo = new List<string[]>();
            string[] billingItem = new string[6];

            try
            {
                using (var dbContext = new ApplicationDbContext())
                {
                    var data = dbContext.Subscriptions.Where(x => x.SubscriptionType == Pitchme.Models.Enums.SubscriptionType.Periodic).ToList();

                    foreach (var item in data)
                    {
                        billingItem[0] = item.PhoneNumber;
                        billingItem[1] = ""; //jobApplicationId
                        billingItem[2] = ""; //Amount
                        billingItem[3] = item.User.Id;

                        billingInfo.Add(billingItem);
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.TraceInformation($"An error occured while preparing billing info :: Message - {ex.Message}, Source - {ex.Source}, Inner Exception {ex.InnerException}, StackTrace - {ex.StackTrace}");
            }
            return billingInfo;
        }

        public bool UpdateUserSubscription(string userID, string jobApplicationId, string phonenumber, string AmountCharged)
        {
            Trace.TraceInformation($"Params :: UserID - {userID}, JobApplicationID - {jobApplicationId}, phoneNumber - {phonenumber}, AmountCharged - {AmountCharged}");
            try
            {
                using (var dbContext = new ApplicationDbContext())
                {
                    using (var dbContextTransaction = dbContext.Database.BeginTransaction())
                    {
                        var subscription = dbContext.Subscriptions.FirstOrDefault(x => x.User.Id == userID && x.PhoneNumber == phonenumber);

                        //subscription.isActive = true;
                        dbContext.Entry(subscription).State = System.Data.Entity.EntityState.Modified;
                        dbContext.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Trace.TraceInformation($"An error occured while updating user subscription :: UserID - {userID}, JobApplicationID - {jobApplicationId}, phoneNumber - {phonenumber}, AmountCharged - {AmountCharged}  \n Message - {ex.Message}, Source - {ex.Source}, Inner Exception {ex.InnerException}, StackTrace - {ex.StackTrace}");
                return false;
            }
        }

        // GET: api/Payment
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Payment/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Payment
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Payment/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Payment/5
        public void Delete(int id)
        {
        }
    }
}

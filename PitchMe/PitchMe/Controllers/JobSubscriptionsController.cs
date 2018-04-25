using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PitchMe.Models;
using Pitchme.Models.Implementation;
using Microsoft.AspNet.Identity;
using PitchMe.Services.Contract;
using Pitchme.Models.Enums;
using PitchMe.App_Start;
using PitchMe.Models.Implementation;
using PitchMe.Data.Repository.Contract;

namespace PitchMe.Controllers
{
    [UsageLoggingFilterAttribute]
    public class JobSubscriptionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        IJobSubscriptionService jobSubService;
        private ApplicationUserManager userMgr;
        private IUnitOfWork uow;
        public JobSubscriptionsController(IJobSubscriptionService _jobSubService, ApplicationUserManager _userMgr, IUnitOfWork _uow)
        {
            jobSubService = _jobSubService;
            userMgr = _userMgr;
            uow = _uow;
        }
        //

        /*
        // GET: JobSubscriptions
        public async Task<ActionResult> Index()
        {
            return View(await db.JobSubscriptions.ToListAsync());
        }

        // GET: JobSubscriptions/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscription jobSubscription = await db.JobSubscriptions.FindAsync(id);
            if (jobSubscription == null)
            {
                return HttpNotFound();
            }
            return View(jobSubscription);
        }
        */

        // GET: JobSubscriptions/Create
        public ActionResult Create(string message, string videoFileName)
        {
            ViewBag.Msg = message;
            ViewBag.VideoFileName = videoFileName;
            ViewBag.SubscriptionType = new SelectList(Enum.GetValues(typeof(SubscriptionType)));
            var model = new Subscription();
            return View(model);
        }

        // POST: JobSubscriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(/*[Bind(Include = "ID,subscriptionDate,subscriptionExpiration,subscriptionType")]*/ Subscription jobSubscription, int noOfMonths, string VidFileName)
        {
            ViewBag.SubscriptionType = new SelectList(Enum.GetValues(typeof(SubscriptionType)));

            if (ModelState.IsValid)
            {
                var user = userMgr.FindById(User.Identity.GetUserId());
                string result = string.Empty;
                if (jobSubscription.SubscriptionType == SubscriptionType.Single)
                {
                    if(String.IsNullOrEmpty(VidFileName) || !VidFileName.Contains("_"))
                    {
                        ViewBag.Msg = "You can not make a single subscription without a recorded video";
                        return View(jobSubscription);
                    }
                    long jobAppId = Int64.Parse(VidFileName.Split('_')[0]);
                    var jobApp = uow.jobApplicationRepository.Get(jobAppId);
                    if (!String.IsNullOrEmpty(jobApp.pitchLocation))
                    {
                        ViewBag.Msg = "You have already submitted a pitch for this job. Please select a periodic subscription instead";
                        return View();
                    }
                    result = await jobSubService.MakeSingleJobSubscription(user, jobSubscription.PhoneNumber, jobAppId);                    
                    if(String.Compare(result, "Success", true) == 0)
                    {
                        jobApp.pitchLocation = VidFileName;
                        uow.jobApplicationRepository.Update(jobApp);
                        uow.Save();
                    }
                }
                else
                {
                    if(noOfMonths < 1)
                    {
                        ViewBag.Msg = "Please enter the number of months";
                        return View(jobSubscription);
                    }
                    result = await jobSubService.SubscribeForAPeriod(user, (int)noOfMonths, jobSubscription.PhoneNumber);
                    if (String.Compare(result, "Success", true) == 0 && VidFileName.Contains('_'))
                    {
                        long jobAppId = Int64.Parse(VidFileName.Split('_')[0]);
                        var jobApp = uow.jobApplicationRepository.Get(jobAppId);
                        jobApp.pitchLocation = VidFileName;
                        uow.jobApplicationRepository.Update(jobApp);
                        uow.Save();
                    }
                }
                
                ViewBag.Msg = result;
                return RedirectToAction("Create");
            }
            ViewBag.Msg = "Incorrect data";
            return View(jobSubscription);
        }

        /*
        // GET: JobSubscriptions/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscription jobSubscription = await db.JobSubscriptions.FindAsync(id);
            if (jobSubscription == null)
            {
                return HttpNotFound();
            }
            return View(jobSubscription);
        }

        // POST: JobSubscriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,subscriptionDate,subscriptionExpiration,subscriptionType")] Subscription jobSubscription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobSubscription).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(jobSubscription);
        }

        // GET: JobSubscriptions/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscription jobSubscription = await db.JobSubscriptions.FindAsync(id);
            if (jobSubscription == null)
            {
                return HttpNotFound();
            }
            return View(jobSubscription);
        }

        // POST: JobSubscriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Subscription jobSubscription = await db.JobSubscriptions.FindAsync(id);
            db.Subscriptions.Remove(jobSubscription);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        */

        //[HttpPost, ActionName("Search")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Search()
        //{

        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

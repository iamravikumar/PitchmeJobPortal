using Newtonsoft.Json;
using Pitchme.Models.Enums;
using Pitchme.Models.Implementation;
using PitchMe.Data.Repository.Contract;
using PitchMe.Models;
using PitchMe.Models.Implementation;
using PitchMe.Services.Contract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Pitchme.Models.Contracts;
using PitchMe.Services.Implementation;
using PagedList;
using PitchMe.App_Start;
using PitchMe.Models.ViewModels;
using System.Web.Helpers;
using System.Reflection;
using System.IO;

namespace PitchMe.Controllers
{
    [Authorize]
    [UsageLoggingFilterAttribute]
    public class JobController : Controller
    {
        
        private IJobService jobService;
        IJobApplicationService jobApplicationService;
        private IJobSubscriptionService jobSubService;
        private ApplicationUserManager userManager;
        private IUnitOfWork uow;        
        public JobController(IUnitOfWork _uow, IJobService _jobService, ApplicationUserManager _userManager, IJobApplicationService _jobAppService, IJobSubscriptionService _jobSubService)
        {
            jobService = _jobService;
            userManager = _userManager;
            jobSubService = _jobSubService;
            jobApplicationService = _jobAppService;
            uow = _uow;
        }

        #region index commented
        
        [AllowAnonymous]
        // GET: Job
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, string state, string category, int? page, JobSearchModel jsmodel = null)
        {
            return RedirectToAction("S");
            /*
            //check if it's ajax result ==> return the list and update only the list section            
       
            ViewBag.CurrentSort = sortOrder;
            ViewBag.PopularSortParm = "popular";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.SalarySortParm = "salary_desc";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var model = uow.jobRepository.GetAll();

            if (Request.IsAjaxRequest())
            {
                Dictionary<string, object> searchObj = JobModelToDict(jsmodel);
                model = jobService.FindJob(searchObj);
                return PartialView("_JobList", model.ToList());
            }
            else if (!(String.IsNullOrEmpty(searchString) || string.IsNullOrEmpty(state) || String.IsNullOrEmpty(category)))
            {
                jsmodel = new JobSearchModel { SearchString = searchString, Category = category, State = state };
                Dictionary<string, object> searchObj = JobModelToDict(jsmodel);
                model = jobService.FindJob(searchObj);
            }


            switch (sortOrder)
            {
                case "salary_desc":
                    model = model.OrderByDescending(s => s.MaximumSalary);
                    break;
                case "popular":
                    model = model.OrderByDescending(s => s.NumberOfApplicants);
                    break;
                case "Date":
                    model = model.OrderBy(s => s.DatePosted);
                    break;
                case "date_desc":
                    model = model.OrderByDescending(s => s.DatePosted);
                    break;
                default:  // Name ascending 
                    model = model.OrderByDescending(s => s.DatePosted);
                    break;
            }

           

            ViewBag.JobCatId = uow.jobCategoryRepository.GetAll().AsEnumerable()
                .Select(j => new SelectListItem { Text = j.Name, Value = Convert.ToString(j.Jobs.Count()) });
            ViewBag.State = CountryStates.GetStates("Nigeria");
            ViewBag.Companies = uow.companyRepository.GetAll().Select(c => c.Name);
            ViewBag.JobType = Enum.GetValues(typeof(JobType));
            ViewBag.ExperienceLevel = Enum.GetValues(typeof(ExperienceLevel));


            int pageSize = 10;
            int pageNumber = (page ?? 1);

            int jobStartNum = GetJobStart(pageNumber, pageSize);
            int jobEndNum = GetJobEnd(model.Count(), pageNumber, pageSize, jobStartNum);
            ViewBag.StartIndex = jobStartNum;
            ViewBag.EndIndex = jobEndNum;
            ViewBag.ModelCount = model.Count();
            return View(model.ToPagedList(pageNumber, pageSize));
            */
        }
        
        #endregion

        [AllowAnonymous]
        public ActionResult S(string o, string f, string s, string st, string ct, int? p, JobSearchViewModel jsmodelkk, JobListVM vm)
        {
            ViewBag.CurrentSort = o;
            ViewBag.PopularSortParm = "popular";
            ViewBag.DateSortParm = o == "Date" ? "date_desc" : "Date";
            ViewBag.SalarySortParm = "salary_desc";

            if (s != null)
            {
                p = 1;
            }
            else
            {
                s = f;
            }
            ViewBag.CurrentFilter = s;

            var model = uow.jobRepository.GetAll();
            var jsmodel = new JobSearchViewModel();
            if(vm != null)
            {
                if (vm.JobSearchViewModel != null)
                    jsmodel = vm.JobSearchViewModel;
            }
            ViewBag.Sstr = "";
            if (!String.IsNullOrEmpty(s))
            {
                jsmodel.SearchString = s;
                ViewBag.Sstr = s;
            }

            ViewBag.Stt = "Job Location";
            if (!String.IsNullOrEmpty(st))
            {
                jsmodel.State = st;
                ViewBag.Stt = st;
            }

            ViewBag.Cat = "Job Category";
            if (!String.IsNullOrEmpty(ct))
            {
                jsmodel.SearchString = ct;
                ViewBag.Cat = ct;
            }
                

            Dictionary<string, object> searchObj = JobModelToDict(jsmodel);
            model = jobService.FindJob(searchObj);

            switch (o)
            {
                case "salary_desc":
                    model = model.OrderByDescending(m => m.MaximumSalary);
                    break;
                case "popular":
                    model = model.OrderByDescending(m => m.NumberOfApplicants);
                    break;
                case "Date":
                    model = model.OrderBy(m => m.DatePosted);
                    break;
                case "date_desc":
                    model = model.OrderByDescending(m => m.DatePosted);
                    break;
                default:  // Name ascending 
                    model = model.OrderByDescending(m => m.DatePosted);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (p ?? 1);
            var mod = new JobListVM
            {
                Jobs = model.ToPagedList(pageNumber, pageSize),
                JobSearchViewModel = jsmodel
            };


            int jobStartNum = GetJobStart(pageNumber, pageSize);
            int jobEndNum = GetJobEnd(model.Count(), pageNumber, pageSize, jobStartNum);
            ViewBag.StartIndex = jobStartNum;
            ViewBag.EndIndex = jobEndNum;
            ViewBag.ModelCount = model.Count();

            ViewBag.JobCatId = uow.jobCategoryRepository.GetAll().AsEnumerable()
                .Select(j => new SelectListItem { Text = j.Name, Value = Convert.ToString(j.Jobs.Count()) });
            ViewBag.State = CountryStates.GetStates("Nigeria");
            ViewBag.Companies = uow.companyRepository.GetAll().Select(c => c.Name);
            ViewBag.JobType = Enum.GetValues(typeof(JobType));
            ViewBag.ExperienceLevel = Enum.GetValues(typeof(ExperienceLevel));
            return View(mod);
        }

        #region out
        //private Dictionary<string, object> JobModelToDict(JobSearchModel jsmodel)
        //{
        //    Dictionary<string, object> result = new Dictionary<string, object>();
        //    foreach (PropertyInfo property in typeof(JobSearchModel).GetProperties())
        //    {
        //        var val = property.GetValue(jsmodel);
        //        if (val == null || String.IsNullOrEmpty(val.ToString()))
        //            continue;
        //        result.Add(property.Name, val);
        //    }
        //    return result;
        //}
        #endregion
        private Dictionary<string, object> JobModelToDict(JobSearchViewModel jsmodel)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            foreach (PropertyInfo property in typeof(JobSearchViewModel).GetProperties())
            {
                var val = property.GetValue(jsmodel);
                if (val == null || String.IsNullOrEmpty(val.ToString()))
                    continue;
                result.Add(property.Name, val);
            }
            return result;
        }

        private int GetJobStart(int pageNumber, int pageSize)
        {
            return ((pageNumber - 1) * pageSize) + 1;
        }

        private int GetJobEnd(int T, int pageNumber, int pageSize, int startIndex)
        {
            if (T >= pageNumber*pageSize)
            {
                return pageNumber * pageSize;
            }
            else
            {
                return startIndex + (T - startIndex);
            }
        }

    
        [Authorize(Roles = "Company")]
        public ActionResult Post()
        {
            ViewBag.JobCatId = uow.jobCategoryRepository.GetAll().AsEnumerable()
                .Select(j => new SelectListItem { Text = j.Name, Value = j.ID.ToString() });
            ViewBag.JobType = new SelectList(Enum.GetValues(typeof(JobType)));           
            ViewBag.State = CountryStates.GetStates("Nigeria");
            ViewBag.ExperienceLevel = new SelectList(Enum.GetValues(typeof(ExperienceLevel)));
            return View();
        }

        [Authorize(Roles ="Company")]
        [HttpPost]
        public ActionResult Post(PostJobViewModel model, string JobCatId)
        {
            if (ModelState.IsValid)
            {
                string userId = User.Identity.GetUserId();
                if (userManager.Users.FirstOrDefault(x => x.Id == userId).IsCompanyUser)
                {
                    try
                    {
                        ViewBag.JobCatId = uow.jobCategoryRepository.GetAll().AsEnumerable()
                        .Select(j => new SelectListItem { Text = j.Name, Value = j.ID.ToString() });
                        ViewBag.JobType = new SelectList(Enum.GetValues(typeof(JobType)));
                        ViewBag.State = CountryStates.GetStates("Nigeria");
                        ViewBag.ExperienceLevel = new SelectList(Enum.GetValues(typeof(ExperienceLevel)));


                        Job job = new Job
                        {
                            Title = model.Title,
                            State = model.State,
                            Country = "Nigeria",
                            Description = model.Description,
                            RequiredSkills = model.RequiredSkills,
                            Responsibilities = model.Responsibilities,
                            Type = model.JobType,
                            ExperienceLevel = model.ExperienceLevel,
                            IsSalaryNegotiable = model.IsSalaryNegotiable,
                            MinimumSalary = model.MinimumSalary,
                            MaximumSalary = model.MaximumSalary,
                            ApplicationDeadline = model.ApplicationDeadline,
                            DatePosted = DateTime.Now,
                            JobCategoryId = long.Parse(JobCatId),
                            CompanyId = uow.companyRepository.GetCompanyByUserId(userId).ID,
                        };
                        jobService.PostJob(job);
                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        FileLogger.LogError(ex);
                        return View(model);
                    }
                }
                else
                {
                    throw new ApplicationException("Sorry, only company accounts are priviledged to create a job posting. Kinly confirm your logged-in user account.");
                }
            }
            ViewBag.ErrorMsg = "One or more fields have incorrect data";
            return View();
        }
        //
        [AllowAnonymous]
        // GET: Job/Details/5
        public ActionResult Details(long id, string am="")
        {
            ViewBag.JobCatId = uow.jobCategoryRepository.GetAll().AsEnumerable()
                .Select(j => new SelectListItem { Text = j.Name, Value = Convert.ToString(j.ID) });
            ViewBag.State = CountryStates.GetStates("Nigeria");
            Job job = null;
            bool hasUserApplied = false;


            ViewBag.ApplyMsg = jobApplicationService.GetMessage(am);

            ViewBag.NoPitchSubmitted = false;

            var user = userManager.FindById(User.Identity.GetUserId());
            if (user == null)
            {
                ViewBag.HasUserApplied = false;
                ViewBag.IsBookmarked = false;
            }
            else
            {
                job = uow.jobRepository.Get(id);

                hasUserApplied = user.jobApplications.Any(j => j.job.ID == id);
                ViewBag.HasUserApplied = hasUserApplied;
                ViewBag.IsBookmarked = user.FavouriteJobs.Any(j => j.ID == id);

                if (hasUserApplied)
                {
                    var jobApp = uow.jobApplicationRepository.Find(j => j.job.ID == id).FirstOrDefault();
                    if (String.IsNullOrEmpty(jobApp.pitchLocation))
                        ViewBag.NoPitchSubmitted = true;
                }
            }
            ViewBag.IsJobFilled = job.JobStatus == JobStatus.Filled;
            ViewBag.IsApplicationClosed = job.JobStatus == JobStatus.Closed;

            if (ViewBag.IsApplicationClosed && !hasUserApplied)
            {
                ViewBag.ApplyMsg = jobApplicationService.GetMessage("jc");
            }
            else if (ViewBag.IsJobFilled && !hasUserApplied)
            {
                ViewBag.ApplyMsg = jobApplicationService.GetMessage("jf");
            }

            return View(job);
        }
        
       public ActionResult Apply(long id)
        {
            try
            {
                string JobStatusMsg = string.Empty;
                var job = uow.jobRepository.Get(id);
                var user = userManager.FindById(User.Identity.GetUserId());
                if (user.jobApplications.Any(j => j.job.ID == job.ID))
                {
                    JobStatusMsg = "aa";                    
                }
                else if (job.JobStatus == JobStatus.Closed)
                {
                    JobStatusMsg = "jc";
                }
                else if (job.JobStatus == JobStatus.Filled)
                {
                    JobStatusMsg = "jf";
                }
                else
                {
                    JobApplication jobApp = new JobApplication
                    {
                        user = user,
                        job = job,
                        applicationStatus = ApplicationStatus.PendingSubmission,
                        Subscribed = false,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now
                    };
                    jobApplicationService.PostJobApplication(jobApp);
                    JobStatusMsg = "sa";

                }
                return RedirectToAction("Details", new { id = id, am = JobStatusMsg });
            }
            catch (Exception ex)
            {
                ViewBag.JobStatusMsg = "An error occured while processing your request, please try again";
                FileLogger.LogError(ex);
            }
            //return View();
            return RedirectToAction("Details", new { id = id, applyMsg = ViewBag.JobStatusMsg });
        }


        [Authorize(Roles = "User")]
        public ActionResult BookMark(long jobId)
        {
            try
            {
                var job = uow.jobRepository.Get(jobId);
                var user = userManager.FindById(User.Identity.GetUserId());
                if (user.FavouriteJobs.Any(j => j.ID == jobId))
                {
                    ViewBag.JobStatusMsg = "ab";
                }
                else
                {
                    user.FavouriteJobs.Add(job);
                    userManager.Update(user);
                    ViewBag.JobStatusMsg = "sb";
                }
            }
            catch (Exception ex)
            {
                ViewBag.JobStatusMsg = "er";
                FileLogger.LogError(ex);
            }
            //return View();
            return RedirectToAction("Details", new { id = jobId, am = ViewBag.JobStatusMsg });
        }

        [Authorize(Roles = "Company")]
        // GET: Job/Edit/5
        public ActionResult Edit(int id)
        {
            var job = uow.jobRepository.Get(id);
            PostJobViewModel model = new PostJobViewModel
            {
                Id =job.ID,
                ApplicationDeadline = job.ApplicationDeadline,
                Country = job.Country,
                Description = job.Description,
                ExperienceLevel = job.ExperienceLevel,
                IsSalaryNegotiable = job.IsSalaryNegotiable,
                JobType = job.Type,
                MaximumSalary = job.MaximumSalary,
                MinimumSalary = job.MinimumSalary,
                RequiredSkills = job.RequiredSkills,
                Responsibilities = job.Responsibilities,
                State = job.State,
                Title = job.Title
            };

            //ViewBag.JobCatId = jobCatRepo.GetAll().AsEnumerable().Select(j => new SelectListItem { Text = j.Name, Value = Convert.ToString(j.ID) });
            ViewBag.JobCatId = new SelectList(uow.jobCategoryRepository.GetAll(), "ID", "Name", job.JobCategory.ID);
            ViewBag.Type = new SelectList(Enum.GetValues(typeof(JobType)), job.Type);
            ViewBag.State = new SelectList(CountryStates.GetStates("Nigeria"), "Value", "Text", job.State);
            ViewBag.ExperienceLevel = new SelectList(Enum.GetValues(typeof(ExperienceLevel)), job.ExperienceLevel);
            return View(model);
        }

        [Authorize(Roles = "Company")]
        // POST: Job/Edit/5
        [HttpPost]
        public ActionResult Edit(PostJobViewModel model, string JobCatId)
        {
            try
            {
                string userId = User.Identity.GetUserId();
                var job = uow.jobRepository.Get(model.Id);
                job.Title = model.Title;
                job.State = model.State;
                job.Country = "Nigeria";
                job.Description = model.Description;
                job.RequiredSkills = model.RequiredSkills;
                job.Responsibilities = model.Responsibilities;
                job.Type = model.JobType;
                job.ExperienceLevel = model.ExperienceLevel;
                job.IsSalaryNegotiable = model.IsSalaryNegotiable;
                job.MinimumSalary = model.MinimumSalary;
                job.MaximumSalary = model.MaximumSalary;
                job.ApplicationDeadline = model.ApplicationDeadline;
                job.DatePosted = DateTime.Now;

                job.JobCategory = uow.jobCategoryRepository.Get(long.Parse(JobCatId));
                job.Company = uow.companyRepository.GetCompanyByUserId(userId);

                uow.jobRepository.Update(job);
                uow.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Job/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Job/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Company")]
        public ActionResult JobApplicants(long jobId)
        {
            ViewBag.JobId = jobId;
            var job = uow.jobRepository.Get(jobId);
            ViewBag.JobTitle = job.Title;
            //var applicants = uow.jobApplicationRepository.GetApplicants(jobId);

            //get jobapps with the jobId
            var theJobApps = new List<JobApplication>();
            if (uow.jobApplicationRepository.GetAll().Any(j => j.job.ID == jobId))
            {
                theJobApps = uow.jobApplicationRepository.Find(j => j.job.ID == jobId && j.user.IsCompanyUser == false).ToList();
            }
            
            return View(theJobApps);
        }
        public ActionResult ChangeStatus(long jobId, int status)
        {
            jobService.ChangeStatus(jobId, status);
            return RedirectToAction("CompanyProfile", "Profile");
        }

        [Authorize(Roles = "User")]
        public ActionResult RecordPitch(long jobId)
        {
            ViewBag.JobId = jobId;
            //if user has not applied, apply and get the appId. if pitch is already submitted, go back to details

            //save the job
            string JobStatusMsg = string.Empty;
            var job = uow.jobRepository.Get(jobId);
            var user = userManager.FindById(User.Identity.GetUserId());

            long jobApplicationId = 0;
            if (!user.jobApplications.Any(j => j.job.ID == job.ID))
            {
                JobApplication jobApp = new JobApplication
                {
                    user = user,
                    job = job,
                    applicationStatus = ApplicationStatus.PendingSubmission,
                    Subscribed = false,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                };
                jobApplicationService.PostJobApplication(jobApp);
                jobApplicationId = jobApp.ID;
            }
            else
            {
                var jobApp = user.jobApplications.Where(j => j.job.ID == job.ID).First();
                jobApplicationId = jobApp.ID;
                if (!String.IsNullOrEmpty(jobApp.pitchLocation))
                {
                    //pitch already submitted
                    JobStatusMsg = "aa";
                    return RedirectToAction("Details", new { id = jobId, am = JobStatusMsg });
                }
            }

            ViewBag.JobApplicationId = jobApplicationId;
            ViewBag.Username = user.UserName;

            ViewBag.SubscriptionType = new SelectList(Enum.GetValues(typeof(SubscriptionType)));
            var model = new Subscription();
            return View(model);
         
        }

        #region takeout
        /*
        [HttpPost]
        public ActionResult RecordPitch(FormCollection fc)
        {
            var user = userManager.FindById(User.Identity.GetUserId());
            if (user == null)
            {
                ViewBag.errorMessage = "You must be logged in";
                return View("Error");
            }
            if (jobSubService.CheckSingleSubscriptionStatus(user))
            {
                var singleSub = uow.jobSubscriptionRepository.GetActiveSingleSubscription(user.Id);
                if (singleSub == null)
                {
                    ViewBag.errorMessage = "Unable to retrieve your subscription";
                    return View("Error");
                }
                return View();
            }
            if (jobSubService.CheckPeriodicSubscriptionStatus(user))
            {
                var periodicSub = uow.jobSubscriptionRepository.GetActivePeriodicSubscription(user.Id);
                if (periodicSub == null)
                {
                    ViewBag.errorMessage = "Unable to retrieve your subscription";
                    return View("Error");
                }
                return View();                
            }
            //if we get this far, there's no active subscription
            return RedirectToAction("Create", "JobSubscriptions", new { returnUrl = "" });            
        }
        */
        #endregion

        [HttpPost]
        public JsonResult SubmitPitch(FormCollection fc, long jobId)  //to be scraped
        {

            //check if the user has an active periodic sub, if yes, create the job app with the pitch URL

            //if no sub,redirect to createSub in sub Controller passing the pitchurl and jobAppId. save the job with the sub

            var user = userManager.FindById(User.Identity.GetUserId());
            if (user == null)
            {
                return Json(new { msg = "You must be logged in" });
            }
            if (jobSubService.CheckSingleSubscriptionStatus(user))
            {
                var singleSub = uow.jobSubscriptionRepository.GetActiveSingleSubscription(user.Id);
                if (singleSub == null)
                {
                    return Json(new { msg = "Unable to retrieve your subscription" });
                }


                //save the pitch and get the location
                string pitchUrl = "";
                //submit jobApp here 
                var job = uow.jobRepository.Get(jobId);
                JobApplication jobApp = new JobApplication
                {
                    user = user,
                    job = job,
                    applicationStatus = ApplicationStatus.PendingSubmission,
                    Subscribed = true,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    pitchLocation = pitchUrl,
                    //SubscriptionId = singleSub.ID
                };

                
                jobApplicationService.PostJobApplication(jobApp);
                return Json(new {subStatus = "1", msg = "Job submitted!" });   
                
                             
            }
            if (jobSubService.CheckPeriodicSubscriptionStatus(user))
            {
                var periodicSub = uow.jobSubscriptionRepository.GetActivePeriodicSubscription(user.Id);
                if (periodicSub == null)
                    return Json(new { msg = "Unable to retrieve your subscription" });


                //save the pitch and get the location
                string pitchUrl = "";
                //submit jobApp here 
                var job = uow.jobRepository.Get(jobId);
                JobApplication jobApp = new JobApplication
                {
                    user = user,
                    job = job,
                    applicationStatus = ApplicationStatus.PendingSubmission,
                    Subscribed = true,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    pitchLocation = pitchUrl,
                    //SubscriptionId = singleSub.ID
                };

                jobApplicationService.PostJobApplication(jobApp);
                return Json(new { subStatus = "1", msg = "Job submitted!" });



            }
            //if we get this far, there's no active subscription
            return Json(new { subStatus = "0", msg = "No active subscription" });
            //return RedirectToAction("Create", "JobSubscriptions", new { returnUrl = "" });
        }

       
        public ActionResult PitchmMe()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult PostRecordedAudioVideo()
        {
            if (Request.Files.Count < 1)
                return RedirectToAction("RecordPitch");

            var path = AppDomain.CurrentDomain.BaseDirectory + "uploads/";
            string fullFileName = Path.Combine(path, Request.Form[0]);
            foreach (string upload in Request.Files)
            {                
                var file = Request.Files[upload];
                if (file == null) continue;

                file.SaveAs(fullFileName);
                break;
            }
            var fileName = Request.Form[0];
            
            var user = userManager.FindById(User.Identity.GetUserId());
            if (jobSubService.CheckPeriodicSubscriptionStatus(user))
            {
                long jobAppId = Int64.Parse(fileName.Split('_')[0]);
                var jobApplication = uow.jobApplicationRepository.Get(jobAppId);
                if(jobApplication == null)
                    return Json(new { status = -1, msg = "An error has occured" });
                jobApplication.pitchLocation = fullFileName;
                uow.jobApplicationRepository.Update(jobApplication);
                return Json(new {status = 1, msg = "You have successfully applied to this job" });
            }
            
            return Json(new { status = 0, msg = "Your job application has been saved but you need to subscribe to get your video submitted" });
        }

        #region out
        //public ActionResult UploadTempVideo()
        //{
        //    if (Request.Files.Count < 1)
        //        return RedirectToAction("RecordPitch");

        //    var path = AppDomain.CurrentDomain.BaseDirectory + "tempPitchVids/";
        //    string fullFileName = Path.Combine(path, Request.Form[0]);
        //    foreach (string upload in Request.Files)
        //    {
        //        var file = Request.Files[upload];
        //        if (file == null) continue;

        //        file.SaveAs(fullFileName);
        //        break;
        //    }
        //    var fileName = Request.Form[0];
        //    return Json(fileName);
        //}
        #endregion

        // ---/RecordRTC/DeleteFile
        [HttpPost]
        public ActionResult DeleteFile()
        {
            var fileUrl = AppDomain.CurrentDomain.BaseDirectory + "uploads/" + Request.Form["delete-file"] + ".webm";
            new FileInfo(fileUrl).Delete();
            return Json(true);
        }


        [Authorize(Roles = "Company")]
        public ActionResult WatchPitch(string f)
        {
            ViewBag.FileName = f;
            try
            {
                long jobAppId = Int64.Parse(f.Split('_')[0]);
                var jobApp = uow.jobApplicationRepository.Get(jobAppId);
                ViewBag.FullName = jobApp.user.Resume?.FullName;
                ViewBag.JobTitle = jobApp.job.Title;
            }
            catch (Exception ex)
            {

                throw;
            }
            return View();
        }
    }
}

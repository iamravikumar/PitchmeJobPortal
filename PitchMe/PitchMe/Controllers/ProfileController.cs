using PitchMe.Data.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;
using Pitchme.Models.Implementation;
using PitchMe.Models;
using System.IO;
using PitchMe.Models.Implementation;
using Newtonsoft.Json;
using PitchMe.Services.Contract;
using PitchMe.Models.ViewModels;
using System.Threading.Tasks;
using PitchMe.App_Start;
using System.Collections;
using PitchMe.Utilities;

namespace PitchMe.Controllers
{
    [Authorize]
    [UsageLoggingFilterAttribute]
    public class ProfileController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;
        IUnitOfWork uow;
        private IResumeService resumeService;
        private IUtilityService utilityService;
        public ProfileController(IUnitOfWork _uow,  ApplicationUserManager userManager, ApplicationSignInManager signInManager, IResumeService _resumeService, IUtilityService _utilityService)
        {
            _userManager = userManager;
            uow = _uow;
            resumeService = _resumeService;
            utilityService = _utilityService;
        }
        // GET: Profile
        public ActionResult Index()
        {

            var userId = User.Identity.GetUserId();
            var user = _userManager.FindById(userId);
            ViewBag.UserName = user.UserName;
            ViewBag.NoOfAppliedJobs = user.jobApplications.Count();
            ViewBag.NoOfFavourites = user.FavouriteJobs.Count();
            ViewBag.PhoneNumber = user.PhoneNumber;
            ViewBag.Email = user.Email;
            if (user.IsCompanyUser)
            {
                return RedirectToAction("CompanyProfile", new { id = userId });
            }
            var resume = user.Resume ?? null;
            return View(resume); 
        }

        [Authorize(Roles = "Company")]
        public ActionResult Details(string uid)
        {
            var user = _userManager.FindById(uid);
            var resume = user.Resume;
            ViewBag.PhoneNumber = user.PhoneNumber;
            ViewBag.Email = user.Email;
     
            return View(resume);
        }

        [Authorize(Roles ="Company")]
        public ActionResult CompanyProfile(string id)
        {
            var user = _userManager.FindById(User.Identity.GetUserId());
            var theCompany = uow.companyRepository.GetCompanyByUserId(user.Id);
            DateTime MostRecentDay = DateTime.Now.AddDays(-7);
            ViewBag.RecentApplications = uow.jobApplicationRepository.Find(j => j.job.CompanyId == theCompany.ID && j.DateCreated >= MostRecentDay).Count();
            return View(theCompany);
        }
        public ActionResult AppliedJobs()
        {
            var userId = User.Identity.GetUserId();
            var user = _userManager.FindById(userId);
            ViewBag.UserName = user.UserName;
            ViewBag.ProfileImgUri = user.Resume.ProfileImageUri;

            var model = user.jobApplications;
            if (model == null)
            {
                ViewBag.NoOfAppliedJobs = 0;
                return View(new List<Job>());
            }
            ViewBag.NoOfAppliedJobs = model.Count();
            ViewBag.NoOfFavourites = user.FavouriteJobs.Count();
            return View(model.Select(a => a.job).ToList());
        }

        public ActionResult Favourites()
        {
            var userId = User.Identity.GetUserId();
            var user = _userManager.FindById(userId);
            ViewBag.UserName = user.UserName;
            ViewBag.ProfileImgUri = user.Resume?.ProfileImageUri;
            ViewBag.NoOfAppliedJobs = user.jobApplications.Any() ? user.jobApplications.Count() : 0;

            var model = user.FavouriteJobs;
            if (model == null)
            {
                ViewBag.NoOfFavourites = 0;
                return View(new List<Job>());
            }
            ViewBag.NoOfFavourites = model.Count();
            return View(model);
        }

        public ActionResult EditResume()
        {
            
            var user = _userManager.FindById(User.Identity.GetUserId());
            var resume = user.Resume;
            ViewBag.ProfileImgUri = user.Resume == null ? "~/assets/images/Passports_2_4aface08-fa52-45f2-9121-9d73d934cacb.jpg" : user.Resume.ProfileImageUri;
            ViewBag.UserName = user.UserName;
            ViewBag.NoOfAppliedJobs = user.jobApplications.Any() ? user.jobApplications.Count() : 0;
            ViewBag.NoOfFavourites = user.FavouriteJobs.Count();

            if (resume == null)
            {
                return View(new EditResumeViewModel());
            }

            EditResumeViewModel model = new EditResumeViewModel
            {
                FullName = resume.FullName,
                AdditionalInformation = resume.AdditionalInformation,
                Address = resume.Address,
                CareerObjective = resume.CareerObjective,
                DateOfBirth = resume.DateOfBirth,
                Declaration = resume.Declaration,
                FatherName = resume.FatherName,
                Gender = resume.Gender,
                MotherName = resume.MotherName,
                Nationality = resume.Nationality,
                PlaceOfBirth = resume.PlaceOfBirth,
                ProfileImageUri = resume.ProfileImageUri,
                SkillsAndQualifications = resume.SkillsAndQualifications,
                EducationBackgrounds = resume.EducationBackgrounds.Any() ? resume.EducationBackgrounds : new List<EducationBackground>() { new EducationBackground() },
                WorkExperiences = resume.WorkExperiences.Any() ? resume.WorkExperiences : new List<WorkExperience>() { new WorkExperience() },
                Languages = resume.Languages.Any() ? resume.Languages : new List<Language>() { new Language() }
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult EditResume(EditResumeViewModel model, FormCollection fc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _userManager.FindById(User.Identity.GetUserId());
                    var theResume = user.Resume;

                    if (theResume == null)
                    {
                        theResume = resumeService.SaveNewResume(user, model);
                    }
                    else    //update the existing resume
                    {
                        string previuosImgPath = user.Resume.ProfileImageUri;
                        resumeService.UpdateExistingResume(theResume, model);
                        if (System.IO.File.Exists(Server.MapPath(previuosImgPath)))
                        {
                            System.IO.File.Delete(Server.MapPath(previuosImgPath));
                        }
                        
                    }

                    uow.Save();                    
                    return Json(new { status = "success", msg = "Successfully updated" });
                }
            }
            catch (Exception ex)
            {
                FileLogger.LogError(ex);
                return Json(new { status = "error", msg = "an error occured" });
            }
       
            return Json(new { status = "error", msg = "Please enter correct data" });
        }

        [HttpPost]
        public JsonResult SaveImageToFolder(HttpPostedFileBase file)
        {
            if ((file == null || file.ContentLength < 1))
            {
                return Json(new { status = "error", msg = "" });
            }


            var result = utilityService.SaveImageToFolder(file, Server.MapPath("~/assets/images/UserProfileImages"), "~/assets/images/UserProfileImages/user.jpg");
            return Json(new { status = result["status"], msg = result["msg"] });        //return Json(result) jeje

        }

        [HttpPost]
        public JsonResult UpdateCompanyProfileImage(HttpPostedFileBase file, long cc)
        {
            if ((file == null || file.ContentLength < 1))
            {
                return Json(new { status = "error", msg = "" });
            }
            var result = utilityService.SaveImageToFolder(file, Server.MapPath("~/assets/images/UserProfileImages"), "~/assets/images/UserProfileImages/user.jpg");
            if (!(String.Compare(result[AppConstants.STATUS], AppConstants.SUCCESS) == 0))
                return Json(result);
            Company company = uow.companyRepository.Get(cc);

            string previuosImgPath = company.ProfileImageUri;
            if (System.IO.File.Exists(Server.MapPath(previuosImgPath)))
            {
                System.IO.File.Delete(Server.MapPath(previuosImgPath));
            }

            company.ProfileImageUri = result["msg"];
            company.DateModified = DateTime.Now;
            uow.companyRepository.Update(company);
            uow.Save();
            return Json(new { status = AppConstants.SUCCESS, msg = "image updated" });
        }

        public async Task<ActionResult> Manage()
        {
            var user = await _userManager.FindByIdAsync(User.Identity.GetUserId());
            ManageProfileViewModel model = new ManageProfileViewModel
            {
                Email = user.Email,
                UserName = user.UserName,
                Phone = user.PhoneNumber
            };
            ViewBag.UserName = user.UserName;
            ViewBag.ProfileImgUri = user.Resume?.ProfileImageUri;
            ViewBag.NoOfAppliedJobs = user.jobApplications.Count();
            ViewBag.NoOfFavourites = user.FavouriteJobs.Count();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Manage(ManageProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var user = await _userManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    user.UserName = model.UserName;
                    user.PhoneNumber = model.Phone;
                    uow.userRepository.Update(user);
                    uow.Save();

                    var result = await _userManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                FileLogger.LogError(ex);
                return View(model);
            }
                       
            return View(model);
        }
    }
}
using PitchMe.App_Start;
using PitchMe.Data.Repository.Contract;
using PitchMe.Models;
using PitchMe.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PitchMe.Controllers
{    
    [UsageLoggingFilterAttribute]
    public class HomeController : Controller
    {
        private IUnitOfWork uow;
        public HomeController(IUnitOfWork _uow)
        {
            uow = _uow;
        }
        public ActionResult Index()
        {
            var model = new HomePageJobsViewModel()
            {
                AllJobs = uow.jobRepository.GetAll().ToList(),
                HotJobs = uow.jobRepository.GetAll().OrderByDescending(j => j.DatePosted).ToList(),
                PopularJobs = uow.jobRepository.GetAll().OrderBy(j => j.NumberOfApplicants).ToList()
            };
            ViewBag.TotalJobs = uow.jobRepository.GetAll().Count();
            ViewBag.TotalCompanies = uow.companyRepository.GetAll().Count();
            ViewBag.TotalJobCandidates = uow.userRepository.Find(u => u.IsCompanyUser == false).Count();

            ViewBag.State = CountryStates.GetStates("Nigeria");

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using PitchMe.Services.Contract;
using Pitchme.Models.Implementation;
using PitchMe.Data.Repository.Implementation;
using System.Linq.Expressions;
using System.Linq;
using Pitchme.Models.Enums;
using PitchMe.Utilities;
using PitchMe.Data.Repository.Contract;

namespace PitchMe.Services.Implementation
{
    public class JobService : IJobService
    {
        private IJobRepository _jobRepository; //Get instance from container 
        private IUnitOfWork uow;
        public JobService(IUnitOfWork _uow, IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
            uow = _uow;
        }

        /// <summary>
        /// Adds a new job record
        /// </summary>
        /// <param name="job"></param>
        public void PostJob(Job job)
        {
            uow.jobRepository.Add(job);
            uow.Save();
        }

        /// <summary>
        /// Searches for jobs using the dictionary filters
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public IEnumerable<Job> FindJob(Dictionary<string, object> dict)
        {
            Expression<Func<Job, bool>> predicate = PredicateBuilder.True<Job>();

            if (dict.Keys.Contains("Company"))
            {
                string company = dict["Company"].ToString();
                if (!String.IsNullOrEmpty(company))
                {
                    predicate = predicate.And(x => String.Compare(x.Company.Name, company, true) == 0);
                }
                
            }
            if (dict.Keys.Contains("State"))
            {
                string state = dict["State"].ToString();
                if (!String.IsNullOrEmpty(state))
                {
                    predicate = predicate.And(x => String.Compare(x.State, state, true) == 0);
                }
                
            }
            if (dict.Keys.Contains("SearchString"))
            {
                string searchStr = dict["SearchString"].ToString();
                if (!String.IsNullOrEmpty(searchStr))
                {
                    predicate = predicate.And(x => x.Title.ToLower().Contains(searchStr.ToLower()) || x.JobCategory.Name.ToLower().Contains(searchStr.ToString().ToLower()));
                }
                
            }
            if (dict.Keys.Contains("Category"))
            {
                string category = dict["Category"].ToString();
                if (!String.IsNullOrEmpty(category))
                {
                    predicate = predicate.And(x => String.Compare(x.JobCategory.Name, category, true) == 0);
                }
               
            }
            if (dict.Keys.Contains("DateRange"))
            {
                string dateRange = dict["DateRange"].ToString();
                if (!String.IsNullOrEmpty(dateRange))
                {
                    DateTime oldestDate = DateTime.Now.Subtract(new TimeSpan(60, 0, 0, 0, 0));
                    switch (dateRange)
                    {
                        case "Today":
                            oldestDate = DateTime.Now.Subtract(new TimeSpan(0, 0, 0, 0, 0));
                            break;
                        case "7 days":
                            oldestDate = DateTime.Now.Subtract(new TimeSpan(6, 0, 0, 0, 0));
                            break;
                        case "30 days":
                            oldestDate = DateTime.Now.Subtract(new TimeSpan(29, 0, 0, 0, 0));
                            break;
                        default:
                            break;
                    }
                    predicate = predicate.And(x => x.DatePosted >= oldestDate);

                }
            }

            if (dict.Keys.Contains("MinimumSalary"))
            {
                decimal minSal = Convert.ToDecimal(dict["MinimumSalary"]);
                if (minSal > 0)
                {
                    predicate = predicate.And(x => x.MinimumSalary >= minSal);
                }
            }
            if (dict.Keys.Contains("MaximumSalary"))
            {
                decimal maxSal = Convert.ToDecimal(dict["MaximumSalary"]);
                if (maxSal > 0)
                {
                    predicate = predicate.And(x => x.MaximumSalary <= maxSal);
                }
            }


            if (dict.Keys.Contains("JobType"))
            {
                var type = Enum.Parse(typeof(JobType), dict["JobType"].ToString());
                predicate = predicate.And(x => x.Type == (JobType)type);
            }
            if (dict.Keys.Contains("ExpLevel"))
            {
                var level = Enum.Parse(typeof(ExperienceLevel), dict["ExpLevel"].ToString());
                predicate = predicate.And(x => x.ExperienceLevel == (ExperienceLevel)level);
            }


            return _jobRepository.Find(predicate);
        }
        public void ChangeStatus(long jobId, int status)
        {
            var job = uow.jobRepository.Get(jobId);
            job.JobStatus = (JobStatus)Enum.Parse(typeof(JobStatus), status.ToString());
            uow.Save();
        }
    }
}

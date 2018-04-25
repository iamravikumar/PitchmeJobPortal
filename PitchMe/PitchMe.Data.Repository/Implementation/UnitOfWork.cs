using PitchMe.Data.Implementation;
using PitchMe.Data.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchMe.Data.Repository.Implementation
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private System.Data.Entity.DbContext context;// = new DbContext();

        //ICompanyRepository gcompanyRepository;   
        public UnitOfWork(System.Data.Entity.DbContext _context, ICompanyRepository _companyRepository, 
            IJobCategoryRepository _jobCategoryRepository, IJobRepository _jobRepository, 
            IJobApplicationRepository _jobApplicationRepository, IWorkExperienceRepository _workExperienceRepository, 
            IEducationBackgroundRepository _educationBackgroundRepository, IResumeRepository _resumeRepository, 
            IUserRepository _userRepository, IJobSubscriptionRepository _jobSubRepo, ILanguageRepository _languageRepo)
        {
            companyRepository = _companyRepository;
            jobCategoryRepository = _jobCategoryRepository;
            jobRepository = _jobRepository;
            jobApplicationRepository = _jobApplicationRepository;
            workExperienceRepository = _workExperienceRepository;
            educationBackgroundRepository = _educationBackgroundRepository;
            resumeRepository = _resumeRepository;
            userRepository = _userRepository;
            jobSubscriptionRepository = _jobSubRepo;
            languageRepository = _languageRepo;

            context = _context;
        }

      

       public ICompanyRepository companyRepository
        {
            get;
            set;
        }

        public IJobRepository jobRepository
        {
            get;
            set;
        }

        public IJobCategoryRepository jobCategoryRepository
        {
            get;
            set;
        }
        public IJobApplicationRepository jobApplicationRepository { get; set; }
        public IWorkExperienceRepository workExperienceRepository { get; set; }
        public IEducationBackgroundRepository educationBackgroundRepository { get; set; }
        public IResumeRepository resumeRepository { get; set; }
        public IUserRepository userRepository { get; set; }
        public IJobSubscriptionRepository jobSubscriptionRepository { get; set; }
        public ILanguageRepository languageRepository { get; set; }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

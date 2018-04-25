using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using PitchMe.Data.Repository.Implementation;
using PitchMe.Data.Repository.Contract;
using PitchMe.Services.Implementation;
using PitchMe.Services.Contract;
using SimpleInjector.Integration.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using PitchMe.Models;
using Pitchme.Models.Implementation;

namespace PitchMe
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            var container = new Container();

            
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            container.Register<System.Data.Entity.DbContext>(() => new ApplicationDbContext(), Lifestyle.Scoped);

            container.Register<IUserStore<User>, MyUserStore>(Lifestyle.Scoped);
            container.Register <UserManager<User>, ApplicationUserManager>(Lifestyle.Scoped);

            container.Register<IAuthenticationManagerFactory, AuthenticationManagerFactory>();
            container.Register<IAuthenticationManager>(
                    () => HttpContext.Current.GetOwinContext().Authentication);



            //Registering Repository Interfaces
            container.Register<ICompanyRepository, CompanyRepository>(Lifestyle.Scoped);
            container.Register<IJobApplicationRepository, JobApplicationRepository>(Lifestyle.Scoped);
            container.Register<IJobRepository, JobRepository>(Lifestyle.Scoped);
            container.Register<IJobSubscriptionRepository, JobSubscriptionRepository>(Lifestyle.Scoped);
            container.Register<IJobCategoryRepository, JobCategoryRepository>(Lifestyle.Scoped); 
            container.Register<IWorkExperienceRepository, WorkExperienceRepository>(Lifestyle.Scoped);
            container.Register<IEducationBackgroundRepository, EducationBackgroundRepository>(Lifestyle.Scoped);
            container.Register<IUserRepository, UserRepository>(Lifestyle.Scoped);
            container.Register<IResumeRepository, ResumeRepository>(Lifestyle.Scoped);
            container.Register<ILanguageRepository, LanguageRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            

            //Registering Service Interfaces
            container.Register<IJobApplicationService, JobApplicationService>(Lifestyle.Scoped);
            container.Register<IJobService, JobService>(Lifestyle.Scoped);
            container.Register<IJobSubscriptionService, JobSubscriptionService>(Lifestyle.Scoped);
            container.Register<IResumeService, ResumeService>(Lifestyle.Scoped);
            container.Register<IUtilityService, UtilityService>(Lifestyle.Scoped);


            //container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            

        }
    }
}

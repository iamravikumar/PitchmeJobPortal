using SimpleInjector;
using PitchMe.Data.Repository;
using PitchMe.Data.Repository.Contract;
using PitchMe.Data.Repository.Implementation;
using PitchMe.Services.Contract;
using PitchMe.Services.Implementation;
using System.Linq;
using SimpleInjector.Lifestyles;
using PitchMe.Data.Implementation;
using PitchMe.Data.Contract;

namespace PitchMe.Extension
{
    public class ServiceLocator 
    {
        Container container = new Container();
        public ServiceLocator(string conString)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();


            container.Register<IDbContext>(() => new DbContext(conString), Lifestyle.Scoped);

            //Registering Repository Interfaces
            container.Register<ICompanyRepository, CompanyRepository>(Lifestyle.Scoped);
            container.Register<IJobApplicationRepository, JobApplicationRepository>(Lifestyle.Scoped);
            container.Register<IJobRepository, JobRepository>(Lifestyle.Scoped);
            container.Register<IJobSubscriptionRepository, JobSubscriptionRepository>(Lifestyle.Scoped);

            //Registering Service Interfaces
            container.Register<IJobApplicationService, JobApplicationService>(Lifestyle.Scoped);
            container.Register<IJobService, JobService>(Lifestyle.Scoped);
            container.Register<IJobSubscriptionService, JobSubscriptionService>(Lifestyle.Scoped);

            //string conString = ConfigurationManager.ConnectionStrings["PitchMeDBConnection"].ConnectionString;
            

            container.Verify();
        }

        public Container GetContainer()
        {
            return container;
        }
        
    }
}

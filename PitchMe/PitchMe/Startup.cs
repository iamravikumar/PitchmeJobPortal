using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PitchMe.Startup))]
namespace PitchMe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

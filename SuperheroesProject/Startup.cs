using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuperheroesProject.Startup))]
namespace SuperheroesProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

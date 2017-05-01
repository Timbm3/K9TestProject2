using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(K9TestProject3.Startup))]
namespace K9TestProject3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

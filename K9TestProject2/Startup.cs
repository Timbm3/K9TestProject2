using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(K9TestProject2.Startup))]
namespace K9TestProject2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

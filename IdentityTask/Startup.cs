using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentityTask.Startup))]
namespace IdentityTask
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

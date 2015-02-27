using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MLearning.Web2.Startup))]
namespace MLearning.Web2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

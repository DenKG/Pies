using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExclusiveCakesMVC.Startup))]
namespace ExclusiveCakesMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarLotMVC.Startup))]
namespace CarLotMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

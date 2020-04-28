using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MySportMeal.Startup))]
namespace MySportMeal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

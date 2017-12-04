using Hangfire;
using Microsoft.Owin;
using Owin;

//[assembly: OwinStartupAttribute(typeof(TechCom.App.Startup))]
namespace TechCom.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //GlobalConfiguration.Configuration
            //   .UseSqlServerStorage("ApplicationDbContext");

            //app.UseHangfireDashboard();
            //app.UseHangfireServer();
        }
    }
}

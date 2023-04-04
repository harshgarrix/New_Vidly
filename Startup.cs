using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(New_Vidly.Startup))]
namespace New_Vidly
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Code_First_Jashim.Startup))]
namespace Code_First_Jashim
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

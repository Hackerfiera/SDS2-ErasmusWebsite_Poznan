using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ErasmusSDS.Startup))]
namespace ErasmusSDS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

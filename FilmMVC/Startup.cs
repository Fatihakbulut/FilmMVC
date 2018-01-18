using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FilmMVC.Startup))]
namespace FilmMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

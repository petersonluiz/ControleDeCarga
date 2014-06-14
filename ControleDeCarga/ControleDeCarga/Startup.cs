using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ControleDeCarga.Startup))]
namespace ControleDeCarga
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

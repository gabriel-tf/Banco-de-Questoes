using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BancoDeQuestoes.UI.Startup))]
namespace BancoDeQuestoes.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

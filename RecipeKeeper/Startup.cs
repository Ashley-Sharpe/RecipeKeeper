using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RecipeKeeper.Startup))]
namespace RecipeKeeper
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

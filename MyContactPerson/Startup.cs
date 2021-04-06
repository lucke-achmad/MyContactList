using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyContactPerson.Startup))]
namespace MyContactPerson
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;
using System.Diagnostics.CodeAnalysis;

[assembly: OwinStartupAttribute(typeof(Cinevans.Startup))]
namespace Cinevans
{
    [ExcludeFromCodeCoverage]
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
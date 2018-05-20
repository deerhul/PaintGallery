using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PaintGallery.Startup))]
namespace PaintGallery
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

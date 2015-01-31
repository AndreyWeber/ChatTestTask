using Microsoft.Owin;
using Owin;

[assembly : OwinStartup(typeof(ChatTestTask.Startup))]
namespace ChatTestTask
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
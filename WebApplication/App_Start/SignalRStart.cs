using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication;

[assembly: OwinStartup(typeof(WebApplication.SignalrStart))]

namespace WebApplication
{
    public class SignalrStart
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
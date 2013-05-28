using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using WebCrm.Framework;

namespace WebCrm.Api
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config");

            ApplicationConfig.Intance.Init(o => { },
                                           new Assembly[]
                                               {
                                                   Assembly.Load("WebCrm.Model"), Assembly.Load("WebCrm.Service"),
                                                   Assembly.Load("WebCrm.Dao")
                                               }).Log4net(path);

        }


        void Application_Error(object sender, EventArgs e)
        {

        }
    }
}

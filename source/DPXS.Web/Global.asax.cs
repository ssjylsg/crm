using System;
using System.IO;
using System.Reflection;
using WebCrm.Framework;
using WebCrm.Web.Facade;

namespace WebCrm.Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config");

            ApplicationConfig.Intance.Init(o => { },
                                           new Assembly[]
                                               {
                                                   Assembly.Load("WebCrm.Model"), Assembly.Load("WebCrm.Service"),
                                                   Assembly.Load("WebCrm.Dao")
                                               }).Log4net(path);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            log4net.LogManager.GetLogger(this.GetType()).Error(sender + e.ToString());
            
#if RELEASE
            Server.ClearError();
            string url = AspNetHelper.WebUrl() + "/Error.htm";
            Response.Redirect(url);
            //   Response.Write("程序出现错误，请重新操作");
            Response.End();
#endif
        }
    }
}
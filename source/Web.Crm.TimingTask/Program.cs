using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Autofac;
using WebCrm.Framework;
using WebCrm.Framework.Repositories;

namespace Web.Crm.TimingTask
{
    /// <summary>
    /// 定时发送消息，将此作为Windows 定时任务，设置为 1 分钟启动一次
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SetUp();
            }
            catch (Exception e)
            {
                LogError(string.Format("程序启动异常,{0}", e));
                return;
            }
            try
            {
                var service = DependencyResolver.Resolver<WebCrm.Model.Services.IMessageService>();
                service.AutoSendInfo();
            }
            catch (Exception ex)
            {
                LogError("自动发送消息失败，" + ex);
                return;
            }
            log4net.LogManager.GetLogger(typeof(Program)).Info(string.Format("{0}消息发送成功",
                                                                              System.DateTime.Now.ToShortDateString()));
        }
        private static void LogError(object message)
        {
            Console.WriteLine(message);
            log4net.LogManager.GetLogger(typeof(Program)).Error(message);
        }
        private static void SetUp()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config");

            ApplicationConfig.Intance.Init(o => o.RegisterType<OracleGenerateNewId>().As<IGenerateNewId>(),
                                           new Assembly[]
                                               {
                                                   Assembly.Load("WebCrm.Model"), Assembly.Load("WebCrm.Service"),
                                                   Assembly.Load("WebCrm.Dao"),Assembly.Load("WebCrm.Framework")
                                               }).Log4net(path);
        }
    }
}

using System;
using System.IO;
using Autofac;
using Autofac.Extras.DynamicProxy2;
using Autofac.Integration.Mvc;
using Castle.DynamicProxy;

namespace WebCrm.Framework
{
    public class ApplicationConfig
    {
        private static ApplicationConfig _config;

        static ApplicationConfig()
        {
            _config = new ApplicationConfig();
        }

        public static ApplicationConfig Intance
        {
            get { return _config; }
        }

        private ContainerBuilder _bulider;
        public ApplicationConfig Init(Action<ContainerBuilder> func, params  System.Reflection.Assembly[] assemblies)
        {
            if (this._bulider != null)
            {
                throw new Exception("已经初始化，不能再初始化！");
            }
            _bulider = new ContainerBuilder();

            _bulider.RegisterInstance(this);

            this.RegisterAssebbly(assemblies);

            func(this._bulider);

            _bulider.RegisterType<ServiceInterceptor>().As<IInterceptor>();
            
            DependencyResolver.Container = this._bulider.Build();
            return this;
        }
        public ApplicationConfig Log4net(string filePath)
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo(filePath));
            log4net.LogManager.GetLogger(this.GetType()).Debug("程序启动");
            return this;
        }
        /// <summary>
        /// 注册Controller
        /// </summary>
        /// <param name="assemblies"></param>
        private void RegisterControllers(params  System.Reflection.Assembly[] assemblies)
        { 
            _bulider.RegisterControllers(assemblies);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="assemblies"></param>
        private void RegisterAssebbly(params  System.Reflection.Assembly[] assemblies)
        {
            _bulider.RegisterAssemblyTypes(assemblies).AsImplementedInterfaces().SingleInstance().
                EnableClassInterceptors();
        } 
    }
}

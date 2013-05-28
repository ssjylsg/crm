using System;
using System.Data;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace WebCX.DAL
{
    //SessionFactory (NHibernate.ISessionFactory)对属于单一数据库的编译过的映射文件的一个线程安全的，不可变的缓存快照。
    //它是Session的工厂，是ConnectionProvider的客户。
    public class SessionFactory
    {
        public SessionFactory() { }

        private static ISessionFactory sessions;
        /// NHibernate.Cfg.Configuration的一个实例代表了应用程序中所有的.NET类到SQL数据库的映射的集合。
        /// Configuration用于构造一个(不可变的)ISessionFactory。
        /// 这些映射是从一些XML映射文件中编译得来的。 
        private static Configuration cfg;
        static readonly object padlock = new object();

        /// <summary>
        /// 创建一个数据库链接，并且打开一个ISession
        /// </summary>
        /// <param name="AssemblyName">程序集名称</param>
        /// <returns></returns>
        public static ISession OpenSession(string AssemblyName)
        {
            if (sessions == null)
            {
                lock (padlock)
                {
                    if (sessions == null)
                    {
                        BuildSessionFactory(AssemblyName);
                    }
                }
            }

            return sessions.OpenSession();
        }

        /// <summary>
        /*--------------------------------------------------
                当所有的映射都被Configuration解析之后，
           应用程序为了得到ISession实例，必须先得到它的工厂。
           这个工厂应该是被应用程序的所有线程共享的：
         ---------------------------------------------------*/
        /// </summary>
        /// <param name="AssemblyName"></param>
        private static void BuildSessionFactory(string AssemblyName)
        {
            cfg = new Configuration();
            ////AddAssembly让NHibernate读取一个程序集中所有的配置文件
            //cfg.AddAssembly(AssemblyName);
            ////创建Session的工厂返回ISessionFactory
            //sessions = cfg.BuildSessionFactory();

            sessions = cfg.Configure().BuildSessionFactory();
        }
        //创建数据库
        public static void CreateDataBase(string AssemblyName)
        {
            cfg = new Configuration();
            cfg.AddAssembly(AssemblyName);
            SchemaExport sch = new SchemaExport(cfg);
            sch.Create(true, true);
        }
    }
}

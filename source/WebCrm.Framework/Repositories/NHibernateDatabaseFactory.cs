using System;
using NHibernate;
using NHibernate.Cfg;
using System.Linq;
namespace WebCrm.Framework.Repositories
{
    public class NHibernateDatabaseFactory
    {
        #region 私有静态变量

        private static object m_Locker = new object();
        private static Configuration m_Configuration = null;
        private static ISessionFactory m_SessionFactory = null;
        private static ISessionStorage m_Sessionsource;

        #endregion

        #region 静态构造函数

        static NHibernateDatabaseFactory()
        {
            //m_Sessionsource = SessionStorageFactory.GetSessionStorage();
        }

        #endregion

        #region 内部静态变量
        /// <summary>
        /// 获取表明
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string TableName<T>()
        {
            var model = Configuration.ClassMappings.Where(m => m.EntityName == typeof(T).FullName).FirstOrDefault();
            if (model != null)
            {
                return model.Table.Name;
            }
            return typeof(T).Name;
        }
        public static string TableName(Type type)
        {
            var model = Configuration.ClassMappings.Where(m => m.EntityName == type.FullName).FirstOrDefault();
            if (model != null)
            {
                return model.Table.Name;
            }
            return type.Name;
        }

        /// <summary>
        /// NHibernate配置对象
        /// </summary>
        public static Configuration Configuration
        {
            get
            {
                lock (m_Locker)
                {
                    if (m_Configuration == null)
                    {
                        CreateConfiguration();
                    }
                    return m_Configuration;
                }
            }
            set { m_Configuration = value; }
        }

        /// <summary>
        /// NHibernate的对象工厂
        /// </summary>
        internal static ISessionFactory SessionFactory
        {
            get
            {
                if (null == m_SessionFactory)
                {
                    if (m_Configuration == null)
                    {
                        CreateConfiguration();
                    }
                    lock (m_Locker)
                    {
                        m_SessionFactory = Configuration.BuildSessionFactory();
                    }

                    if (m_SessionFactory != null)
                    {
                        _sessionContext = m_Configuration.GetProperty("current_session_context_class");
                    }
                }

                return m_SessionFactory;
            }
        }

        private static string _sessionContext;
        #endregion

        #region 公共方法

        /// <summary>
        /// 建立ISessionFactory的实例
        /// </summary>
        /// <returns></returns>
        public static ISession GetSession()
        {
            if (!string.IsNullOrEmpty(_sessionContext))
            {
                if (!NHibernate.Context.CurrentSessionContext.HasBind(SessionFactory))
                {
                    NHibernate.Context.CurrentSessionContext.Bind(SessionFactory.OpenSession());
                }
                return SessionFactory.GetCurrentSession();
            }
            return SessionFactory.OpenSession();
        }

        #endregion

        #region 私有方法

        private static void CreateConfiguration()
        {
            m_Configuration = new Configuration();
            m_Configuration.Configure();
        }

        #endregion
    }
}

using NHibernate;
using NHibernate.Cfg;

namespace WebCrm.Framework.Repositories
{

    public class SessionFactory
    {
        private SessionFactory() { }

        private static ISessionFactory _sessions;

        private static Configuration _cfg;
        static readonly object Padlock = new object();

        public static ISession OpenSession()
        {
            _cfg = new Configuration();
            _sessions = _cfg.Configure().BuildSessionFactory();
            return _sessions.OpenSession();
        }
        private static void BuildSessionFactory()
        {
            _cfg = new Configuration();
            _sessions = _cfg.Configure().BuildSessionFactory();
        }
    }
}

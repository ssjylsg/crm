using NHibernate;

namespace WebCrm.Framework.Repositories
{
    internal interface ISessionStorage
    {
        ISession GetSession();
        void SetSession(ISession session);
    }
    internal class SysConfig
    {
        public const string SESSION_NAME = "nhibernate.current_session";
    }

}

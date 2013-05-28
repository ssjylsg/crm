using System.Web;
using NHibernate;

namespace WebCrm.Framework.Repositories
{
    internal class WebSessionStorage : ISessionStorage
    {
        public ISession GetSession()
        {
            return HttpContext.Current.Cache[SysConfig.SESSION_NAME] as ISession;
        }

        public void SetSession(ISession session)
        {
            if (session == null)
            {
                HttpContext.Current.Cache.Remove(SysConfig.SESSION_NAME);
            }
            else
            {
                HttpContext.Current.Cache[SysConfig.SESSION_NAME] = session;
            }
        }
    }
}

using System;
using NHibernate;

namespace WebCrm.Framework.Repositories
{
    internal class DefaultSessionStorage : ISessionStorage
    {
       [ThreadStatic]
        private static ISession _session;
        public ISession GetSession()
        {
            if (_session != null)
            {
                if (!_session.IsConnected)
                {
                    _session.Reconnect();
                }
            }
            return _session;
            //return AppDomain.CurrentDomain.GetData(SysConfig.SESSION_NAME) as ISession;
        }

        public void SetSession(ISession session)
        {
            //if (session.IsConnected)
            //{
            //    session.Disconnect();
            //}
            _session = session;
            //AppDomain.CurrentDomain.SetData(SysConfig.SESSION_NAME, session);
        }
    }
}

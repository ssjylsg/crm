using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrm.Framework.Repositories
{
    internal class SessionStorageFactory
    {
        /// <summary>
        /// 获得ISessionStorage
        /// </summary>
        /// <returns></returns>
        public static ISessionStorage GetSessionStorage()
        {
            if (Config.SessionSourceType.Equals("web", StringComparison.CurrentCultureIgnoreCase))
            {
                return new WebSessionStorage();
            }
            return new DefaultSessionStorage();
        }
    }

}

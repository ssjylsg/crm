using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace WebCrm.Framework.Repositories
{
    internal class Config
    {
        #region 私有成员

        private static object m_Locker = new object();
        private static string m_SessionSourceType = String.Empty;

        #endregion

        #region 属性

        /// <summary>
        /// Session资源源类型;http,threadStatic
        /// </summary>
        public static string SessionSourceType
        {
            get
            {
                lock (m_Locker)
                {
                    if (m_SessionSourceType == String.Empty)
                    {
                        return ConfigurationManager.AppSettings["SessionSourceType"];
                    }
                    else
                    {
                        return m_SessionSourceType;
                    }
                }
            }
        }
        /// <summary>
        /// 是否使用Session资源源
        /// </summary>
        public static bool UserSessionSource
        {
            get
            {
                lock (m_Locker)
                {
                    return true;
                    //return Convert.ToBoolean(ConfigurationManager.AppSettings["UserSessionSource"]);
                }
            }
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using WebCrm.Model;

namespace WebCrm.Web.Facade
{
    public class HttpCurrentUserService
    {
        internal static readonly string CurrentUserKey = "____currentUser";
        /// <summary>
        /// 设置当前用户
        /// </summary>
        /// <param name="operatorUser"></param>
        internal void SetUser(OperatorUser operatorUser)
        {
            HttpContext.Current.Items[CurrentUserKey] = operatorUser;

            if (operatorUser != null)
            {
                log4net.LogManager.GetLogger
                    (typeof(HttpCurrentUserService)).DebugFormat("设置当前用户为{0}|{1}|{2}",
                                                           operatorUser.OperatorName, operatorUser.Id, operatorUser.OperatorCode);
            }
        }
        public OperatorUser OperatorUser
        {
            get
            {
                try
                {
                    return HttpContext.Current.Items[CurrentUserKey] as OperatorUser;
                }
                catch { return null; }
            }
        }
        public static OperatorUser Current
        {
            get { return new HttpCurrentUserService().OperatorUser; }
        }
    }
}

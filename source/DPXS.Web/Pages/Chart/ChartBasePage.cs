using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCrm.Web.Facade;

namespace WebCrm.Web.Pages.Chart
{
    public class ChartBasePage : BasePage
    {
        /// <summary>
        /// 当前登录人所在公司
        /// </summary>
        public int CompanyId
        {
            get
            {
                return this.CurrentCompany != null ? this.CurrentCompany.Id : 0;
            }
        }
    }
}
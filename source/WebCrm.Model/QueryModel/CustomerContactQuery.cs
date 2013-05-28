using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrm.Model.QueryModel
{
    /// <summary>
    /// 客户联系查询条件
    /// </summary>
    public class CustomerContactQuery
    {
        public DateTime? EndBirthday { get; set; }
        /// <summary>
        /// 所有人
        /// </summary>
        public OperatorUser BussinessPerson { get; set; }
        
    }
}

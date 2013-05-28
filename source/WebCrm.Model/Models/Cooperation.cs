using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrm.Model
{
    /// <summary>
    /// 合作单位
    /// </summary>
    public class Cooperation : CrmEntity
    {
        #region Public Properties
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; set; }
        /// <summary>
        /// 合作日期
        /// </summary>
        public virtual DateTime CreateDate { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 合作单位联系号码
        /// </summary>
        public virtual string TelNo { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public virtual string Email { get; set; }
        /// <summary>
        /// 联系人姓名多个
        /// </summary>
        public virtual string ContactName { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public virtual string Address { get; set; }
        /// <summary>
        /// 传真
        /// </summary>
        public virtual string Fax { get; set; }
        /// <summary>
        /// 公司
        /// </summary>
        public virtual Company Company { get; set; }
        #endregion
    }
}

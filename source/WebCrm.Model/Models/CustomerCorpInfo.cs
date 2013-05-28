using System;
using System.Collections;

namespace WebCrm.Model
{
    /// <summary>
    /// 公司客户信息
    /// </summary>
    public class CustomerCorpInfo : CrmEntity
    {

        #region Public Properties
        /// <summary>
        /// 客户公司名称
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 公司类型
        /// </summary>
        public virtual CategoryItem CorpType { get; set; }
        /// <summary>
        /// 网站
        /// </summary>
        public virtual string Url { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public virtual string LinkMan { get; set; }
        /// <summary>
        /// 联系人电话
        /// </summary>
        public virtual string LinkManTel { get; set; }
        /// <summary>
        /// 办公室电话
        /// </summary>
        public virtual string TelPhone { get; set; }
        /// <summary>
        /// 传真
        /// </summary>
        public virtual string Fax { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public virtual string Address { get; set; }
        /// <summary>
        /// QQ
        /// </summary>
        public virtual string QQ { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string Remark { get; set; }
        /// <summary>
        /// 客户信息
        /// </summary>
        public virtual Customer Customer { get; set; }
        #endregion
    }

}
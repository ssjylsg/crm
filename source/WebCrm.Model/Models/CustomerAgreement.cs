using System;
using System.Collections;

namespace WebCrm.Model
{
    /// <summary>
    /// 大客户协议
    /// </summary>
    public class CustomerAgreement : CrmEntity
    {
        /// <summary>
        /// 客户
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// 协议类型
        /// </summary>
        public virtual CategoryItem AgreementType { get; set; }

        /// <summary>
        /// 附件集合
        /// </summary>
        public virtual string FileIds { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public virtual OperatorUser CreateUser { get; set; }
        /// <summary>
        /// 到期  如果为长期协议 则为空
        /// </summary>
        public virtual DateTime? Expire { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public virtual string Content { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public virtual string Subject { get; set; }
    }

}
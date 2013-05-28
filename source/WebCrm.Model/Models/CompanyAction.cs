using System;
using System.Collections;

namespace WebCrm.Model
{
    #region CompanyAction
    /// <summary>
    /// 活动
    /// </summary>
    public class CompanyAction : CrmEntity
    {
        #region Public Properties
        /// <summary>
        /// 内容
        /// </summary>
        public virtual string Content { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 投放日期
        /// </summary>
        public virtual DateTime ActionDate { get; set; }
        /// <summary>
        /// 花费
        /// </summary>
        public virtual decimal Free { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public virtual CategoryItem State { get; set; }
        /// <summary>
        /// 评估
        /// </summary>
        public virtual CategoryItem Evaluate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; set; }
        /// <summary>
        /// 合作单位
        /// </summary>
        public virtual Cooperation WorkName { get; set; }
        /// <summary>
        /// 附件集合
        /// </summary>
        public virtual string FiledIds { get; set; }
        /// <summary>
        /// 公司
        /// </summary>
        public virtual Company Company { get; set; }
        #endregion
    }
    #endregion
}

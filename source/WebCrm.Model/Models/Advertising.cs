using System;
using System.Collections;

namespace WebCrm.Model
{
    #region Advertising

    /// <summary>
    /// 广告
    /// </summary>
    public class Advertising : CrmEntity
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
        public virtual DateTime DeliveryDate { get; set; }
        /// <summary>
        /// 渠道
        /// </summary>
        public virtual CategoryItem Channel { get; set; }
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
        /// 公司
        /// </summary>
        public virtual Company Company { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public virtual string WorkName { get; set; }
        /// <summary>
        /// 附件集合
        /// </summary>
        public virtual string FiledIds { get; set; }
        #endregion
    }
    #endregion
}
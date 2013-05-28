using System;
using System.Collections;

namespace WebCrm.Model
{
    #region Financial

    /// <summary>
    /// 财务相关
    /// </summary>
    public class Financial : CrmEntity
    {
        /// <summary>
        /// 应付款类型
        /// </summary>
        public virtual CategoryItem FinancialPayType { get; set; }

        /// <summary>
        /// 附件集合
        /// </summary>
        public virtual string FiledIds { get; set; }

        public Financial()
            : base()
        {

        }
        #region Public Properties
        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 财务类别
        /// </summary>
        public virtual FinancialType FinancialType { get; set; }
        /// <summary>
        /// 收款单位
        /// </summary>
        public virtual Customer Customer { get; set; }
        /// <summary>
        /// 客户姓名
        /// </summary>
        public virtual string CustomerName { get; set; }
        /// <summary>
        /// 净额
        /// </summary>
        public virtual decimal SumPrice { get; set; }
        /// <summary>
        /// 是否已收/已付
        /// </summary>
        public virtual bool State { get; set; }
        /// <summary>
        /// 开始日期
        /// </summary>
        public virtual DateTime FinancialDate { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public virtual OperatorUser ChargePerson { get; set; }
        /// <summary>
        /// 处理结果
        /// </summary>
        public virtual string TreatResult { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; set; }

        /// <summary>
        /// 付款单位
        /// </summary>
        public virtual Cooperation Cooperation { get; set; }
        /// <summary>
        /// 公司
        /// </summary>
        public virtual Company Company { get; set; }
        #endregion
    }
    #endregion
}
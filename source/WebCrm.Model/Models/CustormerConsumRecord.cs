using System;
using System.Collections;

namespace WebCrm.Model
{
    #region CustormerConsumRecord

    /// <summary>
    /// 消费记录
    /// </summary>
    public class CustormerConsumRecord : CrmEntity
    {
        public CustormerConsumRecord()
            : base()
        {
            this.WriteDate = DateTime.Now;
            FiledIds = "";
        }

        #region Public Properties

        /// <summary>
        /// 消费日期
        /// </summary>
        public virtual DateTime? ConsumptionDate { get; set; }
        /// <summary>
        /// 消费者
        /// </summary>
        public virtual Customer Customer { get; set; }
        /// <summary>
        /// 总花费
        /// </summary>
        public virtual decimal SpendTotal { get; set; }
        /// <summary>
        /// 打折方式
        /// </summary>
        public virtual CategoryItem DiscountType { get; set; }
        /// <summary>
        /// 打折后总消费数
        /// </summary>
        public virtual decimal AfterDiscountFree { get; set; }
        /// <summary>
        /// 本次积分
        /// </summary>
        public virtual int Score { get; set; }
        /// <summary>
        /// 积分规则
        /// </summary>
        public virtual CategoryItem ScoreRule { get; set; }
        /// <summary>
        /// 录入时间
        /// </summary>
        public virtual DateTime WriteDate { get; set; }
        /// <summary>
        /// 录入人
        /// </summary>
        public virtual OperatorUser WritePerson { get; set; }

        /// <summary>
        /// 收到款项
        /// </summary>
        public virtual decimal ReceiveMoney { get; set; }
        /// <summary>
        /// 公司
        /// </summary>
        public virtual Company Company { get; set; }
        /// <summary>
        /// 消费明细
        /// </summary>
        public virtual string ConsumerDetails { get; set; }
        /// <summary>
        /// 备注信息
        /// </summary>
        public virtual string Remark { get; set; }
        /// <summary>
        /// 消费类型
        /// </summary>
        public virtual CategoryItem ConsumerBusinessType { get; set; }
        /// <summary>
        /// 附件集合
        /// </summary>
        public virtual string FiledIds { get; set; }
        /// <summary>
        /// 业务人员
        /// </summary>
        public virtual OperatorUser BussinessPerson { get; set; }
        #endregion
    }
    #endregion
}
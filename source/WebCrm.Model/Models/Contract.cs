using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace WebCrm.Model
{
    /// <summary>
    /// 合同
    /// </summary>
    public class Contract : CrmEntity
    {
        #region Constructors

        public Contract()
            : base()
        {
            this.CreateDate = System.DateTime.Now;
            FiledIds = string.Empty;

        }

        #endregion

        #region Public Properties


        /// <summary>
        /// 合同名称
        /// </summary>
        public virtual string ContractName { get; set; }

        /// <summary>
        /// 合同状态
        /// </summary>
        public virtual CategoryItem State { get; set; }
        /// <summary>
        /// 附件集合
        /// </summary>
        public virtual string FiledIds { get; set; }
        /// <summary>
        /// 客户姓名
        /// </summary>
        public virtual string CustomerName { get; set; }

        public virtual Customer Customer { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public virtual string Code { get; set; }
        /// <summary>
        /// 开始日期
        /// </summary>
        public virtual DateTime StartDate { get; set; }
        /// <summary>
        /// 结束日期
        /// </summary>
        public virtual DateTime EndDate { get; set; }
        /// <summary>
        /// 公司签约人
        /// </summary>
        public virtual OperatorUser SignPerson { get; set; }
        /// <summary>
        /// 客户签约人
        /// </summary>
        public virtual string CustomerSignPerson { get; set; }
        /// <summary>
        /// 签约日期
        /// </summary>
        public virtual DateTime SignDate { get; set; }
        /// <summary>
        /// 签约地点
        /// </summary>
        public virtual string SignAddress { get; set; }
        /// <summary>
        /// 存放地址
        /// </summary>
        public virtual string StorePlace { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public virtual decimal Sum { get; set; }
        /// <summary>
        /// 结算情况
        /// </summary>
        public virtual SettleState SettleState { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public virtual OperatorUser CreatePerson { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public virtual DateTime CreateDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; set; }
        /// <summary>
        /// 合同内容
        /// </summary>
        public virtual string Content { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        public virtual Company Company { get; set; }

        #endregion
    }

}
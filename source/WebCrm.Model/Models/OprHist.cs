using System;
using System.Collections;

namespace WebCrm.Model
{
    #region OprHist

    /// <summary>
    /// 操作历史
    /// </summary>
    public class OprHist : CrmEntity
    {

        #region Public Properties
        /// <summary>
        /// 操作人姓名
        /// </summary>
        public virtual string OprUsername { get; set; }
        /// <summary>
        /// 操作动作
        /// </summary>
        public virtual string OprAction { get; set; }
        /// <summary>
        /// 步骤
        /// </summary>
        public virtual string StageDesc { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string OprComment { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public virtual DateTime OprDateTime { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public virtual OperatorUser OprUser { get; set; }

        /// <summary>
        /// 单据ID
        /// </summary>
        public virtual int RequestId { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public virtual string RequestType { get; set; }

        #endregion
    }
    #endregion
}
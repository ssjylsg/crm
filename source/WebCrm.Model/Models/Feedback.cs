using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrm.Model.Models
{
    /// <summary>
    /// 反馈
    /// </summary>
    public class Feedback : CrmEntity
    {
        /// <summary>
        /// 提交人
        /// </summary>
        public virtual OperatorUser CreateUser { get; set; }
        /// <summary>
        /// 错误页
        /// </summary>
        public virtual string ErrorUrl { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public virtual string Subject { get; set; }
        /// <summary>
        /// 反馈类型
        /// </summary>
        public virtual CategoryItem FeedType { get; set; }
        /// <summary>
        /// 问题描述
        /// </summary>
        public virtual string Description { get; set; }
        /// <summary>
        /// 处理人员
        /// </summary>
        public virtual OperatorUser DealUser { get; set; }
        /// <summary>
        /// 处理时间
        /// </summary>
        public virtual DateTime DealDate { get; set; }
        /// <summary>
        /// 处理文案
        /// </summary>
        public virtual string DealText { get; set; }
    }
}

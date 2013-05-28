using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrm.Model
{
    /// <summary>
    /// 电话记录
    /// </summary>
    public class PhoneCall : CrmEntity
    {
        /// <summary>
        /// 主题
        /// </summary>
        public virtual string Subject { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public virtual DateTime StartDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public virtual DateTime EndDate { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public virtual CategoryItem Stateus { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public virtual string Description { get; set; }
        /// <summary>
        /// 文件
        /// </summary>
        public virtual string FileIds { get; set; }
    }
}

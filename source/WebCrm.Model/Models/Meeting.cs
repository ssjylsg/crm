using System;

namespace WebCrm.Model
{
    /// <summary>
    /// 会议
    /// </summary>
    public class Meeting : CrmEntity
    {
        /// <summary>
        /// 会议主题
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
        /// 地点
        /// </summary>
        public virtual string Location { get; set; }
        /// <summary>
        /// 文件
        /// </summary>
        public virtual string FileIds { get; set; }
    }
}

using System;

namespace WebCrm.Model.Models
{
    /// <summary>
    /// 新闻
    /// </summary>
    public class News: CrmEntity
    {
        /// <summary>
        /// 会议主题
        /// </summary>
        public virtual string Subject { get; set; }
        /// <summary>
        /// 消息分类
        /// </summary>
        public virtual CategoryItem NewsType { get; set; }
        /// <summary>
        /// 新闻内容
        /// </summary>
        public virtual string Content { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        public virtual string Source { get; set; }
        /// <summary>
        /// 来源地址
        /// </summary>
        public virtual string SourceUrl { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public virtual DateTime PlayDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrm.Model
{
    /// <summary>
    /// 消息
    /// </summary>
    public class MessageContent : CrmEntity
    {
        /// <summary>
        /// 发送次数
        /// </summary>
        public virtual int SendCount { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        public virtual string MsgContent { get; set; }
        /// <summary>
        /// 消息接收方
        /// </summary>
        public virtual string ToNumber { get; set; }
        /// <summary>
        /// 是否成功发送
        /// </summary>
        public virtual bool IsSend { get; set; }
        /// <summary>
        /// 消息中的日期 如 生日模板是 客户的生日，节假日 是 节假日的日期
        /// </summary>
        public virtual DateTime? MessageDate { get; set; }
        /// <summary>
        /// 消息模板
        /// </summary>
        public virtual Template MessageTemplate { get; set; }
    }
}

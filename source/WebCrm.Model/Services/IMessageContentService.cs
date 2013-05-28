using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrm.Model.Services
{
    public interface IMessageContentService : IBaseRequestService<MessageContent>
    {
        /// <summary>
        /// 获取要发送的数据
        /// </summary>
        /// <returns></returns>
        IList<MessageContent> GetAllNoSend();
        /// <summary>
        /// 保存消息列表
        /// </summary>
        /// <param name="messageContents"></param>
        void SaveList(IList<MessageContent> messageContents);
        /// <summary>
        /// 判断是否已经产生信息
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="template"></param>
        /// <param name="messageDate"></param>
        /// <returns></returns>
        bool NoSendInfo(string mobile, Template template, DateTime messageDate);
    }
}

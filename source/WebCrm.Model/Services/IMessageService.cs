using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrm.Model.Services
{
    public interface IMessageService
    {
        bool GenerateMessageInfo(string form, string to, string content);

        /// <summary>
        /// 将要发送的消息 写入到数据库 等待定时任务获取数据发送信息
        /// </summary>
        /// <param name="categoryItem">消息模板</param>
        void GenerateMessageInfo(CategoryItem categoryItem);
        /// <summary>
        /// 自动发送消息
        /// </summary>
        void AutoSendInfo();
    }
}

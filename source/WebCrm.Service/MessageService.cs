using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using WebCrm.Framework;
using WebCrm.Model;
using WebCrm.Model.Services;

namespace WebCrm.Service
{
    public class MessageService : IMessageService
    {
        private ILog _log;
        public MessageService()
        {
            _log = LogManager.GetLogger(this.GetType());
        }
        public bool GenerateMessageInfo(string form, string to, string content)
        {
            string infoId = Guid.NewGuid().ToString();
            var messageInfo = string.Format("发送消息到{0}，消息内容为:{1}，消息ID:{2}", to, content, infoId);
            try
            {

                this._log.InfoFormat(messageInfo + "成功");
            }
            catch (Exception ex)
            {
                _log.Error(messageInfo + "发送失败，失败原因:" + ex);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 将要发送的消息 写入到数据库 等待定时任务获取数据发送信息
        /// </summary>
        /// <param name="categoryItem"></param>
        public void GenerateMessageInfo(CategoryItem categoryItem)
        {
            var templateList = DependencyResolver.Resolver<ITemplateService>().GetTemplateByCategory(categoryItem);

            if (templateList.Count == 0)
            {
                _log.InfoFormat("{0} 无要发送的信息,模板信息为空，模板分类{1}", DateTime.Now.ToShortDateString(),
                                categoryItem.Name + categoryItem.Id);
                return;
            }

            if (categoryItem.OtherInfo == "Holiday")
            {
                SendHolidayMsgInfo(templateList);
            }
            else if (categoryItem.OtherInfo == "Birthday")
            {
                BirthDayMessageGenerate(templateList);
            }
        }
        private void BirthDayMessageGenerate(List<Template> templates)
        {
            if (templates.LongCount() == 0)
            {
                this._log.InfoFormat(string.Format("生日模板为空,{0}", DateTime.Now.ToShortDateString()));
                return;
            }
            IList<CustomerInfo> list = DependencyResolver.Resolver<ICustomerInfoService>().FindSendInfoCustomers();

            IList<MessageContent> messageContents = new List<MessageContent>();
            var messageService = DependencyResolver.Resolver<IMessageContentService>();
            foreach (CustomerInfo customerInfo in list)
            {
                if (!string.IsNullOrEmpty(customerInfo.Mobile))
                {
                    if (!customerInfo.BirthDate.HasValue)
                    {
                        continue;
                    }
                    foreach (var msg in templates)
                    {
                        // 如果此条信息已经产生 将不再产生
                        if (!messageService.NoSendInfo(customerInfo.Mobile, msg, customerInfo.BirthDate.Value))
                        {
                            continue;
                        }
                        messageContents.Add(new MessageContent()
                                                {
                                                    CreateTime = DateTime.Now,
                                                    Deleted = false,
                                                    IsSend = false,
                                                    ModifyTime = DateTime.Now,
                                                    MsgContent =
                                                        msg.MsgContent.Replace("Name", customerInfo.RealName).Replace(
                                                            "Birthday", customerInfo.BirthDate.Value.ToShortDateString()),
                                                    ToNumber = customerInfo.Mobile,
                                                    MessageTemplate = msg,
                                                    MessageDate = customerInfo.BirthDate.Value
                                                });
                    }
                }
            }
            DependencyResolver.Resolver<IMessageContentService>().SaveList(messageContents);
        }
        /// <summary>
        /// 定时发送消息
        /// </summary>
        public void AutoSendInfo()
        {
            var messageServie = DependencyResolver.Resolver<IMessageContentService>();
            var messageList = messageServie.GetAllNoSend();
            CrmDictionary crmDictionary =
                DependencyResolver.Resolver<ICrmDictionaryService>().FindByKey("SendMobileInfo");

            if (crmDictionary == null || string.IsNullOrEmpty(crmDictionary.Value))
            {
                this._log.Error("发送消息Key=SendMobileInfo 未配置");
                return;
            }

            foreach (MessageContent messageContent in messageList)
            {
                messageContent.IsSend = this.GenerateMessageInfo(crmDictionary.Value, messageContent.ToNumber, messageContent.MsgContent);
                messageContent.SendCount = messageContent.SendCount + 1;
                messageServie.Update(messageContent);
            }
        }
        /// <summary>
        /// 获取节假日要发送的消息并写入数据库
        /// </summary>
        /// <param name="templates"></param>
        private void SendHolidayMsgInfo(List<Template> templates)
        {
            IList<Holiday> days =
                DependencyResolver.Resolver<IHolidayService>().GetSendInfoHodiay()
                    .Where(
                        m =>
                        DateTime.Now.AddDays(m.DateNum).ToString("yyyy-MM-dd") == m.HolidayDate.ToString("yyyy-MM-dd"))
                    .ToList();
            if (days.Count == 0)
            {
                _log.InfoFormat("{0} 无要发送的节假日祝贺信息", DateTime.Now.ToShortDateString());
                return;
            }
            IList<CustomerInfo> list = DependencyResolver.Resolver<ICustomerInfoService>().FindSendInfoCustomers();

            IList<MessageContent> messageContents = new List<MessageContent>();
            var messageService = DependencyResolver.Resolver<IMessageContentService>();
            foreach (Template template in templates)
            {
                foreach (Holiday holiday in days)
                {
                    var msg = (template.MsgContent.Replace("HolidayName", holiday.Name));
                    foreach (CustomerInfo customerInfo in list)
                    {

                        if (!string.IsNullOrEmpty(customerInfo.Mobile))
                        {
                            // 如果此条信息已经产生 将不再产生
                            if (!messageService.NoSendInfo(customerInfo.Mobile, template, holiday.HolidayDate))
                            {
                                continue;
                            }

                            messageContents.Add(new MessageContent()
                            {
                                CreateTime = DateTime.Now,
                                Deleted = false,
                                IsSend = false,
                                ModifyTime = DateTime.Now,
                                MsgContent = msg.Replace("Name", customerInfo.RealName),
                                ToNumber = customerInfo.Mobile,
                                MessageTemplate = template,
                                MessageDate = holiday.HolidayDate
                            });
                        }
                    }
                }
            }
            DependencyResolver.Resolver<IMessageContentService>().SaveList(messageContents);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Model;
using WebCrm.Model.Repositories;
using WebCrm.Model.Services;

namespace WebCrm.Service
{
    public class MessageContentService : BaseRequestService<MessageContent>, IMessageContentService
    {
        private IMessageContentRepository _messageContentRepository;
        public MessageContentService(IMessageContentRepository messageContentRepository)
        {
            _messageContentRepository = messageContentRepository;
        }

        public IList<MessageContent> GetAllNoSend()
        {
            return _messageContentRepository.GetAllNoSend();
        }

        public void SaveList(IList<MessageContent> messageContents)
        {
            foreach (MessageContent messageContent in messageContents)
            {
                this.Save(messageContent);
            }
        }

        public bool NoSendInfo(string mobile, Template template, DateTime holidayDate)
        {
            return _messageContentRepository.NoSendInfo(mobile, template, holidayDate);
        }
    }
}

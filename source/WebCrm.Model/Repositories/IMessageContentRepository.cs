using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;

namespace WebCrm.Model.Repositories
{
    public interface IMessageContentRepository : IBaseNhibreateRepository<MessageContent>
    {
        IList<MessageContent> GetAllNoSend();

        bool NoSendInfo(string mobile, Template template, DateTime holidayDate);
    }
}

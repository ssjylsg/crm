using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;
using WebCrm.Model;
using WebCrm.Model.Repositories;

namespace WebCrm.Dao
{
    public class MessageContentRepository : BaseNhibreateRepository<MessageContent>, IMessageContentRepository
    {
        public IList<MessageContent> GetAllNoSend()
        {
            return this.GetSession().CreateQuery("From MessageContent Where IsSend != 1 And Deleted != 1 Order By CreateTime Desc").List<MessageContent>();
        }

        public bool NoSendInfo(string mobile, Template template, DateTime holidayDate)
        {
            return this.GetSession().CreateSQLQuery(
                String.Format(
                    @"SELECT COUNT(1) FROM {3} M WHERE
                                M.TEMPLATE = {0} 
                                AND M.TONUMBER = '{1}' 
                                AND to_char(M.MESSAGEDATE,'yyyy-mm-dd') = '{2}'",
                    template.Id, mobile, holidayDate.ToString("yyyy-MM-dd"),
                    NHibernateDatabaseFactory.TableName(typeof(MessageContent))
                    )).UniqueResult().ObjectToInt() <= 0;
        }
    }
}

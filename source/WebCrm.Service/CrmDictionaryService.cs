using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Model.Repositories;

namespace WebCrm.Service
{
    public class CrmDictionaryService : BaseRequestService<CrmDictionary>, ICrmDictionaryService
    {
        private ICrmDictionaryRepository _crmdictionaryService;
        public CrmDictionaryService(ICrmDictionaryRepository crmdictionaryService)
        {
            this._crmdictionaryService = crmdictionaryService;
        }

        public void Query(PageQuery<IDictionary<string, object>, CrmDictionary> pageQuery)
        {
            this._crmdictionaryService.Query(pageQuery);
        }

        public int GetScalar(string keys)
        {
            return _crmdictionaryService.GetScalar(keys);
        }

        public CrmDictionary FindByKey(string key)
        {
            return _crmdictionaryService.Query(string.Format("From CrmDictionary Where Key='{0}' And Deleted != 1", key)).FirstOrDefault();
        }
        public void CrmDictoryTest()
        {
            var dic = FindByKey("SendMobileInfo");
            if (dic == null)
            {
                Save(new CrmDictionary()
                 {
                     Key = "SendMobileInfo",
                     Depict = "手机发送信息发送者号码"
                 });
            }
        }
    }
}

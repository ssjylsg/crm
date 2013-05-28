using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrm.Model.Services
{
    public interface ICrmDictionaryService : IBaseRequestService<CrmDictionary>
    {
        void Query(PageQuery<IDictionary<string, object>, CrmDictionary> pageQuery);
        int GetScalar(string keys);
        CrmDictionary FindByKey(string p);
        void CrmDictoryTest();
    }
}

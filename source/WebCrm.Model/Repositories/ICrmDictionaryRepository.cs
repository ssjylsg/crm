using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;

namespace WebCrm.Model.Repositories
{
    public interface ICrmDictionaryRepository : IBaseNhibreateRepository<CrmDictionary>
    {
        void Query(PageQuery<IDictionary<string, object>, CrmDictionary> pageQuery);
        int GetScalar(string keys);
    }
}

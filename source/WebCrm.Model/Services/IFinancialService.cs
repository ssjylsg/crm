using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrm.Model.Services
{
    public interface IFinancialService : IBaseRequestService<Financial>
    {
        void Query(PageQuery<IDictionary<string, object>, Financial> pageQuery);
    }
}

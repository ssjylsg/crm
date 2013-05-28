using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace WebCrm.Model.Services
{
    public interface ICompanyActionService : IBaseRequestService<CompanyAction>
    {
        void Query(PageQuery<IDictionary<string, object>, CompanyAction> pageQuery);
        DataTable GetStatisticsData(Dictionary<string, object> dict);
    }
}

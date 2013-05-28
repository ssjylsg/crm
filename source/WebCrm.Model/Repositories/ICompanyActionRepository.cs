using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;
using System.Data;

namespace WebCrm.Model.Repositories
{
    public interface ICompanyActionRepository : IBaseNhibreateRepository<CompanyAction>
    {
        void Query(PageQuery<IDictionary<string, object>, CompanyAction> pageQuery);
        DataTable GetStatisticsData(Dictionary<string, object> dict);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;
using System.Data;

namespace WebCrm.Model.Repositories
{
    public interface ICustormerConsumRecordRepository : IBaseNhibreateRepository<CustormerConsumRecord>
    {
        void Query(PageQuery<IDictionary<string, object>, CustormerConsumRecord> pageQuery);
        DataTable GetStatisticsData(Dictionary<string, object> dict);
        DataTable GetExpenseTrendData(Dictionary<string, object> dict);
    }
}

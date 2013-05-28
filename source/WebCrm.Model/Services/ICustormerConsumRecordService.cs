using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace WebCrm.Model.Services
{
    public interface ICustormerConsumRecordService : IBaseRequestService<CustormerConsumRecord>
    {

        void Query(PageQuery<IDictionary<string, object>, CustormerConsumRecord> pageQuery);
        DataTable GetStatisticsData(Dictionary<string, object> dict);
        DataTable GetExpenseTrendData(Dictionary<string, object> dict);

        IList<CustormerConsumRecord> FindByCustomerId(int p);
    }
}

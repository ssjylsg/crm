using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;
using System.Data;

namespace WebCrm.Model.Repositories
{
    public interface ICustomerRepository : IBaseNhibreateRepository<Customer>
    {
        void Query(PageQuery<IDictionary<string, object>, Customer> pageQuery);
        DataTable GetStatisticsData(Dictionary<string, object> dict);

        DataTable GetByCondition(Dictionary<string, object> dict, string selectFields = "*");

    }
}

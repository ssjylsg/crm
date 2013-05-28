using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;
using System.Data;

namespace WebCrm.Model.Repositories
{
    public interface IAdvertisingRepository : IBaseNhibreateRepository<Advertising>
    {
        void Query(PageQuery<IDictionary<string, object>, Advertising> pageQuery);
        DataTable GetStatisticsData(Dictionary<string, object> dict);
    }
}

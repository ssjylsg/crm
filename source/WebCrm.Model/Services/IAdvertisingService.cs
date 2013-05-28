using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace WebCrm.Model.Services
{
    public interface IAdvertisingService : IBaseRequestService<Advertising>
    {
        void Query(PageQuery<IDictionary<string, object>, Advertising> pageQuery);

        DataTable GetStatisticsData(Dictionary<string, object> dict);
    }
}

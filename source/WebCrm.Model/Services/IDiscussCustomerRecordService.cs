using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrm.Model.Services
{
    public interface IDiscussCustomerRecordService : IBaseRequestService<DiscussCustomerRecord>
    {
        void Query(PageQuery<IDictionary<string, object>, DiscussCustomerRecord> pageQuery);

        IList<DiscussCustomerRecord> FindByCustomerId(int p);
    }
}

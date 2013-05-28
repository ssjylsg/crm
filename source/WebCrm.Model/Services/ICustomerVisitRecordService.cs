using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrm.Model.Services
{
    public interface ICustomerVisitRecordService : IBaseRequestService<CustomerVisitRecord>
    {
        void Query(PageQuery<IDictionary<string, object>, CustomerVisitRecord> pageQuery);

        IList<CustomerVisitRecord> FindByCustomerId(int p);
    }
}

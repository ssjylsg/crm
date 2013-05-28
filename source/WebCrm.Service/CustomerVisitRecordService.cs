using System.Collections.Generic;
using System.Linq;
using WebCrm.Model;
using WebCrm.Model.Repositories;
using WebCrm.Model.Services;

namespace WebCrm.Service
{
    public class CustomerVisitRecordService : BaseRequestService<CustomerVisitRecord>, ICustomerVisitRecordService
    {
       

        private ICustomerVisitRecordRepository _customerVisitRecordRepository;
        public CustomerVisitRecordService(ICustomerVisitRecordRepository customerVisitRecordRepository)
        {
            _customerVisitRecordRepository = customerVisitRecordRepository;
        }

        public void Query(PageQuery<IDictionary<string, object>, CustomerVisitRecord> pageQuery)
        {
            _customerVisitRecordRepository.Query(pageQuery);
        }

        public IList<CustomerVisitRecord> FindByCustomerId(int p)
        {
            return
                _customerVisitRecordRepository.Query(
                    string.Format("FROM CustomerVisitRecord WHERE Customer.Id ={0} AND Deleted <>1 Order by CreateTime", p), SysConfig.QueryMaxResult)
                    .ToList();
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using WebCrm.Model;
using WebCrm.Model.Repositories;
using WebCrm.Model.Services;

namespace WebCrm.Service
{
    public class DiscussCustomerRecordService : BaseRequestService<DiscussCustomerRecord>, IDiscussCustomerRecordService
    {
        private IDiscussCustomerRecordRepository _discussCustomerRecordRepository;
        
        public DiscussCustomerRecordService(IDiscussCustomerRecordRepository discussCustomerRecordRepository)
        {
            this._discussCustomerRecordRepository = discussCustomerRecordRepository;
        }
        public void SaveOrUpdate(DiscussCustomerRecord record)
        {
            _discussCustomerRecordRepository.SaveOrUpdate(record);
        }

        public void Query(PageQuery<IDictionary<string, object>, DiscussCustomerRecord> pageQuery)
        {
            _discussCustomerRecordRepository.Query(pageQuery);
        }

        public IList<DiscussCustomerRecord> FindByCustomerId(int p)
        {
            return
              _discussCustomerRecordRepository.Query(
                  string.Format("FROM DiscussCustomerRecord WHERE Customer.Id ={0} AND Deleted <>1  Order by CreateTime", p), SysConfig.QueryMaxResult).ToList();
        }
    }
}

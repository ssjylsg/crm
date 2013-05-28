using System.Collections.Generic;
using System.Linq;
using WebCrm.Model;
using WebCrm.Model.Repositories;
using WebCrm.Model.Services;
using System.Data;

namespace WebCrm.Service
{
    public class CustormerConsumRecordService : BaseRequestService<CustormerConsumRecord>, ICustormerConsumRecordService
    {
        private ICustormerConsumRecordRepository _recordRepository;
        
        public CustormerConsumRecordService(ICustormerConsumRecordRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }
        public void SaveOrUpdate(CustormerConsumRecord record)
        {
            _recordRepository.SaveOrUpdate(record);
        }


        public void Query(PageQuery<IDictionary<string, object>, CustormerConsumRecord> pageQuery)
        {
            _recordRepository.Query(pageQuery);
        }

        public DataTable GetStatisticsData(Dictionary<string, object> dict)
        {
            return _recordRepository.GetStatisticsData(dict);
        }

        public DataTable GetExpenseTrendData(Dictionary<string, object> dict)
        {
            return _recordRepository.GetExpenseTrendData(dict);
        }

        public IList<CustormerConsumRecord> FindByCustomerId(int p)
        {
            return
             _recordRepository.Query(
                 string.Format("FROM CustormerConsumRecord WHERE Customer.Id ={0} AND Deleted <>1  Order by CreateTime", p),SysConfig.QueryMaxResult).ToList();
        }
    }
}

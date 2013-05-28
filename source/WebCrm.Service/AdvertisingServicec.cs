using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Model;
using WebCrm.Model.Repositories;
using WebCrm.Model.Services;
using System.Data;

namespace WebCrm.Service
{
    public class AdvertisingServicec : BaseRequestService<Advertising>, IAdvertisingService
    {
        private IAdvertisingRepository _advertisingRepository;
        public AdvertisingServicec(IAdvertisingRepository advertisingRepository)
        {
            _advertisingRepository = advertisingRepository;
        }

        public void Query(PageQuery<IDictionary<string, object>, Advertising> pageQuery)
        {
            this._advertisingRepository.Query(pageQuery);
        }

        public DataTable GetStatisticsData(Dictionary<string, object> dict)
        {
            return _advertisingRepository.GetStatisticsData(dict);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Model;
using WebCrm.Model.Services;

namespace WebCrm.Service
{
    public class CustomerCorpInfoService : BaseRequestService<CustomerCorpInfo>, ICustomerCorpInfoService
    {
        private WebCrm.Model.Repositories.ICustomerCorpInfoRepository _corpInfoRepository;
        public CustomerCorpInfoService(WebCrm.Model.Repositories.ICustomerCorpInfoRepository corpInfoRepository)
        {
            _corpInfoRepository = corpInfoRepository;
        }
        public CustomerCorpInfo FindByCustomerId(int p)
        {
            return
                _corpInfoRepository.Query(string.Format(" From CustomerCorpInfo  Where Customer.Id = {0}", p)).
                    FirstOrDefault();
        }
    }
}

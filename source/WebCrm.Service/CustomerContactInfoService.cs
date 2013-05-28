using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Model;
using WebCrm.Model.QueryModel;
using WebCrm.Model.Repositories;
using WebCrm.Model.Services;

namespace WebCrm.Service
{
    public class CustomerContactInfoService : BaseRequestService<CustomerContactInfo>, ICustomerContactInfoService
    {
        private ICustomerContactInfoRepository _contactInfoRepository;
        public CustomerContactInfoService(ICustomerContactInfoRepository contactInfoRepository)
        {
            _contactInfoRepository = contactInfoRepository;
        }
        public void Query(PageQuery<IDictionary<string, object>, CustomerContactInfo> pageQuery)
        {
            _contactInfoRepository.Query(pageQuery);
        }

        public IList<CustomerContactInfo> FindByCustomerId(int customerId)
        {
            return
                this._contactInfoRepository.Query(string.Format(
                    "From CustomerContactInfo Where Customer.Id = {0} And Deleted != 1", customerId)).ToList();
        }

        public void Query(PageQuery<CustomerContactQuery, CustomerContactInfo> pageQuery)
        {

            this._contactInfoRepository.Query(pageQuery);
        }
    }
}

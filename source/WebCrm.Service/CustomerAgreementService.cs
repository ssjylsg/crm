using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Model;
using WebCrm.Model.Repositories;
using WebCrm.Model.Services;

namespace WebCrm.Service
{
    public class CustomerAgreementService : BaseRequestService<CustomerAgreement>, ICustomerAgreementService
    {
        private ICustomerAgreementRepository _customerAgreementRepository;
        public CustomerAgreementService(ICustomerAgreementRepository customerAgreementRepository)
        {
            _customerAgreementRepository = customerAgreementRepository;
        }

        public void Query(PageQuery<IDictionary<string, object>, CustomerAgreement> pageQuery)
        {
            _customerAgreementRepository.Query(pageQuery);
        }
    }
}

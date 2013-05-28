using System.Collections.Generic;
using System.Linq;
using WebCrm.Model;
using WebCrm.Model.Repositories;
using WebCrm.Model.Services;

namespace WebCrm.Service
{
    public class CustomerInfoService : BaseRequestService<CustomerInfo>, ICustomerInfoService
    {
        private ICustomerInfoRepository _repository;
        public CustomerInfoService(ICustomerInfoRepository repository)
        {
            _repository = repository;
        }
         
        public IList<CustomerInfo> FindSendInfoCustomers()
        {
            return _repository.FindSendInfoCustomers();
        }

        public CustomerInfo FindByCustomerId(int id)
        {
            return
              _repository.Query(string.Format(" From CustomerInfo  Where Customer.Id = {0}", id)).
                  FirstOrDefault();
        }
    }
}

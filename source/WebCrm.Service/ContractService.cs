using System.Collections.Generic;
using WebCrm.Model;
using WebCrm.Model.Repositories;
using WebCrm.Model.Services;

namespace WebCrm.Service
{
    public class ContractService : BaseRequestService<Contract>, IContractService
    {
        private IContractRepository _contractRepository;
        public ContractService(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }
        

        public void Query(PageQuery<IDictionary<string, object>, Contract> pageQuery)
        {
            _contractRepository.Query(pageQuery);
        }
    }
}

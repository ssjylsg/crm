using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Model;
using WebCrm.Model.Repositories;
using WebCrm.Model.Services;

namespace WebCrm.Service
{
    public class FinancialService : BaseRequestService<Financial>, IFinancialService
    {
        private IFinancialRepository _financialRepository;
        public FinancialService(IFinancialRepository financialRepository)
        {
            _financialRepository = financialRepository;
        }

        public void Query(PageQuery<IDictionary<string, object>, Financial> pageQuery)
        {
            _financialRepository.Query(pageQuery);
        }
    }
}

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
    public class CompanyActionService : BaseRequestService<CompanyAction>, ICompanyActionService
    {
        private ICompanyActionRepository _companyActionRepository;
        public CompanyActionService(ICompanyActionRepository companyActionRepository)
        {
            _companyActionRepository = companyActionRepository;
        }
        public void Query(PageQuery<IDictionary<string, object>, CompanyAction> pageQuery)
        {
            this._companyActionRepository.Query(pageQuery);
        }
        public DataTable GetStatisticsData(Dictionary<string, object> dict)
        {
            return _companyActionRepository.GetStatisticsData(dict);
        }
    }
}

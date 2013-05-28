using System.Collections.Generic;
using WebCrm.Model;
using WebCrm.Model.Repositories;
using WebCrm.Model.Services;

namespace WebCrm.Service
{
    public class CompanyService : BaseRequestService<Company>, ICompanyService
    {
        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        
        private ICompanyRepository _companyRepository;

        public Company FindByCompanyName(string companyName)
        {
            return this._companyRepository.FindByCompanyName(companyName);
        }

        public IList<Company> GetComapnyList(string comanyName, int? parentId)
        {
            return _companyRepository.GetComapnyList(comanyName, parentId);
        }
    }
}

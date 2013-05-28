using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;

namespace WebCrm.Model.Repositories
{
    public interface ICompanyRepository : IBaseNhibreateRepository<Company>
    {
        Company FindByCompanyName(string companyName);
        IList<Company> GetComapnyList(string comanyName, int? parentId);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrm.Model.Services
{
    public interface ICompanyService : IBaseRequestService<Company>
    {
        Company FindByCompanyName(string companyName);
        /// <summary>
        /// parentId = 0 时 获取所有的顶级部门
        /// </summary>
        /// <param name="comanyName"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        IList<Company> GetComapnyList(string comanyName, int? parentId = null);
    }
}

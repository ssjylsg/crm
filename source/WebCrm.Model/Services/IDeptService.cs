using System.Collections.Generic;

namespace WebCrm.Model.Services
{
    public interface IDeptService : IBaseRequestService<Department>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        IEnumerable<Department> FindSubDept(Department parent);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isContaintDeleted"></param>
        /// <returns></returns>
        IEnumerable<Department> QueryAllDept(bool? isContaintDeleted);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="deptName"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        IList<Department> GetDeptServiceList(string deptName, int? parentId);

        IList<Department> GetDeptByCompany(Company company);
    }
}

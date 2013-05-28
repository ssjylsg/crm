using System;
using WebCrm.Framework.Repositories;

namespace WebCrm.Model.Repositories
{
    public interface IDepartmentRepository : IBaseNhibreateRepository<Department>
    {

        System.Collections.Generic.IList<Department> GetDeptServiceList(string deptName, int? parentId);

        System.Collections.Generic.IList<Department> GetDeptByCompany(Company company);
    }
}

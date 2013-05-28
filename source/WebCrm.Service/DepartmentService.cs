using System;
using System.Collections.Generic;
using System.Linq;
using WebCrm.Model;
using WebCrm.Model.Repositories;
using WebCrm.Model.Services;

namespace WebCrm.Service
{
    public class DepartmentService : BaseRequestService<Department>, IDeptService
    {
        private IDepartmentRepository _departmentRepository;
        
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public void SaveOrUpdate(Department department)
        {
            _departmentRepository.SaveOrUpdate(department);
        }

        public IEnumerable<Department> FindSubDept(Department parent)
        {
            return null;
        }

        public IEnumerable<Department> QueryAllDept(bool? isContaintDeleted)
        {
            if (!isContaintDeleted.HasValue)
            {
                return this._departmentRepository.FindAll();
            }
            return this._departmentRepository.FindAll().Where(m => m.Deleted == isContaintDeleted);
        }

        public IList<Department> GetDeptServiceList(string deptName, int? parentId)
        {
            return _departmentRepository.GetDeptServiceList(deptName, parentId);
        }

        public IList<Department> GetDeptByCompany(Company company)
        {
            return _departmentRepository.GetDeptByCompany(company);
        }
    }
}

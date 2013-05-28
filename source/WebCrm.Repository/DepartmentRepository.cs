using System;
using System.Collections.Generic;
using WebCrm.Framework.Repositories;
using WebCrm.Model;
using WebCrm.Model.Repositories;

namespace WebCrm.Dao
{
    public class DepartmentRepository : BaseNhibreateRepository<Department>, IDepartmentRepository
    {
        public IList<Department> GetDeptServiceList(string deptName, int? parentId)
        {
            string where = " Where Deleted != 1 ";

            if (parentId.HasValue)
            {
                if (parentId.Value == 0)
                {
                    where += "  AND ( Parent.Id IS NULL OR Parent.Id =0)";
                }
                else
                {
                    where += " AND Parent.Id = " + parentId.Value;
                }
            }

            if (!string.IsNullOrEmpty(deptName))
            {
                where += " And DeptName LIKE :deptName";
            }
            return
                this.GetSession().CreateQuery("From Department  " + where).StringLike("deptName", deptName).List<Department>();
        }

        public IList<Department> GetDeptByCompany(Company company)
        {
            if (company == null)
            {
                return
                this.GetSession().CreateQuery("From Department Where Deleted != 1 AND( Company Is Null Or  Company.Id = 0)").List<Department>();
            }
            else
            {
                return
                    this.GetSession().CreateQuery("From Department Where Deleted != 1 AND   Company.Id = " + company.Id).List<Department>();
            }
        }
    }
}

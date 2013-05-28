using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;
using WebCrm.Model;
using WebCrm.Model.Repositories;

namespace WebCrm.Dao
{
    public class CompanyRepository : BaseNhibreateRepository<Company>, ICompanyRepository
    {
        public Company FindByCompanyName(string companyName)
        {
            return
                this.GetSession().CreateQuery("FROM Company WHERE FullName =:companyName")
                .SetString("companyName", companyName)
                .UniqueResult<Company>();
        }

        public IList<Company> GetComapnyList(string comanyName, int? parentId)
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

            if (!string.IsNullOrEmpty(comanyName))
            {
                where += " And Name LIKE :comanyName";
            }
            return
                this.GetSession().CreateQuery("From Company  " + where).StringLike("comanyName", comanyName).List
                    <Company>();
        }
    }
}

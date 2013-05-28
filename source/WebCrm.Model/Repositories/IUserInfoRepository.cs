using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;
using System.Data;

namespace WebCrm.Model.Repositories
{
    public interface IUserInfoRepository : IBaseNhibreateRepository<OperatorUser>
    {
        OperatorUser FindByUserName(string userName);
        Staff FindStaffById(int id);

        void Query(PageQuery<IDictionary<string, object>, OperatorUser> pageQuery);
        void QueryStaff(PageQuery<IDictionary<string, object>, Staff> pageQuery);

        IList<Staff> GetNotOperater(OperatorUser operatorUser);
        DataTable GetByCondition(Dictionary<string, object> dict, string selectFields = "*");
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace WebCrm.Model.Services
{
    public interface IUserInfoService : IBaseRequestService<OperatorUser>
    {
        OperatorUser FindByUserName(string userName);
        /// <summary>
        /// 保存/修改 员工信息
        /// </summary>
        /// <param name="staff"></param>
        void SaveStaff(Staff staff);

        void UpdateStaff(Staff staff);
        /// <summary>
        /// 根据ID 查找员工信息
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        Staff FindStaffById(int p);

        void Query(PageQuery<IDictionary<string, object>, OperatorUser> pageQuery);

        bool ExistName(string name, int id);

        IList<OperatorUser> FindListByIds(int[] ids);

        void QueryStaff(PageQuery<IDictionary<string, object>, Staff> pageQuery);

        IList<Staff> GetNotOperater(OperatorUser operatorUser);

        /// <summary>
        /// 条件查询不分页
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        DataTable GetByCondition(Dictionary<string, object> dict, string selectFields = "*");

        void AddAdmin();
    }
}

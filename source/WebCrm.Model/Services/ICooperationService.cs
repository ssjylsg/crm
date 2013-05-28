using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace WebCrm.Model.Services
{
    /// <summary>
    /// 合作单位
    /// </summary>
    public interface ICooperationService : IBaseRequestService<Cooperation>
    {
        void Query(PageQuery<IDictionary<string, object>, Cooperation> pageQuery);

        /// <summary>
        /// 条件查询不分页
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        DataTable GetByCondition(Dictionary<string, object> dict, string selectFields = "*");
    }
}

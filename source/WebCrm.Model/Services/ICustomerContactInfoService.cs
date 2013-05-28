using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrm.Model.Services
{
    /// <summary>
    /// 客户联系人服务
    /// </summary>
    public interface ICustomerContactInfoService : IBaseRequestService<CustomerContactInfo>
    {
        void Query(PageQuery<IDictionary<string, object>, CustomerContactInfo> pageQuery);
        IList<CustomerContactInfo> FindByCustomerId(int customerId);
        /// <summary>
        /// 最近生日查询 使用SQL 其他地方勿用
        /// </summary>
        /// <param name="pageQuery"></param>
        void Query(PageQuery<QueryModel.CustomerContactQuery, CustomerContactInfo> pageQuery);
    }
}

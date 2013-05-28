using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace WebCrm.Model.Services
{
    public interface ICustomerService : IBaseRequestService<Customer>
    {

        void Query(PageQuery<IDictionary<string, object>, Customer> pageQuery);
        bool ExistName(string name, int id);

        string GetCustomerNo();
        DataTable GetStatisticsData(Dictionary<string, object> dict);

        DataTable GetByCondition(Dictionary<string, object> dict, string selectFields = "*");
        /// <summary>
        /// 删除一个客户，会自动删除联系人信息，扩展信息。洽谈记录、消费记录、回访记录，不做删除
        /// </summary>
        /// <param name="customer"></param>
        void DeleteCustomer(Customer customer);
    }
}

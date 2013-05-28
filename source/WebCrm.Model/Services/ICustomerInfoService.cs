using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrm.Model.Services
{
    public interface ICustomerInfoService : IBaseRequestService<CustomerInfo>
    {
        /// <summary>
        /// 获取散客的手机号码不为空的数据，准备发送短消息
        /// </summary>
        /// <returns></returns>
        IList<CustomerInfo> FindSendInfoCustomers();
        CustomerInfo FindByCustomerId(int id);
    }
}

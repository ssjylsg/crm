using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;
using WebCrm.Model;
using WebCrm.Model.Repositories;

namespace WebCrm.Dao
{
    public class CustomerInfoRepository : BaseNhibreateRepository<CustomerInfo>, ICustomerInfoRepository
    {
        public IList<CustomerInfo> FindSendInfoCustomers()
        {
            return
                this.GetSession().CreateQuery("From CustomerInfo Where ( Mobile Is Not Null) And Deleted != 1").List
                    <CustomerInfo>();
        }
    }
}

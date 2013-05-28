using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;
using WebCrm.Model;
using WebCrm.Model.QueryModel;
using WebCrm.Model.Repositories;

namespace WebCrm.Dao
{
    public class CustomerContactInfoRepository : BaseNhibreateRepository<CustomerContactInfo>, ICustomerContactInfoRepository
    {
        public void Query(PageQuery<IDictionary<string, object>, CustomerContactInfo> pageQuery)
        {
            StringBuilder stringBuilder = new StringBuilder("From CustomerContactInfo Where    Deleted != 1 ");
            foreach (var condition in pageQuery.Condition)
            {
                if (condition.Value == null)
                {
                    continue;
                }
                if (condition.Key == "Customer.Name")
                {
                    stringBuilder.StringLikeAppendHsql(condition.Key, condition.Value);
                }
                else
                {
                    stringBuilder.IntAppendHsql(condition.Key, condition.Value);
                }
            }
            pageQuery.Result = this.GetSession().CreateQuery(stringBuilder.ToString() + pageQuery.Order)
                .SetValue(pageQuery.Condition, "Customer.Name")
                .SetPagerInfo(pageQuery.Pager)
                .List<CustomerContactInfo>();

            pageQuery.RecordCount = this.GetSession().CreateQuery("Select Count(*) " + stringBuilder.ToString())
                .SetValue(pageQuery.Condition, "Customer.Name")
                .UniqueResult()
                .ObjectToInt();
        }

        public void Query(PageQuery<CustomerContactQuery, CustomerContactInfo> pageQuery)
        {
            StringBuilder stringBuilder =
                new StringBuilder(string.Format("FROM {0} T",
                                                NHibernateDatabaseFactory.TableName(typeof(CustomerContactInfo))));
            if (pageQuery.Condition != null)
            {
                var companyId = pageQuery.OperatorUser != null && pageQuery.OperatorUser.Company != null
                                    ? pageQuery.OperatorUser.Company.Id
                                    : 0;
                stringBuilder.AppendFormat(" INNER JOIN CRM_CUSTOMER C ON  C.COMPANY = {0} ", companyId).AppendLine();

                if (pageQuery.Condition.BussinessPerson != null)
                {
                    stringBuilder.AppendLine(" AND C.ID = T.CUSTOMERID").AppendLine();
                }
                stringBuilder.AppendLine(" WHERE 1=1 ");
                if (pageQuery.Condition.EndBirthday.HasValue)
                {
                    stringBuilder.AppendFormat(
                        @" And  (to_char(t.BIRTHDAY,'mm-dd') >= '{0}')
                          And  (to_char(t.BIRTHDAY,'mm-dd') <= '{1}')",
                        pageQuery.Condition.EndBirthday.Value.ToString("MM-dd"), DateTime.Now.ToString("MM-dd")).
                        AppendLine();
                }
                if (pageQuery.Condition.BussinessPerson != null)
                {
                    stringBuilder.AppendLine(string.Format(" And C.BELONGPERSON = {0}",
                                                           pageQuery.Condition.BussinessPerson.Id));
                }

            }

            pageQuery.Result = this.GetSession()
                .CreateSQLQuery("SELECT  T.* " + stringBuilder.ToString())
                .AddEntity("T", typeof(CustomerContactInfo))
                .SetPagerInfo(pageQuery.Pager)
                .List<CustomerContactInfo>();

            pageQuery.RecordCount =
                this.GetSession().CreateSQLQuery("Select Count(*) " + stringBuilder.ToString())
                    .UniqueResult()
                    .ObjectToInt();

        }
    }
}

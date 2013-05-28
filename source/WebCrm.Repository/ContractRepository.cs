using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;
using WebCrm.Model;
using WebCrm.Model.Repositories;

namespace WebCrm.Dao
{
    public class ContractRepository : BaseNhibreateRepository<Contract>, IContractRepository
    {
        public void Query(PageQuery<IDictionary<string, object>, Contract> pageQuery)
        {
            StringBuilder stringBuilder = new StringBuilder("From Contract Where    Deleted != 1 ");

            string contractName = string.Empty;
            foreach (var condition in pageQuery.Condition)
            {
                if (condition.Value == null)
                {
                    continue;
                }
                if (condition.Key == "ContractName")
                {
                    contractName = (condition.Value ?? "").ToString();
                    stringBuilder.StringLikeAppendHsql(condition.Key, condition.Value);
                }
                else if (condition.Key == "startDate")
                {
                    stringBuilder.AppendFormat(" And  SignDate >=to_date('{0}','yyyy-mm-dd')", condition.Value).AppendLine();
                }
                else if (condition.Key == "endDate")
                {
                    stringBuilder.AppendFormat(" And  SignDate <=to_date('{0}','yyyy-mm-dd')", condition.Value).AppendLine();
                }
                else
                {
                    stringBuilder.AppendFormat(" And  {0} = {1}", condition.Key, condition.Value).AppendLine();
                }
            }
            if (pageQuery.OperatorUser != null && pageQuery.OperatorUser.Company != null)
            {
                stringBuilder.AppendFormat(" AND Company.Id = {0}", pageQuery.OperatorUser.Company.Id);
            }
            pageQuery.Result = this.GetSession().CreateQuery(stringBuilder.ToString() + pageQuery.Order)
                .StringEqual("ContractName", contractName)
                .SetPagerInfo(pageQuery.Pager)
                .List<Contract>();

            pageQuery.RecordCount =
                this.GetSession().CreateQuery("Select Count(*) " + stringBuilder.ToString())
                .StringEqual("ContractName", contractName)
                .UniqueResult()
                .ObjectToInt();

        }
    }
}

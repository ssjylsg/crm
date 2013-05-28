using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;
using WebCrm.Model;
using WebCrm.Model.Repositories;

namespace WebCrm.Dao
{
    public class UserInfoRepository : BaseNhibreateRepository<OperatorUser>, IUserInfoRepository
    {
        public OperatorUser FindByUserName(string userName)
        {
            return
                this.GetSession().CreateQuery("From OperatorUser Where OperatorCode =:userName  AND  Deleted != 1")
                .SetString("userName", userName)
                .List<OperatorUser>().ToList()
                .FirstOrDefault();
        }

        public Staff FindStaffById(int id)
        {
            return this.GetSession().Get<Staff>(id);
        }

        public void Query(PageQuery<IDictionary<string, object>, OperatorUser> pageQuery)
        {
            StringBuilder stringBuilder = new StringBuilder("From OperatorUser Where    Deleted != 1 ");
            foreach (var condition in pageQuery.Condition)
            {

                if (condition.Value == null)
                {
                    continue;
                }
                if (condition.Key == "OperatorName")
                {
                    stringBuilder.StringLikeAppendHsql(condition.Key, condition.Value);
                }
                else
                {
                    stringBuilder.IntAppendHsql(condition.Key, condition.Value);
                }
            }
            if (pageQuery.OperatorUser != null && pageQuery.OperatorUser.Company != null)
            {
                stringBuilder.AppendFormat(" AND Company.Id = {0}", pageQuery.OperatorUser.Company.Id);
            }
            stringBuilder.AppendFormat(" And IsCrm = 1 Order  By CreateTime Desc ");
            pageQuery.Result = this.GetSession().CreateQuery(stringBuilder.ToString())
                .SetValue(pageQuery.Condition, "OperatorName")
                .SetPagerInfo(pageQuery.Pager)
                .List<OperatorUser>();

            pageQuery.RecordCount =
                this.GetSession().CreateQuery("Select Count(*) " + stringBuilder.ToString()).SetValue(
                    pageQuery.Condition, "CustoMerName").UniqueResult().ObjectToInt();

        }

        public void QueryStaff(PageQuery<IDictionary<string, object>, Staff> pageQuery)
        {
            StringBuilder stringBuilder = new StringBuilder("From Staff Where    Deleted != 1 ");
            foreach (var condition in pageQuery.Condition)
            {
                if (condition.Value == null)
                {
                    continue;
                }
                if (condition.Key == "OperatorName")
                {
                    stringBuilder.StringLikeAppendHsql(condition.Key, condition.Value);
                }
                else
                {
                    stringBuilder.IntAppendHsql(condition.Key, condition.Value);
                }
            }
            pageQuery.Result = this.GetSession().CreateQuery(stringBuilder.ToString())
              .SetValue(pageQuery.Condition, "OperatorName")
                .SetPagerInfo(pageQuery.Pager)
                .List<Staff>();

            pageQuery.RecordCount = this.GetSession().CreateQuery("Select Count(*) " + stringBuilder.ToString())
                .SetValue(pageQuery.Condition, "OperatorName")
                .UniqueResult().ObjectToInt();

        }

        public IList<Staff> GetNotOperater(OperatorUser operatorUser)
        {
            StringBuilder stringBuilder =
                new StringBuilder(
                    @"SELECT H.* FROM HR_RS_Staff H  LEFT JOIN SYS_OPERATOR P ON H.ID = P.ID AND P.COMPANYID = H.COMPANYID
WHERE P.ID IS NULL ");
            if (operatorUser != null && operatorUser.Company != null)
            {
                stringBuilder.AppendFormat(" AND H.COMPANYID = {0}", operatorUser.Company.Id);
            }
            return
                this.GetSession().CreateSQLQuery(stringBuilder.ToString()).AddEntity("H", typeof(Staff)).List<Staff>();
        }

        /// <summary>
        /// 条件查询不分页
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="selectFields"></param>
        /// <returns></returns>
        public DataTable GetByCondition(Dictionary<string, object> dict, string selectFields = "*")
        {
            StringBuilder stringBuilder = new StringBuilder("select " + selectFields + " From Sys_Operator Where    Deleted != 1 ");
            foreach (var condition in dict)
            {
                if (condition.Key == "OperatorName")
                {
                    stringBuilder.AppendFormat(" And  {0} LIKE '%{1}%'", condition.Key, condition.Value).AppendLine();
                }
                else
                {
                    stringBuilder.AppendFormat(" And  {0} = '{1}'", condition.Key, condition.Value).AppendLine();
                }
            }
            return NHelper.ExecuteDataSet(stringBuilder.ToString()).Tables[0];
        }
    }
}

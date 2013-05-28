using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Model;
using WebCrm.Framework.Repositories;
using WebCrm.Model;
using WebCrm.Model.Repositories;

namespace WebCrm.Dao
{
    public class CommonRepository : BaseNhibreateRepository<WebCrm.Framework.Model.BaseEntity>, ICommonRepository
    {
        public void SaveNewProcHist(string oprComment, BaseEntity entity, OperatorUser oprOperatorUser, string oprAction, string stageDesc)
        {
            OprHist oprHist = new OprHist();
            oprHist.OprAction = oprAction;
            oprHist.OprComment = oprComment;
            oprHist.OprDateTime = DateTime.Now;
            oprHist.OprUser = oprOperatorUser;
            oprHist.OprUsername = oprOperatorUser.OperatorName;
            oprHist.StageDesc = stageDesc;
            oprHist.RequestId = entity.Id;
            oprHist.RequestType = entity.GetType().FullName;
            this.SaveOrUpdate(oprHist);
        }

        public IList<OprHist> OprHistInfoList<T1>(int requestId)
        {
            var requestType = NHibernateDatabaseFactory.TableName(typeof(T1));
            return
                this.GetSession().CreateQuery(string.Format(
                    "From OprHist Where RequestType = '{0}' And RequestId = {1} Order By OprDateTime  ", requestType,
                    requestId)).List<OprHist>();
        }

        
    }
}

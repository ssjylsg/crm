using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Model;

namespace WebCrm.Model.Repositories
{
    public interface ICommonRepository
    {
        void SaveNewProcHist(string oprComment, BaseEntity crmEntity, OperatorUser oprOperatorUser, string oprAction, string stageDesc);
        void Save(BaseEntity entity);

        void Update(BaseEntity entity);

        T FindById<T>(int id);

        IList<OprHist> OprHistInfoList<T1>(int requestId);
        
    }
}

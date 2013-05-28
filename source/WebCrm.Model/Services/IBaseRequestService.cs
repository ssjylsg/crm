using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Model;

namespace WebCrm.Model.Services
{
    public interface IBaseRequestService<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// 保存操作历史
        /// </summary>
        /// <param name="oprComment"></param>
        /// <param name="crmEntity"></param>
        /// <param name="oprOperatorUser"></param>
        /// <param name="oprAction"></param>
        /// <param name="stageDesc"></param>
        void SaveNewProcHist(string oprComment, BaseEntity crmEntity, OperatorUser oprOperatorUser, string oprAction, string stageDesc);
        /// <summary>
        /// 保存对象
        /// </summary>
        /// <param name="entity"></param>
        void Save(TEntity entity);
        /// <summary>
        /// 更新对象
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);
        /// <summary>
        /// 根据ID查找对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity FindById(int id);

        IList<OprHist> OprHistInfoList<T>(int requestId);
    }
}

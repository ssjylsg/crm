using System.Collections.Generic;
using WebCrm.Framework.Model;
using WebCrm.Model;
using WebCrm.Model.Repositories;
using WebCrm.Model.Services;

namespace WebCrm.Service
{
    public abstract class BaseRequestService<T> : IBaseRequestService<T> where T : BaseEntity
    {
        protected ICommonRepository _commonRepository;

        protected BaseRequestService()
            : this(WebCrm.Framework.DependencyResolver.Resolver<ICommonRepository>())
        {

        }

        protected BaseRequestService(ICommonRepository commonRepository)
        {
            _commonRepository = commonRepository;
        }

        public void SaveNewProcHist(string oprComment, BaseEntity crmEntity, OperatorUser oprOperatorUser, string oprAction, string stageDesc)
        {
            this._commonRepository.SaveNewProcHist(oprComment, crmEntity, oprOperatorUser, oprAction, stageDesc);
        }

        public T FindById(int id)
        {
            return _commonRepository.FindById<T>(id);
        }

        public IList<OprHist> OprHistInfoList<T1>(int requestId)
        {
            return this._commonRepository.OprHistInfoList<T>(requestId);
        }

        public void Save(T entity)
        {
            this._commonRepository.Save(entity);
        }

        public void Update(T entity)
        {
            this._commonRepository.Update(entity);
        }
    }
}

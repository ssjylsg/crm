using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using WebCrm.Framework.Model;

namespace WebCrm.Framework.Repositories
{
    public interface INhibreateRepository<TEntity, TKey> where TEntity : BaseEntity
    {
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
        /// 保存或修改对象
        /// </summary>
        /// <param name="entity"></param>
        void SaveOrUpdate(TEntity entity);
        /// <summary>
        /// 根据ID 查找
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity FindByKey(TKey id);
        void Delete(TEntity entity);
        IEnumerable<TEntity> FindAll();
        TEntity GetObjectByDescription(IDictionary ht);
        IEnumerable<T> GetByIds<T>(int[] ids);
        IQuery GetNamedQuery(string queryName);

        ITransaction BeginTransaction();

        void CommitTransaction();

        void RollbackTransaction();

        ITransaction Transaction { get; }

        bool HasOpenTransaction { get; }

        bool IsOpen { get; }

        IEnumerable<TEntity> Query(string queryString,int maxRecord = int.MaxValue);

        
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="entity"></param>
        void SaveObject<T>(T entity) where T : BaseEntity;

        T FindById<T>(TKey id);
        /// <summary>
        /// 序号产生
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        int GenerateNewId(string keyName, int defaultValue = 1);
    }
    public interface IBaseNhibreateRepository<TEntity> : INhibreateRepository<TEntity, int> where TEntity : BaseEntity
    {

    }
}

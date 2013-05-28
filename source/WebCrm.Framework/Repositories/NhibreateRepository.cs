using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using NHibernate;
using NHibernate.Criterion;
using WebCrm.Framework.Model;

namespace WebCrm.Framework.Repositories
{
    public abstract class NhibreateRepository<TEntity, TKey> : INhibreateRepository<TEntity, TKey> where TEntity : BaseEntity
    {
        private IGenerateNewId _generateNewId;
        public NhibreateRepository(IGenerateNewId generateNewId)
        {
            _generateNewId = generateNewId;
        }
        protected NhibreateRepository()
        {

        }
        public ISession GetSession()
        {
            ISession session = NHibernateDatabaseFactory.GetSession();
            if (!session.IsConnected)
            {
                session.Reconnect();
            }
            return session;
        }

        public void Save(TEntity entity)
        {
            if (entity.Id.GetType() == typeof(int) && entity.Id == 0)
            {
                entity.SetId(GenerateNewId(NHibernateDatabaseFactory.TableName(entity.GetType())));
            }
            ISession session = GetSession();
            session.Save(entity);
            session.Flush();
        }

        public void Update(TEntity entity)
        {
            GetSession().Update(entity);
            GetSession().Flush();
        }

        public void SaveOrUpdate(TEntity entity)
        {
            if (entity.Id.GetType() == typeof(int) && entity.Id == 0)
            {
                this.Save(entity);
            }
            else
            {
                this.Update(entity);
            }
        }

        public TEntity FindByKey(TKey id)
        {
            return this.GetSession().Get<TEntity>(id);
        }
        public T FindById<T>(TKey id)
        {
            return this.GetSession().Get<T>(id);
        }
        public void Delete(TEntity entity)
        {
            SaveOrUpdate(entity);
        }

        public IEnumerable<TEntity> FindAll()
        {
            return this.GetSession().CreateCriteria(typeof(TEntity)).List<TEntity>();
        }

        public TEntity GetObjectByDescription(IDictionary ht)
        {
            ICriteria crit = this.GetSession().CreateCriteria(typeof(TEntity));
            foreach (DictionaryEntry entry in ht)
            {
                crit.Add(Expression.Eq(entry.Key.ToString(), entry.Value));
            }
            return crit.UniqueResult() as TEntity;

        }
        public IEnumerable<T> GetByIds<T>(int[] ids)
        {
            ISession session = this.GetSession();
            return session.CreateCriteria(typeof(T)).Add(Expression.In("Id", ids)).List<T>();
        }

        public IQuery GetNamedQuery(string queryName)
        {
            return GetSession().GetNamedQuery(queryName);
        }

        public ITransaction BeginTransaction()
        {
            if (Transaction == null)
                Transaction = this.GetSession().BeginTransaction();

            return Transaction;
        }

        public void CommitTransaction()
        {
            if (Transaction == null)
                return;

            try
            {
                Transaction.Commit();
                Transaction.Dispose();
                Transaction = null;
            }
            catch (HibernateException)
            {
                RollbackTransaction();
                throw;
            }
        }

        public void RollbackTransaction()
        {

            if (Transaction == null)
                return;

            Transaction.Rollback();
            Transaction.Dispose();
            Transaction = null;
        }

        public ITransaction Transaction { get; protected set; }

        public bool HasOpenTransaction
        {
            get { return Transaction != null; }
        }

        public bool IsOpen
        {
            get { return this.GetSession().IsOpen; }
        }

        public IEnumerable<TEntity> Query(string queryString, int maxRecord = int.MaxValue)
        {
            if (maxRecord != int.MaxValue)
            {
                return this.GetSession().CreateQuery(queryString).Enumerable<TEntity>();
            }
            else
            {
                return this.GetSession().CreateQuery(queryString).SetMaxResults(maxRecord).Enumerable<TEntity>();
            }
        }


        public void SaveObject<T>(T entity) where T : BaseEntity
        {
            if (entity.Id.GetType() == typeof(int) && entity.Id == 0)
            {
                entity.SetId(GenerateNewId(NHibernateDatabaseFactory.TableName<T>()));
            }
            GetSession().Save(entity);
            GetSession().Flush();
        }
        public IDbCommand CreateCommand()
        {
            var session = this.GetSession();
            var command = session.Connection.CreateCommand();

            return command;
        }
        public int GenerateNewId(string keyName, int defaultValue = 1)
        {
            int value = 0;
            Guid guid = Guid.NewGuid();


            var sqlConnection = this.GetSession().Connection;
            {
                if (sqlConnection.State != ConnectionState.Open)
                    sqlConnection.Open();
                using (var command = sqlConnection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;

                    for (int i = 0; i < 3; i++)
                    {
                        command.CommandText =
                            (string.Format("select MaxRecID from Sys_MaxRecId where TableName ='{0}'", keyName));
                        value = int.Parse((command.ExecuteScalar() ?? "0").ToString());
                        if (value <= 0)
                        {
                            value = defaultValue;
                            command.CommandText =
                                string.Format(
                                    "insert into Sys_MaxRecId(TableName,MaxRecID,Remark) values('{0}', {1}, '{2}')",
                                    keyName, defaultValue, guid);
                            command.ExecuteNonQuery();
                        }
                        else
                        {
                            value += 1;
                            command.CommandText =
                                (string.Format(
                                    "update Sys_MaxRecId set MaxRecID = MaxRecID  + 1, Remark = '{0}' where  TableName  =  '{1}'",
                                    guid, keyName));
                            command.ExecuteNonQuery();
                        }
                        command.CommandText =
                            (string.Format("select Remark from Sys_MaxRecId where TableName ='{0}'",
                                           keyName));
                        if ((command.ExecuteScalar() ?? Guid.Empty).ToString() == guid.ToString())
                        {
                            break;
                        }
                    }
                    return value;
                }
            }


        }
    }
    public abstract class BaseNhibreateRepository<TEntity> : NhibreateRepository<TEntity, int> where TEntity : BaseEntity
    {

    }
}

using System;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using NHibernate.Criterion;
namespace WebCX.DAL
{
    public class EntityControl
    {
        private static EntityControl entity;
        private string _AssemblyName;
        static readonly object padlock = new object();

        public static EntityControl CreateEntityControl(string AssemblyName)
        {
            if (entity == null)
            {
                lock (padlock)
                {
                    if (entity == null)
                    {
                        entity = new EntityControl();
                        entity._AssemblyName = AssemblyName;
                    }
                }
            }
            return entity;
        }

        public void SaveOrUpdate(Object entity)
        {
            ISession session = SessionFactory.OpenSession(_AssemblyName);
            ITransaction transaction = session.BeginTransaction();
            try
            {
                session.SaveOrUpdate(entity);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                session.Close();
            }
        }

        public void Delete(object entity)
        {
            ISession session = SessionFactory.OpenSession(_AssemblyName);
            ITransaction transaction = session.BeginTransaction();

            try
            {
                session.Delete(entity);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                session.Close();
            }
        }

        public Object GetEntity(string table, string idFieldName, int id)
        {
            Object obj;
            string query = "From " + table + " Where " + idFieldName + " = " + id + "";
            ISession session = SessionFactory.OpenSession(_AssemblyName);

            obj = session.CreateQuery(query).UniqueResult();

            session.Close();

            return obj;
        }
        public object GetEntityByWhere(string table, string where)
        {
            Object obj = null;
            string query = "From " + table;
            if (!String.IsNullOrEmpty(where) && where != "")
            {
                query += " where " + where;
            }
            ISession session = SessionFactory.OpenSession(_AssemblyName);
            IList list = session.CreateQuery(query).List();
            if (list.Count > 0)
            {
                obj = list[0];
            }
            session.Close();
            return obj;
        }
        /// <summary>
        /// 单表分页一
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="table"></param>
        /// <param name="where"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public IList<T> GetEntitesPage<T>(int pageIndex, int pageSize, string table, string where, string orderBy)
        {
            string query = "From " + table;
            if (!String.IsNullOrEmpty(where) && where != "")
            {
                query += " Where " + where;
            }
            if (!String.IsNullOrEmpty(orderBy) && orderBy != "")
            {
                query += " Order By " + orderBy;
            }

            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            if (pageSize < 1)
            {
                pageSize = 1;
            }

            IList<T> lst;

            ISession session = SessionFactory.OpenSession(_AssemblyName);

            lst = session.CreateQuery(query).SetFirstResult(pageSize * (pageIndex - 1)).SetMaxResults(pageSize).List<T>();

            session.Close();

            return lst;
        }
        public string GetPageSet(int pageIndex, int pageSize, string tableName, string where, string urlFormat, int mode)
        {
            ISession session = SessionFactory.OpenSession(_AssemblyName);
            int recordCount = DirectRun.GetRecordCount(session, tableName, where);
            session.Close();
            return SplitPage.GetPageSet(pageIndex, pageSize, recordCount, urlFormat, mode);
        }
        /// <summary>
        /// 多表分页二
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="hql"></param>
        /// <param name="where"></param>
        /// <param name="urlFormat"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public string GetManyPageSet(string query, string where, int pageIndex, int pageSize, string urlFormat, int mode)
        {
            ISession session = SessionFactory.OpenSession(_AssemblyName);
            if (!String.IsNullOrEmpty(where) && where != "")
            {
                query += " Where " + where;
            }
            IQuery q = SessionFactory.OpenSession(_AssemblyName).CreateQuery(query);
            int recordCount = q.List().Count;
            session.Close();

            return SplitPage.GetPageSet(pageIndex, pageSize, recordCount, urlFormat, mode);
        }
        public IList GetManyTablePage(string query, string where, string orderBy, int pageIndex, int pageSize, string table)
        {

            if (!String.IsNullOrEmpty(where) && where != "")
            {
                query += " Where " + where;
            }
            if (!String.IsNullOrEmpty(orderBy) && orderBy != "")
            {
                query += " Order By " + orderBy;
            }

            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            if (pageSize < 1)
            {
                pageSize = 1;
            }

            IList lst;

            ISession session = SessionFactory.OpenSession(_AssemblyName);

            lst = session.CreateQuery(query).SetFirstResult(pageSize * (pageIndex - 1)).SetMaxResults(pageSize).List();

            session.Close();

            return lst;
        }


        public IList GetDataByQuery(string query)
        {

            IList lst;

            ISession session = SessionFactory.OpenSession(_AssemblyName);

            lst = session.CreateQuery(query).List();

            session.Close();

            return lst;
        }
        public IList<T> GetEntities<T>(string table, string where, string orderBy)
        {
            string query = "from " + table;
            if (!String.IsNullOrEmpty(where) && where != "")
            {
                query += " where " + where;
            }
            if (!String.IsNullOrEmpty(orderBy) && orderBy != "")
            {
                query += " order By " + orderBy;
            }

            IList<T> lst;
            ISession session = SessionFactory.OpenSession(_AssemblyName);
            lst = session.CreateQuery(query).List<T>();
            session.Close();
            return lst;
        }
        public object GetObjectById(Type type, int id)
        {
            using (ISession session = SessionFactory.OpenSession(_AssemblyName))
            {
                return session.Load(type, id);
            }
        }

        public object GetObjectById(Type type, int id, bool allowNull)
        {
            if (!allowNull)
            {
                return GetObjectById(type, id);
            }
            else
            {
                using (ISession session = SessionFactory.OpenSession(_AssemblyName))
                {
                    return session.Get(type, id);
                }
            }
        }

        public T GetObjectById<T>(int id)
        {
            using (ISession session = SessionFactory.OpenSession(_AssemblyName))
            {
                return session.Get<T>(id);
            }
        }

        public object GetObjectByDescription(Type type, string propertyName, string description)
        {
            object obj;
            using (ISession session = SessionFactory.OpenSession(_AssemblyName))
            {
                ICriteria crit = session.CreateCriteria(type);
                crit.Add(Expression.Eq(propertyName, description));
                obj = crit.UniqueResult();
                session.Close();
                return obj;
            }
        }
        public object GetObjectByDescription(Type type, Hashtable ht)
        {
            object obj;
            using (ISession session = SessionFactory.OpenSession(_AssemblyName))
            {
                ICriteria crit = session.CreateCriteria(type);
                IDictionaryEnumerator e = ht.GetEnumerator();
                while (e.MoveNext())
                {
                    crit.Add(Expression.Eq(e.Key.ToString(), e.Value));
                }
                obj = crit.UniqueResult();
                session.Close();
                return obj;
            }
        }
        public IList GetAll(Type type)
        {
            return GetAll(type, null);
        }

        public IList GetAll(Type type, params string[] sortProperties)
        {
            using (ISession session = SessionFactory.OpenSession(_AssemblyName))
            {

                ICriteria crit = session.CreateCriteria(type);
                if (sortProperties != null)
                {
                    foreach (string sortProperty in sortProperties)
                    {
                        crit.AddOrder(Order.Asc(sortProperty));
                    }
                }
                return crit.List();
            }
        }

        /// <summary>
        /// Get all objects of T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IList<T> GetAll<T>()
        {
            return GetAll<T>(null);
        }

        /// <summary>
        /// Get all objects of T.
        /// </summary>
        /// <param name="sortProperties"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IList<T> GetAll<T>(params string[] sortProperties)
        {
            using (ISession session = SessionFactory.OpenSession(_AssemblyName))
            {

                ICriteria crit = session.CreateCriteria(typeof(T));
                if (sortProperties != null)
                {
                    foreach (string sortProperty in sortProperties)
                    {
                        crit.AddOrder(Order.Asc(sortProperty));
                    }
                }
                return crit.List<T>();
            }
        }

        /// <summary>
        /// Get all objects of T that match the given criteria.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="criteria">NHibernate DetachedCriteria instance.</param>
        /// <returns></returns>
        /// <remarks>
        /// Be careful to not use this one from the UI layer beacuse it ties the UI to NHibernate.
        /// </remarks>
        public IList<T> GetAllByCriteria<T>(DetachedCriteria criteria)
        {
            using (ISession session = SessionFactory.OpenSession(_AssemblyName))
            {
                ICriteria crit = criteria.GetExecutableCriteria(session);
                return crit.List<T>();
            }
        }

        /// <summary>
        /// Get all objects of T for the given id's.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ids"></param>
        /// <returns></returns>
        public IList<T> GetByIds<T>(int[] ids)
        {
            ISession session = SessionFactory.OpenSession(_AssemblyName);
            ICriteria crit = session.CreateCriteria(typeof(T))
                .Add(Expression.In("Id", ids));
            return crit.List<T>();
        }

        public int ExecuteNonQuery(string sqlString)
        {
            ISession session = SessionFactory.OpenSession(_AssemblyName);
            int num = DirectRun.ExecuteNonQuery(session, sqlString);
            session.Close();
            return num;
        }

    }
}

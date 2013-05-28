using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace WebCX.DAL
{
    public class DALBase<T> where T : class
    {
        public EntityControl control;
        public string TableName = string.Empty;

        public DALBase()
        {
            //control = EntityControl.CreateEntityControl("WebCX.Model");
            control = EntityControl.CreateEntityControl(Common.NHelper.AssemblyName);
        }

        public void SaveOrUpdate(T model)
        {
            control.SaveOrUpdate(model);
        }

        public void Delete(T model)
        {
            control.Delete(model);
        }

        public T GetModel(int id)
        {
            return control.GetEntity(TableName, "ID", id) as T;
        }

        public T GetEntityByWhere(string where)
        {
            return control.GetEntityByWhere(TableName, where) as T;
        }

        public IList<T> GetAllList(string condition = "", string orderBy = "")
        {
            return control.GetEntities<T>(TableName, condition, orderBy);
        }

        public IList<T> GetPageList(int pageIndex, int pageSize, string condition = "", string orderBy = "")
        {
            return control.GetEntitesPage<T>(pageIndex, pageSize, TableName, condition, orderBy) as IList<T>;
        }
    }
}

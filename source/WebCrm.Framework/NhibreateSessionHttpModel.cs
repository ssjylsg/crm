using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using NHibernate;
using WebCrm.Framework.Repositories;

namespace WebCrm.Framework
{
    public class NhibreateSessionHttpModel : System.Web.IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
            context.EndRequest += new EventHandler(context_EndRequest);
            context.Error += new EventHandler(context_Error);
        }

        void context_Error(object sender, EventArgs e)
        {

        }

        void context_EndRequest(object sender, EventArgs e)
        {
            ISession session = NHibernate.Context.CurrentSessionContext.Unbind(NHibernateDatabaseFactory.SessionFactory);
            if (session != null && session.IsConnected)
            {

                try
                {
                    session.Flush();
                    if (session.Transaction != null && session.Transaction.IsActive)
                    {
                        session.Transaction.Commit();
                    }
                }
                catch (Exception)
                {
                    if (session.Transaction != null && session.Transaction.IsActive)
                    {
                        session.Transaction.Rollback();
                    }
                    throw;
                }
                try
                {
                    if (session.IsConnected)
                    {
                        session.Close();
                    }
                    session.Dispose();
                }
                catch (Exception ex)
                {
                    log4net.LogManager.GetLogger(this.GetType()).Error(ex);
                    throw;
                }
            }
        }


        void context_BeginRequest(object sender, EventArgs e)
        {
            var session = NHibernateDatabaseFactory.SessionFactory.OpenSession();
            //session.BeginTransaction(); TODO: 是否在此启用事物
            NHibernate.Context.CurrentSessionContext.Bind(session);
        }

        public void Dispose()
        {

        }
    }
}

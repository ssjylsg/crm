using System;
using System.Data;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace WebCX.DAL
{
    //SessionFactory (NHibernate.ISessionFactory)�����ڵ�һ���ݿ�ı������ӳ���ļ���һ���̰߳�ȫ�ģ����ɱ�Ļ�����ա�
    //����Session�Ĺ�������ConnectionProvider�Ŀͻ���
    public class SessionFactory
    {
        public SessionFactory() { }

        private static ISessionFactory sessions;
        /// NHibernate.Cfg.Configuration��һ��ʵ��������Ӧ�ó��������е�.NET�ൽSQL���ݿ��ӳ��ļ��ϡ�
        /// Configuration���ڹ���һ��(���ɱ��)ISessionFactory��
        /// ��Щӳ���Ǵ�һЩXMLӳ���ļ��б�������ġ� 
        private static Configuration cfg;
        static readonly object padlock = new object();

        /// <summary>
        /// ����һ�����ݿ����ӣ����Ҵ�һ��ISession
        /// </summary>
        /// <param name="AssemblyName">��������</param>
        /// <returns></returns>
        public static ISession OpenSession(string AssemblyName)
        {
            if (sessions == null)
            {
                lock (padlock)
                {
                    if (sessions == null)
                    {
                        BuildSessionFactory(AssemblyName);
                    }
                }
            }

            return sessions.OpenSession();
        }

        /// <summary>
        /*--------------------------------------------------
                �����е�ӳ�䶼��Configuration����֮��
           Ӧ�ó���Ϊ�˵õ�ISessionʵ���������ȵõ����Ĺ�����
           �������Ӧ���Ǳ�Ӧ�ó���������̹߳���ģ�
         ---------------------------------------------------*/
        /// </summary>
        /// <param name="AssemblyName"></param>
        private static void BuildSessionFactory(string AssemblyName)
        {
            cfg = new Configuration();
            ////AddAssembly��NHibernate��ȡһ�����������е������ļ�
            //cfg.AddAssembly(AssemblyName);
            ////����Session�Ĺ�������ISessionFactory
            //sessions = cfg.BuildSessionFactory();

            sessions = cfg.Configure().BuildSessionFactory();
        }
        //�������ݿ�
        public static void CreateDataBase(string AssemblyName)
        {
            cfg = new Configuration();
            cfg.AddAssembly(AssemblyName);
            SchemaExport sch = new SchemaExport(cfg);
            sch.Create(true, true);
        }
    }
}

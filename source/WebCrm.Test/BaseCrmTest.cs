using System;
using System.IO;
using System.Reflection;
using Autofac;
using NUnit.Framework;
using WebCrm.Framework;
using WebCrm.Framework.Repositories;

namespace WebCrm.Test
{
    /// <summary>
    /// BaseCrmTest 的摘要说明
    /// </summary>
    [TestFixture]
    public class BaseCrmTest
    {

        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，该上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        private log4net.ILog _log;
        #region 附加测试特性
        //
        // 编写测试时，可以使用以下附加特性:
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在运行每个测试之前，使用 TestInitialize 来运行代码
        [SetUp]
        public virtual void MyTestInitialize()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config");

            ApplicationConfig.Intance.Init(o => o.RegisterType<OracleGenerateNewId>().As<IGenerateNewId>(),
                                           new Assembly[]
                                               {
                                                   Assembly.Load("WebCrm.Model"), Assembly.Load("WebCrm.Service"),
                                                   Assembly.Load("WebCrm.Dao"),Assembly.Load("WebCrm.Framework")
                                               }).Log4net(path);

            _log = log4net.LogManager.GetLogger(this.GetType());

            Assert.IsNotNull(DependencyResolver.Resolver<IGenerateNewId>());
            this.Log(DependencyResolver.Resolver<IGenerateNewId>().GetType().FullName);


            this.Log(path);
        }

        //在每个测试运行完之后，使用 TestCleanup 来运行代码
        [TestFixtureTearDown()]
        public virtual void MyTestCleanup()
        {


        }

        #endregion


        protected void Log(object message)
        {
            System.Diagnostics.Trace.WriteLine(message);
            _log.Info(message);
        }
        [Test]
        public void TestLog()
        {

            this.Log(string.Format("{0,6}", 123));
            this.Log(System.DateTime.Now);
        }
        [Test]
        public void TestTableName()
        {
            this.Log(NHibernateDatabaseFactory.TableName<WebCrm.Model.CategoryItem>());
        }
        [Test]
        public void ToTitleCase()
        {
            this.Log(System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase("CREATETIME"));
        }
    }
}

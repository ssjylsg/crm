using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrm.Test
{
    class Program
    {
        /// <summary>
        /// 执行数据初始化
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("正在初始化数据");
            try
            {
                var test = new WebCrm.Test.CrmTest1();

                test.MyTestInitialize();
                test.SayHello();

                System.Console.WriteLine("正在导入功能模块");
                test.FunctionInsert();

                //System.Console.WriteLine("正在导入数据分类模块");
                //test.AddCategory();

                System.Console.WriteLine("正在导入管理员");
                test.AddAdmin();


                System.Console.WriteLine("正在增加系统管理员角色");
                test.AddRoleAdmin();


                System.Console.WriteLine("正在给管理员分配角色");
                test.GrantFunToRole();

                System.Console.WriteLine("正在初始化数据字典");
                test.CrmDictoryTest();

                System.Console.WriteLine("初始化完成");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            System.Console.Read();
        }
    }
}

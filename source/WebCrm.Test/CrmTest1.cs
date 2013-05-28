using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using NUnit.Framework;
using WebCrm.Framework;
using WebCrm.Framework.Repositories;
using WebCrm.Model;
using WebCrm.Model.Services;
using WebCrm.Service;
using WebCrm.Web.Facade;


namespace WebCrm.Test
{
    [TestFixture]
    public class CrmTest1 : BaseCrmTest
    {
        private IUserInfoService _userInfoService;
        private IDeptService _departmentService;
        private OperatorUser _operatorUser;
        private ICategoryService _categoryService;
        private ICategoryItemService _categoryItemService;
        private ICustomerService _customerService;
        private string _loginName = "ssjylsg";
        private Staff _staff;
        [SetUp]
        public override void MyTestInitialize()
        {
            _userInfoService = DependencyResolver.Resolver<IUserInfoService>();
            _departmentService = DependencyResolver.Resolver<IDeptService>();
            _categoryService = DependencyResolver.Resolver<ICategoryService>();
            _categoryItemService = DependencyResolver.Resolver<ICategoryItemService>();
            _operatorUser = _userInfoService.FindByUserName(this._loginName);
            _staff = _userInfoService.FindStaffById(1);
            _customerService = DependencyResolver.Resolver<ICustomerService>();
            base.MyTestInitialize();
        }

        #region MembershipCard
        [Test]
        public void CardTest()
        {
            IMembershipCardService cardService = WebCrm.Framework.DependencyResolver.Resolver<IMembershipCardService>();
            Model.MembershipCard card = new MembershipCard("001", "测试", System.DateTime.Now.AddYears(2), false);
            cardService.Save(card);
            Assert.IsNotNull(cardService.FindById(card.Id));
            card.Description = card.Description + "lsg";
            cardService.Update(card);
        }
        #endregion

        #region OperatorUser
        [Test]
        public void UserInfoAddLeader()
        {
            // 员工信息基本信息
            Staff staff = new Staff();
            staff.Sex = Sex.Male;
            staff.Specialty = "sadf";
            staff.Tel = "74546456456";
            staff.Titles = "中国人民";
            staff.WageBooksId = 1123123;
            staff.WorkAge = 25;
            staff.Company = DependencyResolver.Resolver<ICompanyService>().FindById(1);


            this._userInfoService.SaveStaff(staff);


            OperatorUser operatorUser = new OperatorUser();
            operatorUser.OperatorName = "李世岗";
            operatorUser.OperatorCode = this._loginName;
            operatorUser.OperatorPass = (_loginName).Md5();
            operatorUser.SetId(staff.Id);
            _userInfoService.Save(operatorUser);
            _userInfoService.Save(operatorUser);


            Assert.IsNotNull(_userInfoService.FindById(operatorUser.Id));
        }
        [Test]
        public void UserInfoTest()
        {
            for (int i = 0; i < 5; i++)
            {

                OperatorUser operatorUser = new OperatorUser();
                operatorUser.OperatorName = "李世岗" + i;
                operatorUser.OperatorCode = this._loginName + i;
                operatorUser.OperatorPass = ("ssjylsg").Md5();


                _userInfoService.Save(operatorUser);
                Assert.IsNotNull(_userInfoService.FindById(operatorUser.Id));
            }
        }

        #endregion

        #region Company
        [Test]
        public void CompanyTest()
        {
            ICompanyService companyService = WebCrm.Framework.DependencyResolver.Resolver<ICompanyService>();
            Company company = new Company();
            company.Address = "浙江";
            company.Fax = "3525";
            company.FullName = "杭州深大集团总公司";
            company.Name = "深大";

            company.Optor = this._operatorUser;
            company.Website = "www.baidu.com";


            companyService.Save(company);

            Assert.IsNotNull(companyService.FindById(company.Id));
            company.Fax = company.Fax + "asdfasd";

            companyService.Update(company);

        }

        #endregion

        #region DepartmentTest
        [Test]
        public void DepartmentTest()
        {
            Department department = new Department();
            department.Deleted = false;
            department.DeptName = "杭州深大集团";
            department.ShortName = "集团";
            department.DeptCode = "Code1";
            department.DeptShortCode = "ZD_009";



            _departmentService.Save(department);
            Assert.IsNotNull(_departmentService.FindById(department.Id));

            department.OptorCode = "操作人";
            department.TelNo = "58545555";
            department.Company = DependencyResolver.Resolver<ICompanyService>().FindById(1);
            _departmentService.Update(department);

        }
        #endregion

        #region Category
        /// <summary>
        /// 客户类型
        /// </summary>
        [Test]
        public void CategoryTest()
        {
            Category category = new Category();
            category.Name = "客户类型";
            category.Description = "客户管理-客户类型";
            category.Deleted = false;
            category.Value = "";
            category.Code = "CustomerType";

            this.AddCategory(category, new string[] { "潜在客户", "现有客户", "重点客户", "其他", "供应商", "个人客户" });
        }
        [Test]
        public void CategoryItemTest()
        {
            string[] childNames = new string[] { "一般意向", "重点意向", "不确定客户" };
            Category category = _categoryService.FindByCode("CustomerType");

            var parent = _categoryItemService.FindByCategoryTypeAndItemName("CustomerType", "潜在客户");
            for (int i = 0; i < childNames.Length; i++)
            {
                CategoryItem categoryItem = new CategoryItem();
                categoryItem.Category = category;
                categoryItem.Name = childNames[i];
                categoryItem.OrderIndex = (short)i;
                categoryItem.Description = childNames[i];
                categoryItem.ParentItem = parent;
                _categoryItemService.Save(categoryItem);
            }
        }
        [Test]
        public void CategoryItemChidTest()
        {
            ICategoryItemService categoryItemService = DependencyResolver.Resolver<ICategoryItemService>();
            var parent = categoryItemService.FindById(1);
            Assert.IsTrue(parent.ChildItems.Count > 0);
            this.Log(parent.ChildItems.Count);
        }
        /// <summary>
        /// 客户信用
        /// </summary>
        [Test]
        public void CustomerRating()
        {
            //客户信用
            Category category = new Category();
            category.Name = "客户信用";
            category.Description = "客户管理-客户信用";
            category.Deleted = false;
            category.Value = "";
            category.Code = "CreditRating";

            ICategoryService categoryService = DependencyResolver.Resolver<ICategoryService>();
            categoryService.Save(category);

            string[] items = new string[] { "A", "A+", "A-", "B", "B+", "B-" };
            for (int i = 0; i < items.Length; i++)
            {
                CategoryItem categoryItem = new CategoryItem();
                categoryItem.Category = category;
                categoryItem.Name = items[i];
                categoryItem.OrderIndex = (short)i;
                categoryItem.Description = items[i];
                _categoryItemService.Save(categoryItem);
            }
        }
        /// <summary>
        /// 民族
        /// </summary>
        [Test]
        public void NationalitySate()
        {
            //客户信用
            Category category = new Category();
            category.Name = "民族";
            category.Description = "民族";
            category.Deleted = false;
            category.Value = "民族";
            category.Code = "NationalitySate";

            ICategoryService categoryService = DependencyResolver.Resolver<ICategoryService>();
            categoryService.Save(category);

            string[] items = new string[]
                                 {
                                     "汉族",
                                     "回族",
                                     "蒙古族",
                                     "满族",
                                     "朝鲜族",
                                     "赫哲族",
                                     "达斡尔族",
                                     "鄂温克族",
                                     "鄂伦春族",
                                     "东乡族",
                                     "土族",
                                     "撒拉族",
                                     "保安族",
                                     "裕固族",
                                     "维吾尔族",
                                     "哈萨克族",
                                     "柯尔克孜族",
                                     "锡伯族",
                                     "塔吉克族",
                                     "乌孜别克族",
                                     "俄罗斯族",
                                     "塔塔尔族",
                                     "藏族",
                                     "门巴族",
                                     "珞巴族",
                                     "羌族",
                                     "彝族",
                                     "白族",
                                     "哈尼族",
                                     "傣族",
                                     "傈僳族",
                                     "佤族",
                                     "拉祜族",
                                     "纳西族",
                                     "景颇族",
                                     "布朗族",
                                     "阿昌族",
                                     "普米族",
                                     "怒族",
                                     "德昂族",
                                     "独龙族",
                                     "基诺族",
                                     "苗族",
                                     "布依族",
                                     "侗族",
                                     "水族",
                                     "仡佬族",
                                     "壮族",
                                     "瑶族",
                                     "仫佬族",
                                     "毛南族",
                                     "京族",
                                     "土家族",
                                     "黎族",
                                     "畲族",
                                     "高山族"
                                 };
            for (int i = 0; i < items.Length; i++)
            {
                CategoryItem categoryItem = new CategoryItem();
                categoryItem.Category = category;
                categoryItem.Name = items[i];
                categoryItem.OrderIndex = (short)i;
                categoryItem.Description = items[i];
                _categoryItemService.Save(categoryItem);
            }
        }
        /// <summary>
        /// 信仰
        /// </summary>
        [Test]
        public void Believe()
        {
            Category category = new Category();
            category.Name = "信仰";
            category.Description = "客户管理-信仰";
            category.Deleted = false;
            category.Value = "";
            category.Code = "Believe";

            ICategoryService categoryService = DependencyResolver.Resolver<ICategoryService>();
            categoryService.Save(category);


            string[] items = new string[]
                                 {
                                     "佛教",
                                     "基督教",
                                     "未知",
                                     "无神论者",
                                     "道教"
                                 };
            for (int i = 0; i < items.Length; i++)
            {
                CategoryItem categoryItem = new CategoryItem();
                categoryItem.Category = category;
                categoryItem.Name = items[i];
                categoryItem.OrderIndex = (short)i;
                categoryItem.Description = items[i];
                _categoryItemService.Save(categoryItem);
            }
        }

        /// <summary>
        /// 信仰
        /// </summary>
        [Test]
        public void RelationLevel()
        {
            Category category = new Category();
            category.Name = "客户关系";
            category.Description = "客户管理-客户关系";
            category.Deleted = false;
            category.Value = "";
            category.Code = "Customer_RelationLevel";

            ICategoryService categoryService = DependencyResolver.Resolver<ICategoryService>();
            categoryService.Save(category);


            string[] items = new string[]
                                 {
                                     "紧密",
                                     "好",
                                     "一般",
                                     "排斥",
                                     "反感"
                                 };
            for (int i = 0; i < items.Length; i++)
            {
                CategoryItem categoryItem = new CategoryItem();
                categoryItem.Category = category;
                categoryItem.Name = items[i];
                categoryItem.OrderIndex = (short)i;
                categoryItem.Description = items[i];
                _categoryItemService.Save(categoryItem);
            }
        }
        private void AddCategory(Category category, string[] items)
        {
            _categoryService.Save(category);
            for (int i = 0; i < items.Length; i++)
            {
                CategoryItem categoryItem = new CategoryItem();
                categoryItem.Category = category;
                categoryItem.Name = items[i];
                categoryItem.OrderIndex = (short)i;
                categoryItem.Description = items[i];
                _categoryItemService.Save(categoryItem);
            }
        }
        /// <summary>
        /// 认可程度
        /// </summary>
        [Test]
        public void TestLevelSort()
        {
            Category category = new Category();
            category.Name = "认可程度";
            category.Description = "客户管理-认可程度";
            category.Deleted = false;
            category.Value = "";
            category.Code = "Customer_LevelSort";

            this.AddCategory(category, new string[] { "不认可", "一般认可", "非常认可" });
        }

        /// <summary>
        /// 打折方式
        /// </summary>
        [Test]
        public void DiscountTypeTest()
        {
            Category category = new Category();
            category.Name = "打折方式";
            category.Description = "客户管理-打折方式";
            category.Deleted = false;
            category.Value = "";
            category.Code = "Customer_DiscountType";

            this.AddCategory(category, new string[] { "不打折", "9.5 折", "8折", "4折" });
        }
        /// <summary>
        /// 积分规则
        /// </summary>
        [Test]
        public void ScoreRuleTest()
        {
            Category category = new Category();
            category.Name = "积分规则";
            category.Description = "客户管理-积分规则";
            category.Deleted = false;
            category.Value = "";
            category.Code = "Customer_ScoreRule";

            this.AddCategory(category, new string[] { "不积分", "满100积2分", "满200积5分", "满400积12分" });
        }
        /// <summary>
        /// 投诉类型
        /// </summary>
        [Test]
        public void SuggestTypeTest()
        {
            Category category = new Category();
            category.Name = "投诉建议-类型";
            category.Description = "投诉建议-类型";
            category.Deleted = false;
            category.Value = "";
            category.Code = "SuggestType";

            this.AddCategory(category, new string[] { "餐厅", "宾馆客房", "导游", "其他" });
        }
        /// <summary>
        /// 建议/投诉解决方案
        /// </summary>
        [Test]
        public void SolveTypeTest()
        {
            Category category = new Category();
            category.Name = "投诉建议-解决方案";
            category.Description = "投诉建议-解决方案";
            category.Deleted = false;
            category.Value = "";
            category.Code = "SolveType";

            this.AddCategory(category, new string[] { "解决方案1", "解决方案2", "解决方案3", "解决方案4" });
        }
        #endregion
        private CategoryItem FindByCategoryCodeAndItemName(string categoryCode, string name)
        {
            return this._categoryItemService.FindByCategoryTypeAndItemName(categoryCode, name);
        }
        #region Customer
        [Test]
        public void CustomerTest()
        {
            Customer customer = new Customer();

            customer.BelongPerson = this._operatorUser;
            customer.Car = "浙A H012413";
            customer.Cagegory = FindByCategoryCodeAndItemName("CustomerType", "一般意向"); // 一般意向
            customer.Name = "李红";
            customer.CreditRating = this.FindByCategoryCodeAndItemName("CreditRating", "A");
            customer.AccType = CustomerIdentification.Person;
            customer.TotalScore = 0;
            customer.LastSpendDate = null;
            customer.CreatePerson = this._operatorUser;

            CustomerInfo customerInfo = new CustomerInfo()
                                            {
                                                Addr = "浙江好",
                                                CreateTime = DateTime.Now,
                                                Deleted = false,
                                                Email = "ssjylsg@yahu.com",
                                                EmailAuth = false,
                                                IdCard = "100000000"
                                            };

            customerInfo.BirthDate = System.DateTime.Now.AddDays(-30);

            customerInfo.Customer = customer;
            _customerService.Save(customer);
            DependencyResolver.Resolver<ICustomerInfoService>().Save(customerInfo);
        }
        [Test]
        public void FindTest()
        {
            Assert.IsNotNull(this._customerService.FindById(1));
        }
        /// <summary>
        /// 客户回访记录
        /// </summary>
        [Test]
        public void CustomerVisitRecordServiceTest()
        {
            ICustomerVisitRecordService customerVisitRecordService = DependencyResolver.Resolver<ICustomerVisitRecordService>();

            CustomerVisitRecord record = new CustomerVisitRecord();
            record.Customer = _customerService.FindById(1);
            record.BusinessPeople = _staff;
            record.Content = "第一回访，回访很愉快";
            record.OtherPerson = "黎明，万里，张子健";
            record.VisitDate = DateTime.Now.AddDays(-7);

            customerVisitRecordService.Save(record);
            Assert.IsNotNull(customerVisitRecordService.FindById(record.Id));

        }
        /// <summary>
        /// 洽谈
        /// </summary>
        [Test]
        public void DiscussCustomerRecordServiceTest()
        {
            IDiscussCustomerRecordService discussCustomerRecordService =
                DependencyResolver.Resolver<IDiscussCustomerRecordService>();

            DiscussCustomerRecord record = new DiscussCustomerRecord();
            record.Customer = _customerService.FindById(1);
            record.BussinessPerson = _staff;
            record.Content = "第一回访，回访很愉快";
            record.OtherPersonName = "黎明，万里，张子健";
            record.DiscussDate = DateTime.Now.AddDays(-7);

            discussCustomerRecordService.Save(record);
            Assert.IsNotNull(discussCustomerRecordService.FindById(record.Id));

        }
        /// <summary>
        /// 消费记录
        /// </summary>
        [Test]
        public void CustormerConsumRecordServiceTest()
        {
            ICustormerConsumRecordService consumRecordService = DependencyResolver.Resolver<ICustormerConsumRecordService>();

            CustormerConsumRecord record = new CustormerConsumRecord();
            record.Customer = _customerService.FindById(1);
            record.Score = 10;
            record.SpendTotal = (decimal)1000.12;
            record.WritePerson = this._operatorUser;
            record.ConsumptionDate = DateTime.Now.AddDays(-7);
            record.DiscountType = this._categoryItemService.FindById(1);// 9.5 折
            record.ScoreRule = this._categoryItemService.FindById(1);//
            record.AfterDiscountFree = record.SpendTotal * (decimal)0.95;
            record.ReceiveMoney = record.AfterDiscountFree;

            consumRecordService.Save(record);
            this._customerService.SaveNewProcHist(string.Empty, record, this._operatorUser, "新增消费记录", "新增消费记录");
            Assert.IsNotNull(consumRecordService.FindById(record.Id));
        }
        #endregion

        #region 投诉建议
        /// <summary>
        /// 投诉建议
        /// </summary>
        [Test]
        public void SuggetTest()
        {
            ISuggestService suggestService = DependencyResolver.Resolver<ISuggestService>();
            Suggest record = new Suggest();
            record.SuggestType = this._categoryItemService.FindById(1);
            record.SolveType = this._categoryItemService.FindById(1);
            record.Content = "第一回访，回访很愉快";

            record.SuggestDate = DateTime.Now.AddDays(-7);

            suggestService.Save(record);
        }
        #endregion

        #region 节假日
        [Test]
        public void HolidayServiceTest()
        {
            IHolidayService service = DependencyResolver.Resolver<IHolidayService>();


            for (int i = 0; i < 10; i++)
            {
                Holiday day = new Holiday();
                day.HolidayDate = new DateTime(2013, 5, i + 1);
                day.Descript = "五一劳动节" + i;

                service.Save(day);
            }
        }
        #endregion

        #region 合同
        /// <summary>
        /// 合同状态
        /// </summary>
        [Test]
        public void ContractStateTest()
        {
            Category category = new Category();
            category.Name = "合同执行状态";
            category.Description = "合同管理-合同执行状态";
            category.Deleted = false;
            category.Value = "";
            category.Code = "ContractState";

            this.AddCategory(category, new string[] { "未执行", "执行中", "已完成", "已终止" });
        }
        [Test]
        public void ContractServiceTest()
        {
            //执行状态
            IContractService contractService = DependencyResolver.Resolver<IContractService>();
            Contract contract = new Contract();
            contract.State = this.FindByCategoryCodeAndItemName("ContractState", "未执行");
            contract.Content = "合同测试";
            contract.ContractName = "测试和哦他能够";
            contract.SignAddress = "浙江";
            contract.CreatePerson = this._operatorUser;
            contract.CustomerName = "战三有限公司";
            contract.CustomerSignPerson = "张三";

            contract.EndDate = DateTime.Now.AddYears(3);
            contract.StartDate = DateTime.Now.AddDays(12);
            contract.SignDate = DateTime.Now.AddDays(-2);
            contract.Sum = (decimal)1000000.02;
            contract.Code = "HG_0023";
            contract.SettleState = SettleState.NoSettle;

            contractService.Save(contract);
            contractService.SaveNewProcHist("新增合同", contract, this._operatorUser, "新增合同", "新增合同");

        }
        #endregion

        #region Post
        [Test]
        public void PostTest()
        {
            IPostService postService = new PostService();

            string[] postNames = new string[] { ".Net 开发工程师", "Java ", "C++", "C", "go" };

            for (int i = 0; i < postNames.Length; i++)
            {
                Post post = new Post();
                post.PostCode = "00" + i;
                post.Company = DependencyResolver.Resolver<ICompanyService>().FindById(1);
                post.Dept = this._departmentService.FindById(1);

                post.PostName = postNames[i];

                postService.Save(post);

                Assert.IsNotNull(postService.FindById(post.Id));
            }


        }
        #endregion

        #region Function
        [Test]
        public void FunctionTest()
        {
            ApplicationConfig.Intance.Init(o => { },
                                           new Assembly[]
                                               {
                                                   Assembly.Load("WebCrm.Model"), Assembly.Load("WebCrm.Service"),
                                                   Assembly.Load("WebCrm.Dao")
                                               });
            IFunctionService functionService = DependencyResolver.Resolver<IFunctionService>();// new FunctionService();
            Assert.IsNotNull(functionService);
            Assert.IsNotNull(functionService.FindFirstStage());
            //string[] names = new string[] { "基础数据", "客户管理", "合同管理", "节假日管理", "财务管理", "广告管理" };

            //for (int i = 0; i < names.Length; i++)
            //{
            //    Function function = new Function();
            //    function.ActionName = names[i];
            //    function.FunctionName = names[i];
            //    function.IcoTemplate = "";
            //    function.Optor = this._operatorUser;
            //    function.OrderNum = i;

            //    functionService.Save(function);
            //    Assert.IsNotNull(functionService.FindById(function.Id));
            //}
        }
        #endregion

        #region GetCustomerNo
        [Test]
        public void GetCustomerNo()
        {
            for (int i = 0; i < 5; i++)
            {
                this.Log(this._customerService.GetCustomerNo());
            }
        }
        #endregion

        #region VIP类型 区域
        [Test]
        public void VipCagegoryTest()
        {
            Category category = new Category();
            category.Name = "客户管理-会员类型";
            category.Description = "客户管理-会员类型";
            category.Deleted = false;
            category.Value = "";
            category.Code = "VipCategory";

            this.AddCategory(category, new string[] { "普通会员", "VIP会员", "高级VIP会员" });
        }
        [Test]
        public void CustomerAreaTest()
        {
            Category category = new Category();
            category.Name = "客户管理-地区区域管理";
            category.Description = "客户管理-地区区域管理";
            category.Deleted = false;
            category.Value = "";
            category.Code = "CustomerArea";

            #region
            var source = new[]
                             {
                                 new {id = 4, name = "北京"},


                                 new
                                     {
                                         id =
                                     5,
                                         name =
                                     "天津"
                                     }
                                 ,
                                 new
                                     {
                                         id =
                                     6,
                                         name =
                                     "上海"
                                     }
                                 ,
                                 new
                                     {
                                         id =
                                     7,
                                         name =
                                     "重庆"
                                     }
                                 ,
                                 new
                                     {
                                         id =
                                     8,
                                         name =
                                     "广东省"
                                     }
                                 ,
                                 new
                                     {
                                         id =
                                     9,
                                         name =
                                     "江苏省"
                                     }
                                 ,
                                 new
                                     {
                                         id =
                                     10,
                                         name =
                                     "浙江省"
                                     }
                                 ,
                                 new
                                     {
                                         id =
                                     11,
                                         name =
                                     "福建省"
                                     }
                                 ,
                                 new
                                     {
                                         id =
                                     12,
                                         name =
                                     "湖南省"
                                     }
                                 ,
                                 new
                                     {
                                         id =
                                     13,
                                         name =
                                     "湖北省"
                                     }
                                 ,
                                 new
                                     {
                                         id =
                                     14,
                                         name =
                                     "山东省"
                                     }
                                 ,
                                 new
                                     {
                                         id =
                                     15,
                                         name =
                                     "辽宁省"
                                     }
                                 ,
                                 new
                                     {
                                         id =
                                     16,
                                         name =
                                     "吉林省"
                                     }
                                 ,
                                 new
                                     {
                                         id =
                                     17,
                                         name =
                                     "云南省"
                                     }
                                 ,
                                 new
                                     {
                                         id =
                                     18,
                                         name =
                                     "四川省"
                                     }
                                 ,
                                 new
                                     {
                                         id =
                                     19,
                                         name =
                                     "安徽省"
                                     }
                                 ,
                                 new
                                     {
                                         id =
                                     20,
                                         name =
                                     "江西省"
                                     }
                                 ,
                                 new
                                     {
                                         id =
                                     21,
                                         name =
                                     "黑龙江省"
                                     }
                                 ,
                                 new
                                     {
                                         id =
                                     22,
                                         name =
                                     "河北省"
                                     }
                                 ,
                                 new
                                     {
                                         id =
                                     23,
                                         name =
                                     "陕西省"
                                     }
                                 ,
                                 new
                                     {
                                         id =
                                     24,
                                         name =
                                     "海南省"
                                     }
                                 ,
                                 new
                                     {
                                         id =
                                     25,
                                         name =
                                     "河南省"
                                     }
                                 ,
                                 new
                                     {
                                         id =
                                     26,
                                         name =
                                     "山西省"
                                     }
                                 ,
                                 new
                                     {
                                         id =
                                     27,
                                         name =
                                     "内蒙古自治区"
                                     }
                                 ,
                                 new
                                     {
                                         id =
                                     28,
                                         name =
                                     "广西壮族自治区"
                                     }
                                 ,
                                 new
                                     {
                                         id =
                                     29,
                                         name =
                                     "贵州省"
                                     }
                                 ,
                                 new
                                     {
                                         id =
                                     30,
                                         name =
                                     "宁夏回族自治区"
                                     }
                                 ,
                                 new
                                     {
                                         id =
                                     31,
                                         name =
                                     "青海省"
                                     }
                                 ,
                                 new
                                     {
                                         id =
                                     32,
                                         name =
                                     "新疆维吾尔自治区"
                                     }
                                 ,
                                 new
                                     {
                                         id =
                                     33,
                                         name =
                                     "西藏自治区"
                                     }
                                 ,
                                 new
                                     {
                                         id =
                                     34,
                                         name =
                                     "甘肃省"
                                     }
                                 ,
                                 new
                                     {
                                         id =
                                     35,
                                         name =
                                     "台湾省"
                                     }
                                 ,
                                 new
                                     {
                                         id =
                                     36,
                                         name =
                                     "香港特别行政区"
                                     }
                                 ,
                                 new
                                     {
                                         id =
                                     37,
                                         name =
                                     "澳门特别行政区"
                                     }
                             };
            #endregion

            this.AddCategory(category, source.ToList().Select(m => m.name).ToArray());
        }
        /// <summary>
        /// 客户区域
        /// </summary>
        [Test]
        public void CustomerAreaTest1()
        {
            //北京市辖区名称
            var city1 = new string[] { "东城区", "西城区", "崇文区", "宣武区", "朝阳区", "海淀区", "丰台区", "石景山区", "房山区", "通州区", "顺义区", "门头沟区", "昌平区", "大兴区", "怀柔区", "平谷区", "密云县", "延庆县" };
            //上海市辖区名称
            var city2 = new string[] { "黄浦区", "卢湾区", "徐汇区", "长宁区", "静安区", "普陀区", "闸北区", "虹口区", "杨浦区", "宝山区", "闵行区", "嘉定区", "浦东新区", "金山区", "松江区", "青浦区", "南汇区", "奉贤区", "崇明县" };
            //天津市辖区名称
            var city3 = new string[] { "和平区", "河东区", "河西区", "南开区", "河北区", "红桥区", "塘沽区", "汉沽区", "大港区", "东丽区", "西青区", "津南区", "北辰区", "武清区", "宝坻区", "宁河县", "静海县", "蓟县" };
            //重庆市辖区名称
            var city4 = new string[] { "渝中区", "大渡口区", "江北区", "沙坪坝区", "九龙坡区", "南岸区", "北碚区", "万盛区", "双桥区", "渝北区", "巴南区", "万县区", "涪陵区", "永川市", "合川市", "江津市", "南川市", "长寿县", "綦江县", "潼南县", "荣昌县", "壁山县", "大足县", "铜梁县", "梁平县", "城口县", "垫江县", "武隆县", "丰都县", "忠 县", "开 县", "云阳县", "青龙镇青龙嘴", "奉节县", "巫山县", "巫溪县", "南宾镇", "中和镇", "钟多镇", "联合镇", "汉葭镇" };
            //河北省主要城市名称
            var city5 = new string[] { "石家庄市", "唐山市", "秦皇岛市", "邯郸市", "邢台市", "保定市", "张家口市", "承德市", "沧州市", "廊坊市", "衡水市" };
            //山西省主要城市名称
            var city6 = new string[] { "太原市", "大同市", "阳泉市", "长治市", "晋城市", "朔州市", "晋中市", "运城市", "忻州市", "临汾市", "吕梁市" };
            //辽宁省主要城市名称
            var city7 = new string[] { "沈阳市", "大连市", "鞍山市", "抚顺市", "本溪市", "丹东市", "锦州市", "营口市", "阜新市", "辽阳市", "盘锦市", "铁岭市", "朝阳市", "葫芦岛市" };
            //吉林省主要城市名称
            var city8 = new string[] { "长春市", "吉林市", "四平市", "辽源市", "通化市", "白山市", "松原市", "白城市", "延边朝鲜族自治州" };
            //河南省主要城市名称
            var city9 = new string[] { "郑州市", "开封市", "洛阳市", "平顶山市", "安阳市", "鹤壁市", "新乡市", "焦作市", "濮阳市", "许昌市", "漯河市", "三门峡市", "南阳市", "商丘市", "信阳市", "周口市", "驻马店市", "济源市" };
            //江苏省主要城市名称
            var city10 = new string[] { "南京市", "无锡市", "徐州市", "常州市", "苏州市", "南通市", "连云港市", "淮安市", "盐城市", "扬州市", "镇江市", "泰州市", "宿迁市" };
            //浙江省主要城市名称
            var city11 = new string[] { "杭州市", "宁波市", "温州市", "嘉兴市", "湖州市", "绍兴市", "金华市", "衢州市", "舟山市", "台州市", "丽水市" };
            //安徽省主要城市名称
            var city12 = new string[] { "合肥市", "芜湖市", "蚌埠市", "淮南市", "马鞍山市", "淮北市", "铜陵市", "安庆市", "黄山市", "滁州市", "阜阳市", "宿州市", "巢湖市", "六安市", "亳州市", "池州市", "宣城市" };
            //福建省主要城市名称
            var city13 = new string[] { "福州市", "厦门市", "莆田市", "三明市", "泉州市", "漳州市", "南平市", "龙岩市", "宁德市" };
            //江西省主要城市名称
            var city14 = new string[] { "南昌市", "景德镇市", "萍乡市", "九江市", "新余市", "鹰潭市", "赣州市", "吉安市", "宜春市", "抚州市", "上饶市" };
            //山东省主要城市名称
            var city15 = new string[] { "济南市", "青岛市", "淄博市", "枣庄市", "东营市", "烟台市", "潍坊市", "威海市", "济宁市", "泰安市", "日照市", "莱芜市", "临沂市", "德州市", "聊城市", "滨州市", "菏泽市" };
            //湖北省主要城市名称
            var city16 = new string[] { "武汉市", "黄石市", "襄樊市", "十堰市", "荆州市", "宜昌市", "荆门市", "鄂州市", "孝感市", "黄冈市", "咸宁市", "随州市", "恩施州", "仙桃市", "潜江市", "天门市", "神农架林区" };
            //湖南省主要城市名称
            var city17 = new string[] { "长沙市", "株洲市", "湘潭市", "衡阳市", "邵阳市", "岳阳市", "常德市", "张家界市", "益阳市", "郴州市", "永州市", "怀化市", "娄底市", "湘西州" };
            //广东省主要城市名称
            var city18 = new string[] { "广州市", "深圳市", "珠海市", "汕头市", "韶关市", "佛山市", "江门市", "湛江市", "茂名市", "肇庆市", "惠州市", "梅州市", "汕尾市", "河源市", "阳江市", "清远市", "东莞市", "中山市", "潮州市", "揭阳市", "云浮市" };
            //海南省主要城市名称
            var city19 = new string[] { "海口市", "龙华区", "秀英区", "琼山区", "美兰区", "三亚市" };
            //四川省主要城市名称
            var city20 = new string[] { "成都市", "自贡市", "攀枝花市", "泸州市", "德阳市", "绵阳市", "广元市", "遂宁市", "内江市", "乐山市", "南充市", "宜宾市", "广安市", "达州市", "眉山市", "雅安市", "巴中市", "资阳市", "阿坝州", "甘孜州", "凉山州" };
            //贵州省主要城市名称
            var city21 = new string[] { "贵阳市", "六盘水市", "遵义市", "安顺市", "铜仁地区", "毕节地区", "黔西南州", "黔东南州", "黔南州" };
            //云南省主要城市名称
            var city22 = new string[] { "昆明市", "大理市", "曲靖市", "玉溪市", "昭通市", "楚雄市", "红河市", "文山市", "思茅市", "西双版纳市", "保山市", "德宏市", "丽江市", "怒江市", "迪庆市", "临沧市" };
            //陕西省主要城市名称
            var city23 = new string[] { "西安市", "铜川市", "宝鸡市", "咸阳市", "渭南市", "延安市", "汉中市", "榆林市", "安康市", "商洛市" };
            //甘肃省主要城市名称
            var city24 = new string[] { "兰州市", "嘉峪关市", "金昌市", "白银市", "天水市", "武威市", "张掖市", "平凉市", "酒泉市", "庆阳市", "定西市", "陇南市", "临夏州", "甘南州" };
            //青海省主要城市名称
            var city25 = new string[] { "西宁市", "海东地区", "海北州", "黄南州", "海南州", "果洛州", "玉树州", "海西州" };
            //黑龙江省主要城市名称
            var city26 = new string[] { "哈尔滨市", "齐齐哈尔市", "鸡西市", "鹤岗市", "双鸭山市", "大庆市", "伊春市", "佳木斯市", "七台河市", "牡丹江市", "黑河市", "绥化市", "大兴安岭地区" };
            //内蒙古自治区主要城市名称
            var city27 = new string[] { "呼和浩特市", "包头市", "乌海市", "赤峰市", "通辽市", "鄂尔多斯市", "呼伦贝尔市", "巴彦淖尔市", "乌兰察布市", "兴安盟", "锡林郭勒盟", "阿拉善盟" };
            //广西壮族自治区主要城市名称
            var city28 = new string[] { "南宁市", "柳州市", "桂林市", "梧州市", "北海市", "防城港市", "钦州市", "贵港市", "玉林市", "百色市", "贺州市", "河池市", "来宾市", "崇左市" };
            //西藏自治区主要城市名称
            var city29 = new string[] { "拉萨市", "昌都地区", "山南地区", "日喀则地区", "那曲地区", "阿里地区", "林芝地区" };
            //宁夏回族自治区主要城市名称
            var city30 = new string[] { "银川市", "石嘴山市", "吴忠市", "固原市", "中卫市" };
            //新疆维吾尔自治区主要城市名称
            var city31 = new string[] { "乌鲁木齐市", "克拉玛依市", "吐鲁番地区", "哈密地区", "和田地区", "阿克苏地区", "喀什地区", "克孜勒苏柯尔克孜自治州", "巴音郭楞蒙古自治州", "昌吉回族自治州", "博尔塔拉蒙古自治州", "伊犁哈萨克自治州", "塔城地区", "阿勒泰地区", "石河子市", "阿拉尔市", "图木舒克市", "五家渠市" };
            //台湾省主要城市名称
            var city32 = new string[] { "台北市", "高雄市", "基隆市", "台中市", "台南市", "新竹市", "嘉义市", "台北县", "宜兰县", "桃园县", "新竹县", "苗栗县", "台中县", "彰化县", "南投县", "云林县", "嘉义县", "台南县", "高雄县", "屏东县", "澎湖县", "台东县", "花莲县" };
            //香港特别行政区主要辖区名称
            var city33 = new string[] { "中西区", "东区", "九龙城区", "观塘区", "南区", "深水埗区", "黄大仙区", "湾仔区", "油尖旺区", "离岛区", "葵青区", "北区", "西贡区", "沙田区", "屯门区", "大埔区", "荃湾区", "元朗区" };
            //澳门地区
            var city34 = new string[] { "澳门地区" };
            //其它地区
            var city35 = new string[] { "其它地区" };


            var allCity = new string[][]
                              {
                                  city1, city2, city3, city4, city5, city6, city7, city8, city9, city10,
                                  city11, city12, city13, city14, city15, city16, city17, city18, city19, city20,
                                  city21, city22, city23, city24, city25, city26, city27, city28, city29, city30,
                                  city31, city32, city33, city34, city35
                              };

            //全国省会，直辖市，自治区名称
            var provinceName = new string[] { "北京市", "上海市", "天津市", "重庆市", "河北省", "山西省", "辽宁省", "吉林省", "河南省", "江苏省", "浙江省", "安徽省", "福建省", "江西省", "山东省", "湖北省", "湖南省", "广东省", "海南省", "四川省", "贵州省", "云南省", "陕西省", "甘肃省", "青海省", "黑龙江省", "内蒙古自治区", "广西壮族自治区", "西藏自治区", "宁夏回族自治区", "新疆维吾尔自治区", "台湾省", "香港特别行政区", "澳门特别行政区", "其它" };


            Category category = new Category();
            category.Name = "客户管理-地区区域管理";
            category.Description = "客户管理-地区区域管理";
            category.Deleted = false;
            category.Value = "";
            category.Code = "CustomerArea";


            this.AddCategory(category, provinceName);

            for (int i = 0; i < provinceName.Length; i++)
            {
                AddChildCategoryItem(provinceName[i], "CustomerArea", allCity[i], category);
            }
        }

        private void AddChildCategoryItem(string s, string customerarea, string[] strings, Category category)
        {
            CategoryItem parent = this._categoryItemService.FindByCategoryTypeAndItemName(customerarea, s);


            for (int index = 0; index < strings.Length; index++)
            {
                string s1 = strings[index];
                CategoryItem child = new CategoryItem();
                child.Name = s1;
                child.Description = s1;
                child.OrderIndex = (short)index;
                child.ParentItem = parent;
                child.Category = category;

                this._categoryItemService.Save(child);
            }

        }

        #endregion

        #region 初始化数据
        [Test]
        public void AddCategory()
        {
            var session = NHibernateDatabaseFactory.GetSession();
            var connection = session.Connection;
            this.Log(connection.ConnectionString);

            var command = connection.CreateCommand();
            command.CommandType = CommandType.Text;

            string[] sql = new string[] { "DELETE FROM Crm_Category", "DELETE FROM Crm_CategoryItem", };

            try
            {
                foreach (string s in sql)
                {
                    command.CommandText = s;
                    command.ExecuteNonQuery();
                }

                CategoryTest();
                CategoryItemTest();
                CustomerRating();
                NationalitySate();
                Believe();
                RelationLevel();
                TestLevelSort();
                DiscountTypeTest();
                ScoreRuleTest();
                SuggestTypeTest();
                SolveTypeTest();
                ContractStateTest();
                VipCagegoryTest();
                CustomerAreaTest1();
                AddActionCategory();
                CompanyActionEvaluate();

                this.Advertising_Channel();
                this.Advertising_Evaluate();
                this.Advertising_State();

                CustomerSource();
                FinancialPay();
                CustomerBusiness();
            }
            catch
            {

                throw;
            }
        }

        #region 消费类型
        [Test]
        public void ConsumerBusinessType()
        {
            Category category = new Category();
            category.Name = "客户-消费类型";
            category.Description = "客户-消费类型";
            category.Deleted = false;
            category.Value = "";
            category.Code = "ConsumerBusinessType";

            this.AddCategory(category, new string[] { "景区门票", "酒店", "餐饮", "温泉" });
        }
        #endregion

        #region 活动
        /// <summary>
        /// 活动状态
        /// </summary>
        public void AddActionCategory()
        {
            Category category = new Category();
            category.Name = "活动-状态";
            category.Description = "活动-状态";
            category.Deleted = false;
            category.Value = "";
            category.Code = "CompanyAction_State";

            this.AddCategory(category, new string[] { "未执行", "执行中", "活动已结束", "延缓", "挂起" });
        }
        /// <summary>
        /// 活动-评价
        /// </summary>
        public void CompanyActionEvaluate()
        {
            Category category = new Category();
            category.Name = "活动-评价";
            category.Description = "活动-评价";
            category.Deleted = false;
            category.Value = "";
            category.Code = "CompanyAction_Evaluate";

            this.AddCategory(category, new string[] { "一般", "好", "优秀" });
        }

        /// <summary>
        /// 客户来源
        /// </summary>
        [Test]
        public void CustomerSource()
        {
            Category category = new Category();
            category.Name = "客户-来源";
            category.Description = "客户-来源";
            category.Deleted = false;
            category.Value = "";
            category.Code = "CustomerSource";

            this.AddCategory(category, new string[] { "报纸", "电视", "网络", "户外广告", "朋友介绍" });
        }
        /// <summary>
        /// 财务管理-应付账款类别
        /// </summary>
        [Test]
        public void FinancialPay()
        {
            Category category = new Category();
            category.Name = "财务管理-应付账款类别";
            category.Description = "财务管理-应付账款类别";
            category.Deleted = false;
            category.Value = "";
            category.Code = "FinancialPayType";

            this.AddCategory(category, new string[] { "广告费", "印刷费", "租车费", "退款" });
        }
        /// <summary>
        /// 客户行业
        /// </summary>
        [Test]
        public void CustomerBusiness()
        {
            Category category = new Category();
            category.Name = "客户管理-客户行业";
            category.Description = "客户管理-客户行业";
            category.Deleted = false;
            category.Value = "";
            category.Code = "CustomerBusiness";

            this.AddCategory(category, new string[] { "金融", "政府", "IT/互联网", "零售商", "建筑" });
        }
        #endregion

        #region 广告
        /// <summary>
        /// 广告状态
        /// </summary>
        public void Advertising_Channel()
        {
            Category category = new Category();
            category.Name = "广告-渠道";
            category.Description = "广告-渠道";
            category.Deleted = false;
            category.Value = "";
            category.Code = "Advertising_Channel";

            this.AddCategory(category, new string[] { "渠道1", "渠道2", "渠道3" });
        }
        /// <summary>
        /// 广告状态
        /// </summary>
        public void Advertising_State()
        {
            Category category = new Category();
            category.Name = "广告状态";
            category.Description = "广告-状态";
            category.Deleted = false;
            category.Value = "";
            category.Code = "Advertising_State";

            this.AddCategory(category, new string[] { "未投放", "已投放", });
        }
        /// <summary>
        /// 广告-评价
        /// </summary>
        public void Advertising_Evaluate()
        {
            Category category = new Category();
            category.Name = "广告-评价";
            category.Description = "广告-评价";
            category.Deleted = false;
            category.Value = "";
            category.Code = "Advertising_Evaluate";

            this.AddCategory(category, new string[] { "一般", "好", "优秀" });
        }
        #endregion

        #endregion

        #region 功能模块导入
        private class PageModel
        {
            public string Url { get; set; }
            public string PageName { get; set; }

        }

        /// <summary>
        /// 功能模块导入
        /// </summary>
        [Test]
        public void FunctionInsert()
        {
            Dictionary<string, IList<PageModel>> pages = new Dictionary<string, IList<PageModel>>();


            pages["基础模块"] = GetSysModel();

            pages["客户管理"] = CustomerPageModels();

            pages["合同管理"] = GetContractPageModel();

            pages["财务管理"] = GetFinancialPageModel();

            pages["市场管理"] = this.GetMarketPageModel();

            pages["投诉建议管理"] = GetComplaSuggPageModel();

            pages["统计分析"] = GetChartModel();

            pages["消息发送"] = GetWebMsgModel();

            pages["消息模板"] = this.GetTemplateModel();

            pages["我的桌面"] = this.GetMySelftCustomerModel();

            int modelSort = 1;
            foreach (var page in pages)
            {
                var parent = InsertPlug(page.Key, null, modelSort, string.Empty);
                this.Log(string.Format("写入{0}", page.Key));
                int pageSort = 1;
                foreach (PageModel pageModel in page.Value)
                {
                    this.InsertPlug(pageModel.PageName, parent, pageSort, pageModel.Url);
                    this.Log(string.Format("写入{0} ,地址 {1} , 父节点ID {2} ", pageModel.PageName, pageModel.Url, parent.Id));
                    pageSort++;
                }
                modelSort++;
            }
        }

        private Plug InsertPlug(string pageName, Plug parent, int sort, string url = "")
        {
            Plug plug = new Plug() { CreateTime = DateTime.Now, Deleted = false, PlugWebFile = url, PlugName = pageName, Parent = parent, State = true, Sort = sort };

            DependencyResolver.Resolver<IPlugService>().Save(plug);
            return plug;
        }


        private IList<PageModel> CustomerPageModels()
        {
            List<PageModel> list = new List<PageModel>();


            list.Add(new PageModel() { PageName = "客户详细信息", Url = "/Pages/WebCustomer/List.aspx" });
            list.Add(new PageModel() { PageName = "客户回访记录", Url = "/Pages/WebCustomer/VisitRecordList.aspx" });
            list.Add(new PageModel() { PageName = "客户洽谈记录", Url = "/Pages/WebDiscuss/List.aspx" });
            list.Add(new PageModel() { PageName = "客户消费记录", Url = "/Pages/WebConsume/List.aspx" });
            return list;
        }
        private IList<PageModel> GetContractPageModel()
        {
            return new List<PageModel>() { new PageModel() { PageName = "合同管理", Url = "/Pages/WebContract/List.aspx" } };
        }
        private IList<PageModel> GetFinancialPageModel()
        {
            return new List<PageModel>()
                       {
                           new PageModel() {PageName = "应收账款", Url = "/Pages/WebFinancial/List.aspx?FinancialType=receive"},
                           new PageModel() {PageName = "应付账款", Url = "/Pages/WebFinancial/List.aspx?FinancialType=pay"}
                       };
        }

        private IList<PageModel> GetMarketPageModel()
        {

            return new List<PageModel>()
                       {
                           new PageModel() {PageName = "广告", Url = "/Pages/WebMarket/WebAd/List.aspx"},
                           new PageModel() {PageName = "活动", Url = "/Pages/WebMarket/WebActivity/List.aspx"},
                             new PageModel() {PageName = "合作单位", Url = "/Pages/WebMarket/WebJowork/List.aspx"}
                       };
        }

        private IList<PageModel> GetComplaSuggPageModel()
        {

            return new List<PageModel>()
                       {
                           new PageModel() {PageName = "投诉", Url = "/Pages/WebComplaSugg/List.aspx?SuggestComplaints=Complaints"},
                           new PageModel() {PageName = "建议", Url = "/Pages/WebComplaSugg/List.aspx?SuggestComplaints=Suggest"},
                             
                       };
        }

        private IList<PageModel> GetChartModel()
        {

            return new List<PageModel>()
                       {
                           new PageModel() {PageName = "消费记录分析", Url = "/Pages/Chart/ExpenseRecord.aspx"},
                           new PageModel() {PageName = "客户结构分析", Url = "/Pages/Chart/CustomerArchitecture.aspx"},
                            new PageModel() {PageName = "市场活动分析", Url = "/Pages/Chart/MarketingActivity.aspx"},
                           new PageModel() {PageName = "销售人员业绩分析", Url = "/Pages/Chart/SalesPerformance.aspx"},
                             
                       };
        }

        private IList<PageModel> GetWebMsgModel()
        {

            return new List<PageModel>()
                       {
                           new PageModel() {PageName = "消息发送", Url = "/Pages/WebMsg/NewOrEdit.aspx"}, 
                       };
        }
        private IList<PageModel> GetTemplateModel()
        {

            return new List<PageModel>()
                       {
                           new PageModel() {PageName = "消息模板", Url = "/Pages/WebTemplate/List.aspx"}, 
                       };
        }
        private IList<PageModel> GetMySelftCustomerModel()
        {

            return new List<PageModel>()
                       {
                           new PageModel() {PageName = "我的客户", Url = "/Pages/WebNotify/MySelftCustomer.aspx"}, 
                           new PageModel() {PageName = "最近生日客户", Url = "/Pages/WebNotify/CustomerNotify/BirthdayNotify.aspx"}, 
                           new PageModel(){PageName = "我创建的任务",Url = "/Pages/WebTask/List.aspx"},
                           new PageModel(){PageName = "指派给我的任务",Url = "/Pages/WebTask/List.aspx?QueryType=assign"}
                       };
        }

        private IList<PageModel> GetSysModel()
        {


            return new List<PageModel>()
                       {
                           new PageModel() {PageName = "公司列表", Url = "/Pages/WebComapny/List.aspx"},
                           new PageModel() {PageName = "部门列表", Url = "/Pages/WebDept/List.aspx"},
                           new PageModel() {PageName = "用户列表", Url = "/Pages/WebUser/List.aspx"},
                           new PageModel() {PageName = "节假日列表", Url = "/Pages/WebHoliday/List.aspx"},

                           new PageModel() {PageName = "会员卡信息", Url = "/Pages/WebshipCard/List.aspx"},
                           new PageModel() {PageName = "角色管理", Url = "/Pages/WebSysRole/List.aspx"},
                           new PageModel() {PageName = "插件管理", Url = "/Pages/WebPlug/List.aspx"},
                           new PageModel() {PageName = "CRM数据字典", Url = "/Pages/WebCrmDictionary/List.aspx"},

                           new PageModel() {PageName = "分类列表", Url = "/Pages/WebCategory/List.aspx"},
                           new PageModel() {PageName = "CRM分类项列表", Url = "/Pages/WebCategoryItem/List.aspx"},
                       };
        }
        #endregion

        #region 消息发送测试
        [Test]
        public void InsertMessageContent()
        {
            var messageService = DependencyResolver.Resolver<IMessageContentService>();
            for (int i = 0; i < 10; i++)
            {
                messageService.Save(new MessageContent()
                                        {
                                            IsSend = false,
                                            ToNumber = "134568684" + i.ToString(),
                                            MsgContent = "好啊，我是来测试的啊哈哈"
                                        });

            }

            IList<MessageContent> list = messageService.GetAllNoSend();
            Assert.IsNotNull(list);
        }

        #endregion

        #region Chart 测试
        [Test]
        public void AgeChartServiceTest()
        {
            //var service = DependencyResolver.Resolver<IChartService>();

            //DataTable dataTable = service.GetCustomerAgeStructure(DateTime.Now.AddYears(-50), DateTime.Now.AddYears(1));
            //for (int index = 0; index < dataTable.Rows.Count; index++)
            //{
            //    foreach (DataColumn column in dataTable.Columns)
            //    {
            //        this.Log(dataTable.Rows[index][column]);
            //    }
            //}
        }
        #endregion
        /// <summary>
        /// 检测依赖是否满足
        /// </summary>
        public void SayHello()
        {
            var service = DependencyResolver.Resolver<ICustomerService>();
        }

        #region 增加管理员
        /// <summary>
        /// 增加管理员
        /// </summary>
        [Test]
        public void AddAdmin()
        {

            var admin = _userInfoService.FindByUserName("ADMIN");

            if (admin == null)
            {
                // 员工信息基本信息
                Staff staff = new Staff();
                staff.Sex = Sex.Male;
                staff.Specialty = "admin";
                staff.Tel = "0571-";
                staff.Titles = " ";
                staff.WageBooksId = 0;
                staff.WorkAge = 25;

                this._userInfoService.SaveStaff(staff);


                OperatorUser operatorUser = new OperatorUser();
                operatorUser.OperatorName = "管理员";
                operatorUser.OperatorCode = "ADMIN";
                operatorUser.OperatorPass = ("admin").Md5();
                operatorUser.IsCrm = true;
                operatorUser.SetId(staff.Id);
                _userInfoService.Save(operatorUser);
                _userInfoService.Save(operatorUser);
            }
            else
            {
                admin.IsCrm = true;
                admin.UseFlag = 1;
                this._userInfoService.Update(admin);
            }
        }
        #endregion


        private void ExecuteNonQuery(string[] sql)
        {
            var session = NHibernateDatabaseFactory.GetSession();
            var connection = session.Connection;
            this.Log(connection.ConnectionString);

            var command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            try
            {
                foreach (string s in sql)
                {
                    command.CommandText = s;
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log(ex);
            }
        }

        /// <summary>
        /// 增加系统管理员角色
        /// </summary>
        public void AddRoleAdmin()
        {
            string roleName = "系统管理员";
            var role = DependencyResolver.Resolver<IRoleService>().FindByRoleName(roleName);

            if (role == null)
            {
                role = new Role() { RoleName = roleName, Remark = "CRM 系统管理员" };
                DependencyResolver.Resolver<IRoleService>().Save(role);
            }
            // 删除 CRM 系统管理员 原来的插件
            ExecuteNonQuery(new string[]{@"DELETE FROM Sys_RolePlug WHERE ROLEID IN (
SELECT ID FROM SYS_ROLE WHERE  ROLENAME ='系统管理员' AND SYSTEMNAME = 'CRM'
)"});
            // 给角色分配操作功能
            var pageQuery = new PageQuery<IDictionary<string, object>, Plug>(null);
            pageQuery.Condition = new Dictionary<string, object>();
            DependencyResolver.Resolver<IPlugService>().Query(pageQuery);

            foreach (Plug plug in pageQuery.Result.Where(m => m.Parent != null))
            {
                RolePlug rolePlug = new RolePlug();
                rolePlug.Role = role;
                rolePlug.Plug = plug;
                DependencyResolver.Resolver<IRolePlugService>().Save(rolePlug);
            }

        }
        /// <summary>
        /// 给管理员分配角色
        /// </summary>
        public void GrantFunToRole()
        {
            RoleOperator roleOperator = new RoleOperator();
            roleOperator.Role = DependencyResolver.Resolver<IRoleService>().FindByRoleName("系统管理员");
            roleOperator.User = _userInfoService.FindByUserName("ADMIN");

            DependencyResolver.Resolver<IRolePlugService>().Save(roleOperator);
        }
        /// <summary>
        /// 初始化数据字典
        /// </summary>
        public void CrmDictoryTest()
        {
            var dic = DependencyResolver.Resolver<ICrmDictionaryService>().FindByKey("SendMobileInfo");
            if (dic == null)
            {
                DependencyResolver.Resolver<ICrmDictionaryService>().Save(new CrmDictionary()
                                                                              {
                                                                                  Key = "SendMobileInfo",
                                                                                  Depict = "手机发送信息发送者号码"
                                                                              });
            }
        }
    }
}




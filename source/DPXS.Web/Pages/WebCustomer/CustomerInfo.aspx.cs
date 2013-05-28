using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WebCrm.Framework;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Web.Facade;
namespace WebCrm.Web.Pages.WebCustomer
{
    public partial class CustomerInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                var mode = DependencyResolver.Resolver<ICustomerService>().FindById(CustomerId);
                if (mode != null)
                {
                    Customer = mode;
                }
                else
                {
                    this.Response.Write("数据错误!");
                    this.Response.End();
                }
            }
        }

        /// <summary>
        /// 客户信息
        /// </summary>
        public Customer Customer { get; private set; }
        /// <summary>
        /// 散客扩展信息
        /// </summary>
        public WebCrm.Model.CustomerInfo PersonInfo
        {
            get { return DependencyResolver.Resolver<ICustomerInfoService>().FindByCustomerId(this.CustomerId); }
        }
        /// <summary>
        /// 企业扩展信息
        /// </summary>
        public CustomerCorpInfo CorpInfo
        {
            get
            {
                return DependencyResolver.Resolver<ICustomerCorpInfoService>().FindByCustomerId(this.CustomerId);
            }
        }
        public IList<CustomerVisitRecord> VisitRecords
        {
            get
            {
                return DependencyResolver.Resolver<ICustomerVisitRecordService>().FindByCustomerId(this.CustomerId);
            }
        }
        public IList<DiscussCustomerRecord> DiscussRecords
        {
            get
            {
                return DependencyResolver.Resolver<IDiscussCustomerRecordService>().FindByCustomerId(this.CustomerId);
            }
        }
        public IList<CustormerConsumRecord> ConsumRecords
        {
            get
            {
                return DependencyResolver.Resolver<ICustormerConsumRecordService>().FindByCustomerId(this.CustomerId);
            }
        }

        public IList<CustomerContactInfo> ContactList
        {
            get
            {
                return DependencyResolver.Resolver<ICustomerContactInfoService>().FindByCustomerId(this.CustomerId);
            }
        }
        private void PrintConsumeRecord(IList<CustormerConsumRecord> consumRecords)
        {

        }

        private void PrintDisRecord(IList<DiscussCustomerRecord> discussCustomerRecords)
        {

        }

        private void PrintVisitRecord(IList<CustomerVisitRecord> list)
        {

        }

        private void PrintCustomerCorpInfo(CustomerCorpInfo corInfo)
        {

        }

        private void PrintCustomerPersonInfo(Model.CustomerInfo personInfo)
        {

        }

        private void PrintCustomer(Customer customer)
        {

        }
        public int CustomerId
        {
            get
            {
                var id = this.Request.GetRequestValue("CustomerId");
                if (id.IsInt())
                {
                    return int.Parse(id);
                }
                return 0;
            }
        }

    }
}
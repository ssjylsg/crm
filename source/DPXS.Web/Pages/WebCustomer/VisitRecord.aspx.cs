using System;
using WebCrm.Framework;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Web.Facade;

namespace WebCrm.Web.Pages.WebCustomer
{
    public partial class VisitRecord : EditPage<CustomerVisitRecord, ICustomerVisitRecordService>
    {

        public ICustomerService CustomerService
        {
            get { return DependencyResolver.Resolver<ICustomerService>(); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropList();
                this.CurrentModel = this.Service.FindById(this.Id);
                if (this.NE == "edit")
                {
                    CustomerID.Enabled = false;
                }
            }
        }

        private void BindDropList()
        {
            AspNetHelper.BindCustomer(CustomerID);
            AspNetHelper.BindBussinessPerson(BusinessPeopleID);
        }


        public string CustomerName { get; set; }

        protected override void DataToFace(CustomerVisitRecord value)
        {
            if (value == null)
            {
                return;
            }
            if (value.Customer != null)
            {
                CustomerID.SelectedValue = value.Customer.Id.ToString();
            }
            this.VisitDateID.Text = value.VisitDate.ToShortDateString();
            this.OtherPersonID.Text = value.OtherPerson;
            if (value.BusinessPeople != null)
            {
                this.BusinessPeopleID.SelectedValue = value.BusinessPeople.Id.ToString();
            }
            this.Content.Text = value.Content;

            files.InnerHtml = AspNetHelper.DownLoadFile(value.Files);
        }

        protected override void FaceToData(ref CustomerVisitRecord record)
        {
            if (CustomerID.Text.IsInt())
            {
                record.Customer = this.CustomerService.FindById(int.Parse(CustomerID.Text));
            }
            record.VisitDate = DateTime.Parse(this.VisitDateID.Text);
            record.Content = this.Content.Text;
            record.OtherPerson = this.OtherPersonID.Text;
            if (BusinessPeopleID.Text.IsInt())
            {
                record.BusinessPeople = DependencyResolver.Resolver<IUserInfoService>().FindStaffById(int.Parse(BusinessPeopleID.Text));
            }
            record.Company = this.CurrentCompany;


            record.FileIds = record.FileIds + "," + Request.GetRequestValue("fileID").Trim(',');
        }



        protected override string PageTitle
        {
            get { return "客户回访记录"; }
        }


        protected override bool CheckData(out string errorMsg)
        {
            errorMsg = string.Empty;
            if (!this.CustomerID.SelectedValue.IsInt())
            {
                errorMsg = "请正确填写客户";
                return false;
            }
            if (!this.VisitDateID.Text.IsDateTime())
            {
                errorMsg = "请正确填写回访日期";
                this.VisitDateID.Focus();
            }
            if (!BusinessPeopleID.Text.IsInt())
            {
                errorMsg = "请选择业务人员";
                this.BusinessPeopleID.Focus();
            }
            if (!this.Content.Text.ValidStringLength())
            {
                errorMsg = string.Format("回访内容不能超过{0}个字符", SysConfig.StringMaxLength);
                this.Content.Focus();
                return false;
            }
            return true;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            this.SaveOrUpdate("VisitRecordList.aspx");
        }
    }


}
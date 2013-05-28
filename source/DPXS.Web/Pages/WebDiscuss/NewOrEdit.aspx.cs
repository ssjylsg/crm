using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WebCrm.Framework;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Web.Facade;

namespace WebCrm.Web.Pages.WebDiscuss
{
    public partial class NewOrEdit : EditPage<DiscussCustomerRecord, IDiscussCustomerRecordService>
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
                if (this.IsEdit)
                {
                    CustomerID.Enabled = false;
                }
            }
        }

        private void BindDropList()
        {
            var dic = new Dictionary<DropDownList, string>();
            dic.Add(this.State, "CustomerDiscussState");
            AspNetHelper.BindDropDown(dic);
            AspNetHelper.BindCustomer(this.CustomerID);
            AspNetHelper.BindBussinessPerson(this.BusinessPeopleID);
        }


        protected override void DataToFace(DiscussCustomerRecord value)
        {
            if (value == null)
            {
                return;
            }
            if (value.Customer != null)
            {
                CustomerID.SelectedValue = value.Customer.Id.ToString();
            }
            this.VisitDateID.Text = value.DiscussDate.ToShortDateString();
            this.OtherPersonID.Text = value.OtherPersonName;
            if (value.BussinessPerson != null)
            {
                this.BusinessPeopleID.SelectedValue = value.BussinessPerson.Id.ToString();
            }
            this.Content.Text = value.Content;
            if (value.State != null)
            {
                this.State.SelectedValue = value.State.Id.ToString();
            }

            files.InnerHtml = AspNetHelper.DownLoadFile(value.Files);
        }

        protected override void FaceToData(ref DiscussCustomerRecord record)
        {
            if (CustomerID.SelectedValue.IsInt())
            {
                record.Customer = this.CustomerService.FindById(int.Parse(CustomerID.SelectedValue));
            }
            record.DiscussDate = DateTime.Parse(this.VisitDateID.Text);
            record.Content = this.Content.Text;
            record.OtherPersonName = this.OtherPersonID.Text;
            if (this.BusinessPeopleID.SelectedValue.IsInt())
            {
                record.BussinessPerson = DependencyResolver.Resolver<IUserInfoService>().FindStaffById(int.Parse(this.BusinessPeopleID.SelectedValue));
            }
            if (this.State.SelectedValue.IsInt())
            {

                record.State =
                    DependencyResolver.Resolver<ICategoryItemService>().FindById(int.Parse(this.State.SelectedValue));
            }
            record.Company = this.CurrentCompany;

            record.FileIds = record.FileIds + "," + Request.GetRequestValue("fileID").Trim(',');
        }



        protected override string PageTitle
        {
            get { return "洽谈记录"; }
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
                errorMsg = string.Format("洽谈内容不能超过{0}个字符", SysConfig.StringMaxLength);
                this.Content.Focus();
                return false;
            }
            return true;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            this.SaveOrUpdate();
        }
    }


}
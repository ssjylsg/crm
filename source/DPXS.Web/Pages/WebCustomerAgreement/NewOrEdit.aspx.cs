using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Web.Facade;

namespace WebCX.Web.Pages.WebCustomerAgreement
{
    /// <summary>
    /// 大客户协议
    /// </summary>
    public partial class NewOrEdit : EditPage<CustomerAgreement, ICustomerAgreementService>
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ExpireID.IsSetDefaultValue = false;

                BindDropDownList();
                if (IsEdit)
                {
                    var model = this.Service.FindById(this.Id);
                    this.CurrentModel = model;

                    this.SubjectID.ReadOnly = true;
                    this.CustomerID.Enabled = model.Customer == null;
                }
            }
        }

        private void BindDropDownList()
        {

            var request = new Dictionary<DropDownList, string>();
            request[this.AgreementTypeID] = "AgreementType";
            AspNetHelper.BindDropDown(request);

            AspNetHelper.BindCustomer(this.CustomerID);
        }


        protected override string PageTitle
        {
            get { return "大客户协议"; }
        }

        protected override void DataToFace(CustomerAgreement model)
        {
            if (model == null)
            {
                return;
            }
            this.SubjectID.Text = model.Subject;
            this.ContentID.Text = model.Content;
            if (model.Customer != null)
            {
                this.CustomerID.SelectedValue = model.Customer.Id.ToString();
            }
            this.ExpireID.Text = model.Expire.HasValue
                                         ? model.Expire.Value.ToString("yyyy-MM-dd")
                                         : string.Empty;



            AspNetHelper.SetDropDownSelectedvalue(this.AgreementTypeID, model.AgreementType);

            this.RemarkID.Text = model.Remark;
            files.InnerHtml = AspNetHelper.DownLoadFile(model.FileIds);
        }

        protected override void FaceToData(ref CustomerAgreement model)
        {

            model.ModifyTime = DateTime.Now;

            if (!this.IsEdit)
            {
                model.CreateUser = this.CurrentOperatorUser;
            }

            model.Subject = this.SubjectID.Text;
            model.Content = this.ContentID.Text;
            var userService = WebCrm.Framework.DependencyResolver.Resolver<ICustomerService>();
            if (this.CustomerID.SelectedValue.IsInt())
            {
                model.Customer = userService.FindById(int.Parse(this.CustomerID.SelectedValue));
            }

            if (this.ExpireID.Text.IsDateTime())
            {
                model.Expire = DateTime.Parse(this.ExpireID.Text);
            }

            model.AgreementType = AspNetHelper.GetItemByDropDownValue(this.AgreementTypeID);
            model.Remark = this.RemarkID.Text;
            model.FileIds = model.FileIds + "," + Request.GetRequestValue("fileID").Trim(',');
        }

        protected override bool CheckData(out string errorMsg)
        {
            if (string.IsNullOrEmpty(this.SubjectID.Text))
            {
                errorMsg = "标题为必填项";
                this.SubjectID.Focus();
                return false;
            }
            if (!this.ContentID.Text.ValidStringLength())
            {
                errorMsg = "任务内容的最大长度为1000个字符";
                this.ContentID.Focus();
                return false;
            }

            if (!this.RemarkID.Text.ValidStringLength())
            {
                errorMsg = "备注信息不能超过1000个字符";
                this.RemarkID.Focus();
                return false;
            }
            errorMsg = string.Empty;
            return true;
        }
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            this.SaveOrUpdate();
        }
    }
}
using System;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Web.Facade;

namespace WebCX.Web.Pages.WebLoginInfo
{
    public partial class NewOrEdit : EditPage<OperatorUser, IUserInfoService>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindStuff();
                if (NE == "edit")
                {
                    lblTitle.Text = "编辑用户";
                    var model  = this.Service.FindById(this.Id);
                    CurrentModel = model;
                    this.CompanyId.Enabled = model.Company == null;
                }
                else
                {
                    txtPwd.Attributes.Add("value", "");
                    txtPwd2.Attributes.Add("value", "");
                    txtName.Text = string.Empty;
                }
            }
        }

        private void BindStuff()
        {
            AspNetHelper.BindCompany(CompanyId, this.CurrentCompany);
        }

        protected override string PageTitle
        {
            get { return "操作员"; }
        }

        protected override OperatorUser CurrentModel
        {
            get
            {
                var customer = this.Service.FindById(Id) ?? new OperatorUser();
                FaceToData(ref customer);
                return customer;
            }
            set
            {
                DataToFace(value);
            }
        }

        protected override void DataToFace(OperatorUser model)
        {
            txtName.Text = model.OperatorCode;
            txtRealName.Text = model.OperatorName;
            txtPwd.Attributes.Add("value", model.OperatorPass);
            txtPwd2.Attributes.Add("value", model.OperatorPass);

            ddlFlag.SelectedValue = "" + model.UseFlag;
            txtReamrk.Text = model.Remark;
            this.CompanyId.SelectedValue = model.Company != null ? model.Company.Id.ToString() : string.Empty;
        }

        protected override void FaceToData(ref OperatorUser model)
        {
            model.UseFlag = Convert.ToInt32(ddlFlag.SelectedValue);
            model.OperatorName = txtRealName.Text;

            if (model.OperatorPass != txtPwd.Text) ////改变以后就需要加密了
            {
                model.OperatorPass = (txtPwd.Text).Md5();
            }

            model.OperatorCode = txtName.Text.ToUpper();
            model.Optor = this.CurrentOperatorUser;
            model.Remark = txtReamrk.Text;

            if (this.CompanyId.SelectedValue.IsInt())
            {
                model.Company =
                WebCrm.Framework.DependencyResolver.Resolver<ICompanyService>().FindById(
                    int.Parse(this.CompanyId.SelectedValue));
            }

            model.IsCrm = true;
            model.Deleted = false;
            model.ModifyTime = DateTime.Now;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string errorMsg;
                if (!CheckData(out errorMsg))
                {
                    this.ShowMsg(errorMsg);
                    return;
                }
                var model = this.CurrentModel;
                if (!this.IsEdit)
                {
                    Staff staff = new Staff();
                    staff.Email = this.txtMail.Text;
                    staff.Company = model.Company;
                    staff.Phone = this.txtMobile.Text;
                    staff.Remark = txtReamrk.Text;
                    staff.RealName = model.OperatorName;

                    this.Service.SaveStaff(staff);
                    model.SetId(staff.Id);
                    Service.Save(model);
                }
                else
                {

                    var staff = this.Service.FindStaffById(this.Id);
                    staff.Email = this.txtMail.Text;
                    staff.Company = model.Company;
                    staff.Phone = this.txtMobile.Text;
                    staff.Remark = txtReamrk.Text;
                    staff.RealName = model.OperatorName;

                    Service.Update(model);
                }
                this.ShowMsg("操作成功", "List.aspx");
            }
            catch (Exception ex)
            {
                log4net.LogManager.GetLogger(this.GetType()).Error(ex);
                this.ShowMsg("出错，请尝试！");
            }
        }
        protected override bool CheckData(out string errorMsg)
        {
            bool existName = this.Service.ExistName(txtName.Text.Trim(), Id);
            if (existName)
            {
                errorMsg = ("用户名已经存在，请更改");
                return false;
            }
            if (!this.CompanyId.SelectedValue.IsInt())
            {
                errorMsg = "请选择部门";
                return false;
            }
            errorMsg = string.Empty;
            return true;
        }
        /// <summary>
        /// 检测用户名是否存在
        /// </summary>
        protected void CheckExistName()
        {
            string name = Request["name"];
            string id = Request["id"];
            var exist = this.Service.ExistName(name, int.Parse(id));
            Response.Write("{exist:" + exist + "}");
            Response.End();
        }
    }
}
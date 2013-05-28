using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WebCrm.Framework;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Web.Facade;

namespace WebCX.Web.Pages.WebSysRole
{
    public partial class NewOrEdit : EditPage<Role, IRoleService>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.IsEdit)
                {
                    lblTitle.Text = "编辑角色";
                    this.CurrentModel = this.Service.FindById(this.Id);
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            this.SaveOrUpdate();
        }

        protected override string PageTitle
        {
            get { return "角色"; }
        }

        protected override void DataToFace(Role model)
        {
            if (model == null)
            {
                return;
            }
            txtName.Text = model.RoleName;
            txtReamrk.Text = model.Remark;

        }

        protected override void FaceToData(ref Role model)
        {
            model.Remark = this.txtReamrk.Text;
            model.RoleName = this.txtName.Text;
            model.Optor = this.CurrentOperatorUser;
            model.Company = this.CurrentCompany;
            model.ModifyTime = DateTime.Now;
        }

        protected override bool CheckData(out string errorMsg)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                errorMsg = "角色名称不能为空";
                this.txtName.Focus();
                return false;
            }
            errorMsg = string.Empty;
            return true;
        }
    }
}
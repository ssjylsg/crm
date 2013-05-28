using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WebCrm.Framework;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Web.Facade;
using System.Linq;

namespace WebCX.Web.Pages.WebUser
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
                    CurrentModel = this.Service.FindById(this.Id);

                    StuffID.Enabled = false;
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
            StuffID.Items.Clear();
            List<ListItem> list = new List<ListItem>();
            var opr = this.Service.FindById(this.Id);

            if (opr != null)
            {
                list.Add(new ListItem() { Text = opr.OperatorName, Value = opr.Id.ToString() });
            }
            var currentUser = this.CurrentOperatorUser;
            list.AddRange(
                this.Service.GetNotOperater(currentUser.IsAdmin ? null : currentUser)
                    .Where(m => m.Deleted == false)
                    .Select(m => new ListItem() {Text = m.RealName, Value = m.Id.ToString()}));
            StuffID.Items.AddRange(list.Distinct().ToArray());
            StuffID.Items.Insert(0, new ListItem() { Text = "请选择", Value = string.Empty });
        }

        protected override string PageTitle
        {
            get { return "操作员"; }
        }

        protected override OperatorUser CurrentModel
        {
            get
            {
                var stuffId = int.Parse(this.StuffID.SelectedValue);
                var otherOpr = this.Service.FindById(stuffId); // 操作表中，是否包含了当前选择的人，但是此人没有权限登录CRM
                var customer = (otherOpr ?? new OperatorUser());
                if (otherOpr == null)
                {
                    customer.SetId(this.Service.FindStaffById(stuffId).Id);
                }
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
            var staff = this.Service.FindStaffById(this.Id);
            if (staff != null)
            {
                StuffID.SelectedValue = staff.Id.ToString();
            }
            ddlAdminFlag.SelectedValue = model.IsAdmin ? "1" : "0";
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
            var staff = this.Service.FindById(int.Parse(this.StuffID.SelectedValue));
            if (staff != null && staff.Company != null)
            {
                model.Company = staff.Company;
            }
            model.IsCrm = true;
            model.Deleted = false;
            model.ModifyTime = DateTime.Now;
            model.IsAdmin = ddlAdminFlag.SelectedValue == "1";
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
                var opr = this.Service.FindById(int.Parse(this.StuffID.SelectedValue));
                if (opr == null)
                {
                    Service.Save(this.CurrentModel);
                }
                else
                {
                    Service.Update(this.CurrentModel);
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
            if (!this.StuffID.SelectedValue.IsInt())
            {
                errorMsg = "请选择用户";
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
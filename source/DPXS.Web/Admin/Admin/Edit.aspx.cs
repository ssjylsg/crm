using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SendInfo.Common;
using SendInfo.CommonExt;
using SendInfo.CommonExt.PageHelper;
using DPXS.BLL;
using DPXS.Model;
using WebCX.Model;

namespace DPXS.Web.Admin.Admin
{
    public partial class Edit :AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindStatus();

                if (Id > 0)
                    LoadData();
            }
        }

        /// <summary>
        /// 编号
        /// </summary>
        public int Id
        {
            get { return DntRequest.GetQueryInt("id"); }
        }

        /// <summary>
        /// 绑定状态
        /// </summary>
        private void BindStatus()
        {
            EnumHelper.BindRBL<AdminStatus>(rblStatus);
            rblStatus.SelectedIndex = 0;
        }

        /// <summary>
        /// 载入数据
        /// </summary>
        private void LoadData()
        {
            var model = AdminBLL.Instance.GetModel(Id);
            if (model != null)
            {
                txtUserName.Text = model.UserName;
                txtPassword.Text = model.Password;
                txtRealName.Text = model.RealName;
                txtTel.Text = model.Tel;
                txtPhone.Text = model.Phone;
                txtEmail.Text = model.Email;
                txtQQ.Text = model.QQ;
                txtReamrk.Text = model.Remark;
                rblStatus.SelectedValue = model.Status.ToString();
            }
            else
                this.ShowMessage("实体不存在！");
        }

        /// <summary>
        /// 提交操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // 获取参数
            string userName = DntRequest.GetFormString("txtUserName");
            string password = DntRequest.GetFormString("txtPassword");
            string realName = DntRequest.GetFormString("txtRealName");
            string tel = DntRequest.GetFormString("txtTel");
            string phone = DntRequest.GetFormString("txtPhone");
            string email = DntRequest.GetFormString("txtEmail");
            string qq = DntRequest.GetFormString("txtQQ");
            string remark = DntRequest.GetFormString("txtReamrk");
            int status = DntRequest.GetFormInt("rblStatus");

            // 验证参数
            try
            {
                if (userName.IsNullOrEmpty())
                    throw new Exception("请输入用户名！");

                if (Id == 0)
                {
                    if (userName.ToLower() == "admin")
                        throw new Exception("该用户名已经存在！");

                    if (AdminBLL.Instance.ExistUserName(userName))
                        throw new Exception("该用户名已经存在！");

                    if (password.IsNullOrEmpty())
                        throw new Exception("请输入密码！");
                }
            }
            catch (Exception ex)
            {
                this.ShowMessage(ex.Message);
                return;
            }

            // 生成实体
            var model = Id > 0 ? AdminBLL.Instance.GetModel(Id) : new AdminModel();
            model.UserName = userName;
            model.RealName = realName;
            model.Tel = tel;
            model.Phone = phone;
            model.Email = email;
            model.QQ = qq;
            model.Remark = remark;
            model.Status = status;
            model.UpdateTime = DateTime.Now.ToString();

            if (!password.IsNullOrEmpty())
                password = (password + "DPXS").MD5();

            // 提交数据库
            if (Id > 0)
            {
                if (!password.IsNullOrEmpty())
                    model.Password = password;

                if (AdminBLL.Instance.Update(model))
                    Response.Redirect("List.aspx");
                else
                    this.ShowMessage("更新失败！");
            }
            else
            {
                model.ID = AdminBLL.Instance.GetNewID();
                model.Password = password;
                model.CreateTime = DateTime.Now.ToString();
                model.LastLoginTime = DateTime.Now.ToString();
                if (AdminBLL.Instance.Insert(model))
                    Response.Redirect("List.aspx");
                else
                    this.ShowMessage("添加失败！");
            }
        }
    }
}

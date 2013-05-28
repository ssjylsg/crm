using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WebCrm.Framework;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Web.Facade;

namespace WebCX.Web.Pages.WebCategory
{
    public partial class NewOrEdit : BasePage
    {
        public ICategoryService Service
        {
            get { return DependencyResolver.Resolver<ICategoryService>(); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.CurrentModel = this.Service.FindById(this.Id);
            }
        }
        public Category CurrentModel
        {
            get
            {
                Category customer = Id != 0 ? this.Service.FindById(Id) : new Category();
                FaceToData(ref customer);
                return customer;
            }
            set
            {
                DataToFace(value);
            }
        }

        private void DataToFace(Category value)
        {
            if (value == null)
            {
                return;
            }
            this.NameID.Text = value.Name;
            this.ValueID.Text = value.Value;
            this.DescriptionID.Text = value.Description;
            CodeID.Enabled = false; // Code 不容许编辑
            this.CodeID.Text = value.Code;
        }

        private void FaceToData(ref Category customer)
        {
            customer.Name = this.NameID.Text;
            customer.Value = this.ValueID.Text;
            customer.Description = this.DescriptionID.Text;
            // Code 不能编辑
            if (string.IsNullOrEmpty(customer.Code))
            {
                customer.Code = this.CodeID.Text;
            }
        }

        /// <summary>
        /// ID
        /// </summary>
        public int Id
        {
            get
            {
                string strId = Request.QueryString["Id"];
                if (string.IsNullOrEmpty(strId))
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(strId);
                }
            }
        }

        /// <summary>
        /// 新增或编辑
        /// </summary>
        public string NE
        {
            get { return Request.QueryString["NE"]; }
        }

        private bool CheckData(out string errorMsg)
        {
            errorMsg = string.Empty;
            var mode = this.CurrentModel;
            if (string.IsNullOrEmpty(mode.Name))
            {
                errorMsg = "名称不能为空";
                this.NameID.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(mode.Code))
            {
                errorMsg = "编号不能为空";
                this.CodeID.Focus();
                return false;
            }
            if (this.Service.ExisCode(mode.Code, this.Id))
            {
                errorMsg = "已经存在相同的编号";
                this.CodeID.Focus();
                return false;
            }
            return true;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string errorMsg;
            if (!CheckData(out errorMsg))
            {
                this.ShowMsg(errorMsg);
                return;
            }
            if (NE == "edit")
            {
                this.Service.Update(this.CurrentModel);
            }
            else
            {
                this.Service.Save(CurrentModel);
            }
            this.ShowMsg("操作成功", "List.aspx");
        }
    }


}
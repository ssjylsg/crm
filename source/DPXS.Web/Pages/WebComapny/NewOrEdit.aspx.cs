using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WebCrm.Framework;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Web.Facade;


namespace WebCX.Web.Pages.WebComapny
{
    public partial class NewOrEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.CurrentModel = this.Service.FindById(this.Id);
            }
        }
        public ICompanyService Service
        {
            get { return DependencyResolver.Resolver<ICompanyService>(); }
        }
        public Company CurrentModel
        {
            get
            {
                Company customer = Id != 0 ? this.Service.FindById(Id) : new Company();
                FaceToData(ref customer);
                return customer;
            }
            set
            {
                DataToFace(value);
            }
        }

        private void DataToFace(Company value)
        {
            txtParentName.Text = ParentName;
            if (value == null)
            {
                return;
            }

            this.NameID.Text = value.Name;
            this.FullNameID.Text = value.FullName;
            this.ZipCodeID.Text = value.ZipCode;
            this.AddressID.Text = value.Address;
            this.WebsiteID.Text = value.Website;
            this.FaxID.Text = value.Fax;
            this.RemarkID.Text = value.Remark;
        }

        private void FaceToData(ref Company customer)
        {
            if (customer == null)
            {
                customer = new Company();
                customer.Optor = this.CurrentOperatorUser;

            }
            customer.ModifyTime = DateTime.Now;
            customer.Name = this.NameID.Text;
            customer.FullName = this.FullNameID.Text;
            customer.ZipCode = this.ZipCodeID.Text;
            customer.Address = this.AddressID.Text;
            customer.Website = this.WebsiteID.Text;
            customer.Parent = this.Service.FindById(this.ParentId);
            customer.Fax = this.FaxID.Text;
            customer.Remark = this.RemarkID.Text;
        }

        /// <summary>
        /// 父节点编号
        /// </summary>
        public int ParentId
        {
            get
            {
                string strId = Request.QueryString["ParentId"];
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
        /// 父节点名称
        /// </summary>
        public string ParentName
        {
            get { return Request.QueryString["ParentName"]; }
        }

        /// <summary>
        /// 节点ID
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
        /// 节点名称
        /// </summary>
        public string Name
        {
            get { return Request.QueryString["Name"]; }
        }

        /// <summary>
        /// 新增或编辑
        /// </summary>
        public string NE
        {
            get { return Request.QueryString["NE"]; }
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (NE == "edit")
            {
                this.Service.Update(this.CurrentModel);

            }
            else
            {
                this.Service.Save(this.CurrentModel);
            }
            this.ShowMsg("操作成功", "List.aspx");
        }
    }
}
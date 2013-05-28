using System;
using System.Web.UI.WebControls;
using WebCrm.Framework;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Web.Facade;
using System.Linq;

namespace WebCX.Web.Pages.WebCategoryItem
{
    public partial class NewOrEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindComany();
                this.CurrentModel = this.Service.FindById(this.Id);
            }
        }
        private void BindComany()
        {
            var dept = this.Service.FindById(this.Id);
            txtParentName.Text = this.ParentName;
            if (dept != null)
            {

                CompanyID.Items.AddRange(dept.ChildDept.ToList().Where(m => m.Deleted == false).Select(
                    m => new ListItem() { Text = m.DeptName, Value = m.Id.ToString() }).ToArray());
                CompanyID.Items.Insert(0, new ListItem() { Text = dept.Company.Name, Value = dept.Company.Id.ToString() });
            }
            else
            {
                var companyList =
                    DependencyResolver.Resolver<ICompanyService>().GetComapnyList(string.Empty, 0).Where(
                        m => m.Deleted == false).ToList();
                CompanyID.Items.AddRange(
                    companyList.Select(m => new ListItem() { Text = m.Name, Value = m.Id.ToString() }).ToArray());
            }

        }
        public IDeptService Service
        {
            get { return DependencyResolver.Resolver<IDeptService>(); }
        }
        public Department CurrentModel
        {
            get
            {
                Department customer = Id != 0 ? this.Service.FindById(Id) : new Department();
                FaceToData(ref customer);
                return customer;
            }
            set
            {
                DataToFace(value);
            }
        }

        private void DataToFace(Department value)
        {
            if (value == null)
            {
                txtParentName.Text = ParentName;
                return;
            }

            this.DeptShortCodeID.Text = value.DeptShortCode;
            this.DeptNameID.Text = value.DeptName;
            this.RealNameID.Text = value.RealName;
            this.PYCodeID.Text = value.PYCode;
            this.TelNoID.Text = value.TelNo;
            this.FaxNoID.Text = value.FaxNo;
            this.EmailID.Text = value.Email;
            DeptCodeID.Text = value.DeptCode;
            DeptLeaderID.Text = value.DeptLeader;

            SortID.Text = value.Sort.ToString();
            this.RemarkID.Text = value.Remark;
        }

        private void FaceToData(ref Department customer)
        {
            if (customer == null)
            {
                customer = new Department();
                customer.OptorCode = this.CurrentOperatorUser.OperatorName;

            }
            customer.RealName = this.RealNameID.Text;
            customer.ModifyTime = DateTime.Now;
            customer.DeptShortCode = this.DeptShortCodeID.Text;
            customer.DeptName = this.DeptNameID.Text;
            customer.DeptCode = this.DeptCodeID.Text;

            customer.PYCode = this.PYCodeID.Text;
            customer.Parent = this.Service.FindById(this.ParentId);
            customer.FaxNo = this.FaxNoID.Text;
            customer.Remark = this.RemarkID.Text;

            customer.DeptLeader = this.DeptLeaderID.Text;
            customer.TelNo = this.TelNoID.Text;
            customer.Email = EmailID.Text;
            customer.Sort = int.Parse(SortID.Text);

            int companyid;
            if (int.TryParse(this.CompanyID.SelectedValue, out companyid))
            {
                customer.Company =
                    DependencyResolver.Resolver<ICompanyService>().FindById(companyid);
            }

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
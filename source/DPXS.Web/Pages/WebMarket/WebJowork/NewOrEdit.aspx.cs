using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WebCrm.Framework;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Web.Facade;

namespace WebCrm.Web.Pages.WebMarket.WebJowork
{
    public partial class NewOrEdit : BasePage
    {
        public ICooperationService Service
        {
            get { return DependencyResolver.Resolver<ICooperationService>(); }
        }
        public ICategoryItemService CategoryItemService
        {
            get { return DependencyResolver.Resolver<ICategoryItemService>(); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.CurrentModel = this.Service.FindById(this.Id);
            }
        }

        public Cooperation CurrentModel
        {
            get
            {
                var customer = Id != 0 ? this.Service.FindById(Id) : new Cooperation();
                FaceToData(ref customer);
                return customer;
            }
            set
            {
                DataToFace(value);
            }
        }

        private void DataToFace(Cooperation value)
        {
            if (value != null)
            {
                this.NameID.Text = value.Name; //姓名
                this.TelNoID.Text = value.TelNo;    //联系号码
                this.EmailID.Text = value.Email;  //Email
                this.ContactNameID.Text = value.ContactName;  //联系人姓名
                this.FaxID.Text = value.Fax; //传真
                this.AddressID.Text = value.Address;//地址
                this.CreateDateID.Text = value.CreateDate.ToShortDateString();//合作时间
                this.RemarkID.Text = value.Remark;//备注
            }
        }

        private void FaceToData(ref Cooperation value)
        {
            value.Name = this.NameID.Text;//姓名
            value.TelNo = this.TelNoID.Text;  //联系号码
            value.Email = this.EmailID.Text; //Email
            value.ContactName = this.ContactNameID.Text;//联系人姓名
            value.Fax = this.FaxID.Text;//传真
            value.Address = this.AddressID.Text;//地址
            value.CreateDate = DateTime.Parse(this.CreateDateID.Text);//合作时间
            value.Remark = this.RemarkID.Text;//备注

            value.Company = this.CurrentCompany;
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
            DateTime result;
            if (!DateTime.TryParse(this.CreateDateID.Text, out result))
            {
                errorMsg = "日期格式不正确";
                this.CreateDateID.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.NameID.Text))
            {
                errorMsg = "名称为必填项";
                this.NameID.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(this.ContactNameID.Text))
            {
                errorMsg = "请填写联系人姓名";
                this.ContactNameID.Focus();
                return false;
            }
            if (!this.RemarkID.Text.ValidStringLength())
            {
                errorMsg = string.Format("备注信息不能超过{0}个字符", SysConfig.StringMaxLength);
                this.RemarkID.Focus();
                return false;
            }
            if (!this.AddressID.Text.ValidStringLength(100))
            {
                errorMsg = string.Format("地址不能超过{0}个字符", 100);
                this.AddressID.Focus();
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
                this.ShowMsg("操作成功", "List.aspx");
            }
            else
            {
                this.Service.Save(CurrentModel);
                this.ShowMsg("操作成功", "List.aspx");
            }

        }
    }
}
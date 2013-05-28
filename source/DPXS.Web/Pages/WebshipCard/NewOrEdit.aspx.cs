using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WebCrm.Framework;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Web.Facade;

namespace WebCX.Web.Pages.WebshipCard
{
    public partial class NewOrEdit : BasePage
    {
        public IMembershipCardService Service
        {
            get { return DependencyResolver.Resolver<IMembershipCardService>(); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindDropdown();
                this.CurrentModel = this.Service.FindById(this.Id);
            }
        }

        private void BindDropdown()
        {
            var dic = new Dictionary<DropDownList, string>();
            dic[this.CardTypeID] = "VipCategory";
            AspNetHelper.BindDropDown(dic);
        }
        public MembershipCard CurrentModel
        {
            get
            {
                var customer = Id != 0 ? this.Service.FindById(Id) : new MembershipCard();
                FaceToData(ref customer);
                return customer;
            }
            set
            {
                DataToFace(value);
            }
        }

        private void DataToFace(MembershipCard value)
        {
            if (value == null)
            {
                return;
            }
            this.CardCodeID.Text = value.CardCode;
            this.ValidDateID.Text = value.ValidDate.ToShortDateString();
            this.DescriptionID.Text = value.Description;
            if (value.CardType != null)
            {
                this.CardTypeID.SelectedValue = value.CardType.Id.ToString();
            }
        }

        private void FaceToData(ref MembershipCard value)
        {
            value.CardCode = this.CardCodeID.Text;
            value.ValidDate = DateTime.Parse(this.ValidDateID.Text);
            value.Description = this.DescriptionID.Text;
            if (this.CardTypeID.SelectedValue.IsInt())
            {
                value.CardType =
                    DependencyResolver.Resolver<ICategoryItemService>().FindById(int.Parse(this.CardTypeID.Text));
            }
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

        //private bool CheckData(out string errorMsg)
        //{
        //    errorMsg = string.Empty;
        //    DateTime result;
        //    if (!DateTime.TryParse(this.ValidDateID.Text, out result))
        //    {
        //        errorMsg = "日期格式不正确";
        //        this.ValidDateID.Focus();
        //        return false;
        //    }
        //    if (!this.CardTypeID.SelectedValue.IsInt())
        //    {
        //        errorMsg = "请选择会员卡类型";
        //        this.CardTypeID.Focus();
        //        return false;
        //    }
        //    return true;
        //}
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
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
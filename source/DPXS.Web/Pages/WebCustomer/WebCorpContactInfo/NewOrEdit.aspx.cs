using System;
using WebCrm.Framework;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Web.Facade;

namespace WebCrm.Web.Pages.WebCorpContactInfo
{
    public partial class NewOrEdit : EditPage<CustomerContactInfo, ICustomerContactInfoService>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                var model = this.Service.FindById(this.Id);
                this.CurrentModel = model;
            }
        }

        protected override string PageTitle
        {
            get { return "散客"; }
        }

        protected override void DataToFace(CustomerContactInfo value)
        {
            if (value == null)
            {
                var customer = DependencyResolver.Resolver<ICustomerService>().FindById(this.CustomerId);
                if (customer != null)
                {
                    this.CustomerName.Text = (string.IsNullOrEmpty(customer.ShortName) ? customer.Name : customer.ShortName) +
                                             "    " + customer.Code;
                }
                return;
            }

            if (value.Customer != null)
            {
                this.CustomerName.Text = (string.IsNullOrEmpty(value.Customer.ShortName) ? value.Customer.Name : value.Customer.ShortName) +
                                         "    " + value.Customer.Code;
            }
            this.NameID.Text = value.Name;
            this.SexID.SelectedValue = value.Sex;
            this.TelNumberID.Text = value.TelNumber;
            this.DutyNameID.Text = value.DutyName;
            this.BirthdayID.Text = value.Birthday.HasValue ? value.Birthday.Value.ToShortDateString() : string.Empty;
            this.EmailID.Text = value.Email;
            this.MSNID.Text = value.MSN;
            this.IdCardID.Text = value.IdCard;
            this.NativePlaceID.Text = value.NativePlace;
            this.FavoritesID.Text = value.Favorites;
            this.RemarkID.Text = value.Remark;
            this.QQID.Text = value.QQ;
            this.AddressID.Text = value.Address;
            this.PhoneNumberID.Text = value.PhoneNumber;
        }

        protected override void FaceToData(ref CustomerContactInfo record)
        {
            if (record.Customer == null)
            {
                record.Customer = DependencyResolver.Resolver<ICustomerService>().FindById(this.CustomerId);
            }
            record.ModifyTime = DateTime.Now;
            record.Name = this.NameID.Text;
            record.Sex = this.SexID.SelectedValue;
            record.TelNumber = this.TelNumberID.Text;
            record.DutyName = this.DutyNameID.Text;
            if (BirthdayID.Text.IsDateTime())
            {
                record.Birthday = DateTime.Parse(this.BirthdayID.Text);
            }
            record.Email = this.EmailID.Text;
            record.MSN = this.MSNID.Text;
            record.IdCard = this.IdCardID.Text;
            record.NativePlace = this.NativePlaceID.Text;
            record.Favorites = this.FavoritesID.Text;
            record.Remark = this.RemarkID.Text;
            record.QQ = this.QQID.Text;
            record.Address = AddressID.Text;
            record.PhoneNumber = PhoneNumberID.Text;
        }

        public int CustomerId
        {
            get
            {
                var corpId = Request.QueryString["CustomerId"];
                if (corpId.IsInt())
                {
                    return int.Parse(corpId);
                }
                return 0;
            }
        }


        protected override bool CheckData(out string errorMsg)
        {
            errorMsg = string.Empty;
            if(!this.FavoritesID.Text.ValidStringLength())
            {
                errorMsg = string.Format("个人喜好不能超过{0}个字符!", SysConfig.StringMaxLength);
                return false;
            }
            if (!this.RemarkID.Text.ValidStringLength())
            {
                errorMsg = string.Format("备注信息不能超过{0}个字符!", SysConfig.StringMaxLength);
                return false;
            }
            return true;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            this.SaveOrUpdate(string.Format("list.aspx?CustomerID={0}", this.CustomerId));
        }
    }
}
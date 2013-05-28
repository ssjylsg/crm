using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WebCrm.Framework;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Web.Facade;

namespace WebCX.Web.Pages.WebFinancial
{
    public partial class NewOrEdit : EditPage<Financial, IFinancialService>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDownList();
                if (NE == "edit")
                {
                    this.CurrentModel = this.Service.FindById(this.Id);
                }
            }
        }
        public bool IsPay
        {
            get { return FinancialType.Equals("pay", StringComparison.CurrentCultureIgnoreCase); }
        }
        public string FinancialType
        {
            get
            {
                var type = Request.GetRequestValue("FinancialType");
                if (string.IsNullOrEmpty(type))
                {
                    type = "pay";
                }
                return type;
            }
        }
        private void BindDropDownList()
        {
            if (this.IsPay)
            {
                AspNetHelper.BindCooperation(this.CustomerID);
            }
            else
            {
                AspNetHelper.BindCustomer(this.CustomerID);
            }
            this.StateId.Items.Clear();
            this.StateId.Items.AddRange(new ListItem[]
                                            {
                                                new ListItem() {Text = "是", Value = "1"},
                                                new ListItem() {Text = "否", Value = "0", Selected = true}
                                            });

            AspNetHelper.BindBussinessPerson(this.ChargePersonID);

            if(this.IsPay)
            {
                Dictionary<DropDownList,string> request = new Dictionary<DropDownList, string>();
                request[FinancialPayTypeID] = "FinancialPayType";
                AspNetHelper.BindDropDown(request);
            }
        }


        protected override string PageTitle
        {
            get { return "财务"; }
        }

        protected override void DataToFace(Financial model)
        {
            if (model == null)
            {
                return;
            }
            this.NameID.Text = model.Name;
            StateId.SelectedValue = model.State ? "1" : "0";
            this.CustomerNameID.Text = model.CustomerName;
            this.FinancialDateID.Text = model.FinancialDate.ToShortDateString();


            if (model.ChargePerson != null)
            {
                ChargePersonID.SelectedValue = model.ChargePerson.Id.ToString();
            }
            if (model.FinancialType == WebCrm.Model.FinancialType.Receive)
            {
                if (model.Customer != null)
                {
                    this.CustomerID.SelectedValue = model.Customer.Id.ToString();
                    this.CustomerNameID.Text = model.Customer.ShortName;
                }
            }
            else
            {
                if (model.Cooperation != null)
                {
                    this.CustomerID.SelectedValue = model.Cooperation.Id.ToString();
                    this.CustomerNameID.Text = model.Cooperation.Name;
                }
            }

            this.SumPriceID.Text = model.SumPrice.ToString();
            this.TreatResultID.Text = model.TreatResult;

            this.RemarkID.Text = model.Remark;
            files.InnerHtml = AspNetHelper.DownLoadFile(model.FiledIds);
            if (this.IsPay)
            {
                 AspNetHelper.SetDropDownSelectedvalue(this.FinancialPayTypeID,model.FinancialPayType);
            }
        }

        protected override void FaceToData(ref Financial model)
        {

            model.ModifyTime = DateTime.Now;

            model.Name = this.NameID.Text;
            model.State = StateId.SelectedValue == "1";
            model.CustomerName = this.CustomerNameID.Text;
            model.FinancialDate = DateTime.Parse(this.FinancialDateID.Text);

            model.FinancialType = this.IsPay ? WebCrm.Model.FinancialType.Pay : WebCrm.Model.FinancialType.Receive;

            model.ChargePerson =
                DependencyResolver.Resolver<IUserInfoService>().FindById(int.Parse(ChargePersonID.SelectedValue));


            if (model.FinancialType == WebCrm.Model.FinancialType.Receive)
            {

                model.Customer =
                    DependencyResolver.Resolver<ICustomerService>().FindById(int.Parse(this.CustomerID.SelectedValue));

                if (model.Customer != null)
                {
                    model.CustomerName = this.CustomerNameID.Text;
                }

            }
            else
            {

                model.Cooperation =
                    DependencyResolver.Resolver<ICooperationService>().FindById(int.Parse(this.CustomerID.SelectedValue));


                if (model.Cooperation != null)
                {
                    model.CustomerName = this.CustomerNameID.Text;
                }

            }

            model.SumPrice = decimal.Parse(this.SumPriceID.Text);
            model.TreatResult = this.TreatResultID.Text;
            model.Remark = this.RemarkID.Text;
            if (!this.IsEdit)
            {
                model.Company = this.CurrentCompany;
            }
            model.FiledIds = model.FiledIds + "," + Request.GetRequestValue("fileID").Trim(',');
            if(this.IsPay)
            {
                model.FinancialPayType = AspNetHelper.GetItemByDropDownValue(this.FinancialPayTypeID);
            }
        }

        protected override bool CheckData(out string errorMsg)
        {

            if (string.IsNullOrEmpty(this.NameID.Text))
            {
                errorMsg = "名称为必填项";
                this.NameID.Focus();
                return false;
            }
            if (!this.SumPriceID.Text.IsDecimal())
            {
                errorMsg = "金额需为数字";
                this.SumPriceID.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.CustomerNameID.Text) && !this.CustomerID.SelectedValue.IsInt())
            {
                errorMsg = (this.IsPay ? "收款单位" : "欠款单位") + "为必填项";
                this.CustomerNameID.Focus();
                return false;
            }
            if (!this.FinancialDateID.Text.IsDateTime())
            {
                errorMsg = (this.IsPay ? "应付日期" : "欠款起始日") + "为必填项";
                this.FinancialDateID.Focus();
                return false;
            }
            if (!this.ChargePersonID.SelectedValue.IsInt())
            {
                errorMsg = "负责人为必填项";
                return false;
            }
            if (!this.RemarkID.Text.ValidStringLength())
            {
                errorMsg = string.Format("备注信息不能超过{0}个字符", SysConfig.StringMaxLength);
                this.RemarkID.Focus();
                return false;
            }
            if (!this.TreatResultID.Text.ValidStringLength())
            {
                errorMsg = string.Format("处理结果不能超过{0}个字符", SysConfig.StringMaxLength);
                this.TreatResultID.Focus();
                return false;
            }
            errorMsg = string.Empty;
            return true;
        }
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            this.SaveOrUpdate(string.Format("List.aspx?FinancialType={0}", this.FinancialType));
        }
    }
}
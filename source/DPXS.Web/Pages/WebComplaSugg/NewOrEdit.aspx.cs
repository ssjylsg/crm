using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WebCrm.Framework;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Web.Facade;

namespace WebCrm.Web.Pages.WebComplaSugg
{
    public partial class NewOrEdit : EditPage<Suggest, ISuggestService>
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindDropDown();
                if (NE == "edit")
                {
                    this.CurrentModel = this.Service.FindById(this.Id);
                }
            }
        }
        public bool IsPay
        {
            get { return SuggestComplaints.Equals("Complaints", StringComparison.CurrentCultureIgnoreCase); }
        }
        public string SuggestComplaints
        {
            get
            {
                var type = Request.GetRequestValue("SuggestComplaints");
                if (string.IsNullOrEmpty(type))
                {
                    type = "Complaints";
                }
                return type;
            }
        }

        private void BindDropDown()
        {

            AspNetHelper.BindCustomer(this.CustomerID);

            var dic = new Dictionary<DropDownList, string>();
            dic[this.SuggestTypeID] = "SuggestType";
            dic[this.SolveTypeID] = "SolveType";
            AspNetHelper.BindDropDown(dic);

            AspNetHelper.BindBussinessPerson(HandlerPersonID);
            AspNetHelper.BindBussinessPerson(DealPersonID);
        }


        protected override string PageTitle
        {
            get { return "投诉建议"; }
        }

        protected override void DataToFace(Suggest model)
        {
            if (model == null)
            {
                return;
            }

            this.CustomerID.Text = model.CustoMerName;
            this.SuggestDateID.Text = model.SuggestDate.ToShortDateString();
            this.SolveDateID.Text = model.SolveDate.ToShortDateString();

            if (model.Customer != null)
            {
                this.CustomerID.SelectedValue = model.Customer.Id.ToString();
            }
            this.CustomerNameID.Text = model.CustoMerName;

            this.ContentID.Text = model.Content;
            this.SolveResultsID.Text = model.SolveResults;
            AspNetHelper.SetDropDownSelectedvalue(this.SuggestTypeID, model.SuggestType);
            AspNetHelper.SetDropDownSelectedvalue(this.SolveTypeID, model.SolveType);
            if (model.HandlerPerson != null)
            {
                HandlerPersonID.SelectedValue = model.HandlerPerson.Id.ToString();
            }
            if (model.DealPerson != null)
            {
                DealPersonID.SelectedValue = model.DealPerson.Id.ToString();
            }
            files.InnerHtml = AspNetHelper.DownLoadFile(model.Files);
        }

        protected override void FaceToData(ref Suggest model)
        {
            model.ModifyTime = DateTime.Now;

            model.CustoMerName = this.CustomerNameID.Text;
            model.SuggestDate = DateTime.Parse(this.SuggestDateID.Text);
            model.SolveDate = DateTime.Parse(this.SolveDateID.Text);
            model.SuggestComplaints = this.IsPay ? WebCrm.Model.SuggestComplaints.Complaints : WebCrm.Model.SuggestComplaints.Suggest;

            model.CustoMerName = this.CustomerNameID.Text;
            if (this.CustomerID.SelectedValue.IsInt())
                model.Customer =
                    DependencyResolver.Resolver<ICustomerService>().FindById(
                        int.Parse(this.CustomerID.SelectedValue));
            model.Content = this.ContentID.Text;
            model.SolveResults = this.SolveResultsID.Text;
            model.SolveType = AspNetHelper.GetItemByDropDownValue(this.SolveTypeID);
            model.SuggestType = AspNetHelper.GetItemByDropDownValue(this.SuggestTypeID);
            if (!this.IsEdit)
            {
                model.Company = this.CurrentCompany;
            }

            model.FileIds = model.FileIds + "," + Request.GetRequestValue("fileID").Trim(',');
            var userService = DependencyResolver.Resolver<IUserInfoService>();
            if (HandlerPersonID.SelectedValue.IsInt())
            {
                model.HandlerPerson = userService.FindById(int.Parse(this.HandlerPersonID.SelectedValue));
            }
            if (this.DealPersonID.SelectedValue.IsInt())
            {
                model.DealPerson = userService.FindById(int.Parse(this.DealPersonID.SelectedValue));
            }

        }

        protected override bool CheckData(out string errorMsg)
        {

            errorMsg = string.Empty;
            if (!this.ContentID.Text.ValidStringLength())
            {
                errorMsg = "投诉内容不能超过1000个字符";
                this.ContentID.Focus();
                return false;
            }
            if (!this.SolveResultsID.Text.ValidStringLength())
            {
                errorMsg = "解决结果不能超过1000个字符";
                this.SolveResultsID.Focus();
                return false;
            }
            errorMsg = string.Empty;
            return true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            this.SaveOrUpdate(string.Format("List.aspx?SuggestComplaints={0}", this.SuggestComplaints));
        }

    }
}
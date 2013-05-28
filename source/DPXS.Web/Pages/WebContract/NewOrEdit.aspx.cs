using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WebCrm.Framework;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Web.Facade;

namespace WebCX.Web.Pages.WebContract
{
    public partial class NewOrEdit : EditPage<Contract, IContractService>
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindDropDownList();
                if (IsEdit)
                {
                    this.CurrentModel = this.Service.FindById(this.Id);
                    ContractNameID.ReadOnly = true;
                    this.CodeID.ReadOnly = true;
                    this.CustomerID.Enabled = false;
                    this.CustomerNameID.ReadOnly = true;
                }
            }
        }

        private void BindDropDownList()
        {
            AspNetHelper.BindCustomer(this.CustomerID);
            AspNetHelper.BindBussinessPerson(this.SignPersonID);
            this.SettleStateID.Items.Clear();
            this.SettleStateID.Items.AddRange(AspNetHelper.GetFieldDescription(typeof(SettleState)));
            // 合同状态
            Dictionary<DropDownList, string> dic = new Dictionary<DropDownList, string>();
            dic[this.StateId] = "ContractState";
            AspNetHelper.BindDropDown(dic);

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


        protected override string PageTitle
        {
            get { return "合同"; }
        }

        protected override void DataToFace(Contract model)
        {
            if (model == null)
            {
                return;
            }
            this.ContractNameID.Text = model.ContractName;
            AspNetHelper.SetDropDownSelectedvalue(StateId, model.State);
            if (model.Customer != null)
            {
                this.CustomerID.SelectedValue = model.Customer.Id.ToString();
            }
            this.CodeID.Text = model.ContractName;
            this.StartDateID.Text = model.StartDate.ToShortDateString();
            this.EndDateID.Text = model.EndDate.ToShortDateString();

            if (model.SignPerson != null)
            {
                SignPersonID.SelectedValue = model.SignPerson.Id.ToString();
            }
            this.CustomerSignPersonID.Text = model.CustomerSignPerson;
            this.SignDateID.Text = model.SignDate.ToShortDateString();

            this.SignAddressID.Text = model.SignAddress;
            this.StorePlaceID.Text = model.StorePlace;
            this.SumID.Text = model.Sum.ToString();

            this.SettleStateID.SelectedValue = ((int)model.SettleState).ToString();
            this.RemarkID.Text = model.Remark;
            this.ContentID.Text = model.Content;
            CustomerNameID.Text = model.CustomerName;


            files.InnerHtml = AspNetHelper.DownLoadFile(model.FiledIds);
        }

        protected override void FaceToData(ref Contract model)
        {

            model.ModifyTime = DateTime.Now;

            model.ContractName = this.ContractNameID.Text;
            model.State = AspNetHelper.GetItemByDropDownValue(this.StateId);

            if (CustomerID.SelectedValue.IsInt())
            {
                model.Customer =
                    DependencyResolver.Resolver<ICustomerService>().FindById(
                        int.Parse(this.CustomerID.SelectedValue));
            }

            if (model.Customer != null)
            {
                model.CustomerName = model.Customer.ShortName;
            }
            else
            {
                model.CustomerName = CustomerNameID.Text;
            }

            model.ContractName = this.CodeID.Text;
            model.StartDate = DateTime.Parse(this.StartDateID.Text);
            model.EndDate = DateTime.Parse(this.EndDateID.Text);


            model.SignPerson =
                DependencyResolver.Resolver<IUserInfoService>().FindById(int.Parse(SignPersonID.SelectedValue));

            model.CustomerSignPerson = this.CustomerSignPersonID.Text;
            model.SignDate = DateTime.Parse(this.SignDateID.Text);

            model.SignAddress = this.SignAddressID.Text;
            model.StorePlace = this.StorePlaceID.Text;
            model.Sum = decimal.Parse(this.SumID.Text);

            model.SettleState = this.SettleStateID.SelectedValue.Convert<SettleState>();
            model.Remark = this.RemarkID.Text;
            model.Content = this.ContentID.Text;

            model.Company = this.CurrentCompany;


            model.FiledIds = model.FiledIds + "," + Request.GetRequestValue("fileID").Trim(',');
        }

        protected override bool CheckData(out string errorMsg)
        {

            if (string.IsNullOrEmpty(this.ContractNameID.Text))
            {
                errorMsg = "名称为必填项";
                this.ContractNameID.Focus();
                return false;
            }
            if (!this.ContentID.Text.ValidStringLength())
            {
                errorMsg = "合同内容的最大长度为1000个字符";
                return false;
            }
            if(!this.RemarkID.Text.ValidStringLength())
            {
                errorMsg = "备注信息不能超过1000个字符";
                return false;
            }
            errorMsg = string.Empty;
            return true;
        }

        /// <summary>
        /// 节点名称
        /// </summary>
        public string Name
        {
            get { return Request.QueryString["Name"]; }
        }


        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            this.SaveOrUpdate();
        }
    }
}
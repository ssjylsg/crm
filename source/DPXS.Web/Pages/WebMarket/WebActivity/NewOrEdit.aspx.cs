using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WebCrm.Framework;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Web.Facade;
using System.Data;
namespace WebCrm.Web.Pages.WebMarket.WebActivity
{
    public partial class NewOrEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSalesDDL();
                this.BindDropDown();
                this.CurrentModel = this.Service.FindById(this.Id);
            }
        }
        public ICooperationService GetService
        {
            get { return DependencyResolver.Resolver<ICooperationService>(); }
        }
        private void BindDropDown()
        {
            var dic = new Dictionary<DropDownList, string>();
            dic[this.StateID] = "CompanyAction_State";
            dic[this.EvaluateID] = "CompanyAction_Evaluate";

            AspNetHelper.BindDropDown(dic);
        }

        /// <summary>
        /// 绑定合作单位下拉列表
        /// </summary>
        protected void BindSalesDDL()
        {

            DropWorkNameID.Items.Clear();

            var request = new PageQuery<IDictionary<string, object>, Cooperation>(null);
            request.Condition = new Dictionary<string, object>();
            request.SetQueryAll();

            DependencyResolver.Resolver<ICooperationService>().Query(request);

            DropWorkNameID.Items.AddRange(
                request.Result.Select(m => new ListItem() { Text = m.Name, Value = m.Id.ToString() }).ToArray());
            DropWorkNameID.Items.Insert(0, new ListItem("请选择", ""));
        }

        public CompanyAction CurrentModel
        {
            get
            {
                var customer = Id != 0 ? this.Service.FindById(Id) : new CompanyAction();
                FaceToData(ref customer);
                return customer;
            }
            set
            {
                DataToFace(value);
            }
        }

        public ICompanyActionService Service
        {
            get { return DependencyResolver.Resolver<ICompanyActionService>(); }
        }
        public ICategoryItemService CategoryItemService
        {
            get { return DependencyResolver.Resolver<ICategoryItemService>(); }
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

        private void DataToFace(CompanyAction value)
        {
            if (value == null)
            {
                FreeID.Text = "0";
                return;
            }
            this.NameID.Text = value.Name;
            this.ContentID.Text = value.Content;
            this.RemarkID.Text = value.Remark;
            this.FreeID.Text = value.Free.ToString();
            this.ActionDateID.Text = value.ActionDate.ToShortDateString();
            if (value.WorkName != null)
            {
                this.DropWorkNameID.SelectedValue = value.WorkName.Id.ToString();
            }

            AspNetHelper.SetDropDownSelectedvalue(this.StateID, value.State);
            AspNetHelper.SetDropDownSelectedvalue(this.EvaluateID, value.Evaluate);
            files.InnerHtml = AspNetHelper.DownLoadFile(value.FiledIds);
        }

        private void FaceToData(ref CompanyAction value)
        {
            value.Name = this.NameID.Text;
            value.Content = this.ContentID.Text;
            value.Remark = this.RemarkID.Text;
            value.Free = decimal.Parse(this.FreeID.Text);
            value.ActionDate = DateTime.Parse(this.ActionDateID.Text);
            if (this.DropWorkNameID.SelectedValue.IsInt())
            {
                value.WorkName = DependencyResolver.Resolver<ICooperationService>().FindById(int.Parse(this.DropWorkNameID.SelectedValue));
            }
            value.State = AspNetHelper.GetItemByDropDownValue(this.StateID);
            value.Evaluate = AspNetHelper.GetItemByDropDownValue(this.EvaluateID);
            value.FiledIds = value.FiledIds + "," + Request.GetRequestValue("fileID").Trim(',');
            if(value.Company != null)
            {
                value.Company = this.CurrentCompany;
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
            DateTime result;
            if (!DateTime.TryParse(this.ActionDateID.Text, out result))
            {
                errorMsg = "日期格式不正确";
                this.ActionDateID.Focus();
                return false;
            }
            if (!this.RemarkID.Text.ValidStringLength())
            {
                errorMsg = string.Format("备注信息不能超过{0}个字符", SysConfig.StringMaxLength);
                this.RemarkID.Focus();
                return false;
            }
            if (!this.ContentID.Text.ValidStringLength())
            {
                errorMsg = string.Format("内容不能超过{0}个字符", SysConfig.StringMaxLength);
                this.ContentID.Focus();
                return false;
            }
            if (!this.StateID.SelectedValue.IsInt())
            {
                errorMsg = "请选择状态";
                this.StateID.Focus();
                return false;
            }
            if (!this.DropWorkNameID.SelectedValue.IsInt())
            {
                errorMsg = "请选择合作单位";
                this.DropWorkNameID.Focus();
                return false;
            }
            if (!this.EvaluateID.SelectedValue.IsInt())
            {
                errorMsg = "请选择评价";
                this.EvaluateID.Focus();
                return false;
            }
            if (!this.FreeID.Text.IsDecimal())
            {
                errorMsg = "请正确填写费用";
                this.FreeID.Focus();
                return false;
            }
            return true;
        }

    }
}
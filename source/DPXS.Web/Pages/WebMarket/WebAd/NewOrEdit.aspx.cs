using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WebCrm.Framework;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Web.Facade;
using System.Data;


namespace WebCX.Web.Pages.WebAd
{
    public partial class NewOrEdit : BasePage
    {
        public IAdvertisingService Service
        {
            get { return DependencyResolver.Resolver<IAdvertisingService>(); }
        }
        public ICooperationService GetService
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
                this.BindDropDown();
                BindSalesDDL();
                this.CurrentModel = this.Service.FindById(this.Id);
            }
        }

        private void BindDropDown()
        {
            var dic = new Dictionary<DropDownList, string>();
            dic[this.ChannelID] = "Advertising_Channel";
            dic[this.StateID] = "Advertising_State";
            dic[this.EvaluateID] = "Advertising_Evaluate";

            AspNetHelper.BindDropDown(dic);
        }
        /// <summary>
        /// 绑定合作单位下拉列表
        /// </summary>
        protected void BindSalesDDL()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();

            var dt = GetService.GetByCondition(dict, "Name");
            DropWorkNameID.Items.Clear();
            DropWorkNameID.Items.Add(new ListItem("请选择", ""));
            foreach (DataRow row in dt.Rows)
            {
                this.DropWorkNameID.Items.Add(new ListItem("" + row[0], "" + row[0]));
            }
        }
        public Advertising CurrentModel
        {
            get
            {
                var customer = Id != 0 ? this.Service.FindById(Id) : new Advertising();
                FaceToData(ref customer);
                return customer;
            }
            set
            {
                DataToFace(value);
            }
        }

        private void DataToFace(Advertising value)
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
            this.DeliveryDateID.Text = value.DeliveryDate.ToShortDateString();
            this.DropWorkNameID.Text = value.WorkName;
            AspNetHelper.SetDropDownSelectedvalue(this.StateID, value.State);
            AspNetHelper.SetDropDownSelectedvalue(this.EvaluateID, value.Evaluate);
            AspNetHelper.SetDropDownSelectedvalue(ChannelID, value.Channel);
            files.InnerHtml = AspNetHelper.DownLoadFile(value.FiledIds);
        }

        private void FaceToData(ref Advertising value)
        {
            value.Name = this.NameID.Text;
            value.Content = this.ContentID.Text;
            value.Remark = this.RemarkID.Text;
            value.Free = decimal.Parse(this.FreeID.Text);
            value.DeliveryDate = DateTime.Parse(this.DeliveryDateID.Text);
            value.WorkName = this.DropWorkNameID.Text;

            value.State = AspNetHelper.GetItemByDropDownValue(this.StateID);
            value.Evaluate = AspNetHelper.GetItemByDropDownValue(this.EvaluateID);
            value.Channel = AspNetHelper.GetItemByDropDownValue(this.ChannelID);
            value.Company = this.CurrentCompany;
            value.FiledIds = value.FiledIds + "," + Request.GetRequestValue("fileID").Trim(',');
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


            if (!DateTime.TryParse(this.DeliveryDateID.Text, out result))
            {
                errorMsg = "日期格式不正确";
                this.DeliveryDateID.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.NameID.Text))
            {
                errorMsg = "名称为必填项";
                this.NameID.Focus();
                return false;
            }
            if (!this.StateID.SelectedValue.IsInt())
            {
                errorMsg = "请选择状态";
                this.StateID.Focus();
                return false;
            }
            if (!this.ChannelID.SelectedValue.IsInt())
            {
                errorMsg = "请选择渠道";
                this.ChannelID.Focus();
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
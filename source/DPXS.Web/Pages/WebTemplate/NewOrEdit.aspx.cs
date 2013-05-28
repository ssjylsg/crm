using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WebCrm.Framework;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Web.Facade;

namespace WebCX.Web.Pages.WebTemplate
{
    public partial class NewOrEdit : EditPage<Template, ITemplateService>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDownList();
                if (this.IsEdit)
                {
                    this.CurrentModel = this.Service.FindById(this.Id);
                    this.TemplateCodeID.ReadOnly = true;
                }
            }
        }

        private void BindDropDownList()
        {

            System.Collections.Generic.Dictionary<DropDownList, string> dic = new Dictionary<DropDownList, string>();
            dic[this.MsgTypeID] = "MessageCagetory";
            AspNetHelper.BindDropDown(dic);

        }


        protected override string PageTitle
        {
            get { return "消息模板"; }
        }

        protected override void DataToFace(Template model)
        {
            if (model == null)
            {
                return;
            }
            this.TemplateNameID.Text = model.TemplateName;
            this.TemplateCodeID.Text = model.TemplateCode;
            this.MsgContentID.Text = model.MsgContent;
            AspNetHelper.SetDropDownSelectedvalue(this.MsgTypeID, model.MsgType);
        }

        protected override void FaceToData(ref Template model)
        {

            model.ModifyTime = DateTime.Now;

            model.TemplateName = this.TemplateNameID.Text;
            model.TemplateCode = this.TemplateCodeID.Text;
            model.MsgContent = this.MsgContentID.Text;
            model.MsgType = AspNetHelper.GetItemByDropDownValue(this.MsgTypeID);
            if (!this.IsEdit)
            {
                model.CreatePerson = this.CurrentOperatorUser;
                model.Company = this.CurrentCompany;
            }
        }

        protected override bool CheckData(out string errorMsg)
        {

            if (string.IsNullOrEmpty(this.TemplateNameID.Text))
            {
                errorMsg = "名称为必填项";
                this.TemplateNameID.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.TemplateCodeID.Text))
            {
                errorMsg = "编号为必填项";
                this.TemplateCodeID.Focus();
                return false;
            }
            if (!this.MsgTypeID.SelectedValue.IsInt())
            {
                errorMsg = "请选择消息类型";
                this.MsgTypeID.Focus();
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
            this.SaveOrUpdate();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Web.Facade;

namespace WebCX.Web.Pages.WebTask
{
    public partial class NewOrEdit : EditPage<Task, ITaskService>
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ActualDateID.IsSetDefaultValue = false;
                ExpectationDateID.IsSetDefaultValue = false;
                BindDropDownList();
                if (IsEdit)
                {
                    var model = this.Service.FindById(this.Id);
                    this.CurrentModel = model;
                    if (model.CreateUser.Id != this.CurrentOperatorUser.Id)
                    {
                        this.AssignUserID.Enabled = false;
                        this.SubjectID.ReadOnly = true;
                        this.TaskContentID.ReadOnly = true;
                        this.StartDateID.ReadOnly = true;
                        this.ExpectationDateID.ReadOnly = true;
                        this.AssignUserID.Enabled = true;
                    }
                }
            }
        }

        private void BindDropDownList()
        {
            AspNetHelper.BindBussinessPerson(this.AssignUserID);
            var request = new Dictionary<DropDownList, string>();
            request[this.TaskProcessID] = "TaskProcess";
            AspNetHelper.BindDropDown(request);
        }


        protected override string PageTitle
        {
            get { return "任务计划"; }
        }

        protected override void DataToFace(Task model)
        {
            if (model == null)
            {
                return;
            }
            this.SubjectID.Text = model.Subject;
            this.TaskContentID.Text = model.TaskContent;
            if (model.AssignUser != null)
            {
                this.AssignUserID.SelectedValue = model.AssignUser.Id.ToString();
            }
            this.ActualDateID.Text = model.ActualDate.HasValue
                                         ? model.ActualDate.Value.ToString("yyyy-MM-dd")
                                         : string.Empty;

            this.StartDateID.Text = model.StartDate.ToString("yyyy-MM-dd");
            this.ExpectationDateID.Text = model.ExpectationDate.HasValue
                                              ? model.ExpectationDate.Value.ToString("yyyy-MM-dd")
                                              : string.Empty;

            this.ExecutionContentID.Text = model.ExecutionContent;

            AspNetHelper.SetDropDownSelectedvalue(this.TaskProcessID, model.TaskProcess);

            this.RemarkID.Text = model.Remark;
        }

        protected override void FaceToData(ref Task model)
        {

            model.ModifyTime = DateTime.Now;

            if (!this.IsEdit)
            {
                model.CreateUser = this.CurrentOperatorUser;
            }

            model.Subject = this.SubjectID.Text;
            model.TaskContent = this.TaskContentID.Text;
            var userService = WebCrm.Framework.DependencyResolver.Resolver<IUserInfoService>();
            if (this.AssignUserID.SelectedValue.IsInt())
            {
                model.AssignUser = userService.FindById(int.Parse(this.AssignUserID.SelectedValue));
            }

            if (this.ActualDateID.Text.IsDateTime())
            {
                model.ActualDate = DateTime.Parse(this.ActualDateID.Text);
            }
            if (this.StartDateID.Text.IsDateTime())
            {
                model.StartDate = DateTime.Parse(this.StartDateID.Text);
            }
            if (this.ExpectationDateID.Text.IsDateTime())
            {
                model.ExpectationDate = DateTime.Parse(ExpectationDateID.Text);
            }

            model.ExecutionContent = this.ExecutionContentID.Text;
            model.TaskProcess = AspNetHelper.GetItemByDropDownValue(this.TaskProcessID);
            model.Remark = this.RemarkID.Text;

        }

        protected override bool CheckData(out string errorMsg)
        {
            if (string.IsNullOrEmpty(this.SubjectID.Text))
            {
                errorMsg = "标题为必填项";
                this.SubjectID.Focus();
                return false;
            }
            if (!this.TaskContentID.Text.ValidStringLength())
            {
                errorMsg = "任务内容的最大长度为1000个字符";
                this.TaskContentID.Focus();
                return false;
            }
            if (!this.ExecutionContentID.Text.ValidStringLength())
            {
                errorMsg = "执行中内容最大长度为1000个字符";
                this.ExecutionContentID.Focus();
                return false;
            }
            if (!this.RemarkID.Text.ValidStringLength())
            {
                errorMsg = "备注信息不能超过1000个字符";
                this.RemarkID.Focus();
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
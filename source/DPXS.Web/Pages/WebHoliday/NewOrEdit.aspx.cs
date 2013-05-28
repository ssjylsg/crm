using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WebCrm.Framework;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Web.Facade;

namespace WebCX.Web.Pages.WebHoliday
{
    public partial class NewOrEdit : BasePage
    {
        public IHolidayService Service
        {
            get { return DependencyResolver.Resolver<IHolidayService>(); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.CurrentModel = this.Service.FindById(this.Id);
            }
        }
        public Holiday CurrentModel
        {
            get
            {
                var customer = Id != 0 ? this.Service.FindById(Id) : new Holiday();
                FaceToData(ref customer);
                return customer;
            }
            set
            {
                DataToFace(value);
            }
        }

        private void DataToFace(Holiday value)
        {
            if (value == null)
            {
                return;
            }
            this.NameID.Text = value.Name;
            this.DateTimeControl1.Text = value.HolidayDate.ToShortDateString();
            this.DescriptionID.Text = value.Descript;
            this.IsSendMsg.SelectedValue = value.IsSendMsg ? "1" : "0";
            this.DataNum.Text = value.DateNum.ToString();
        }

        private void FaceToData(ref Holiday value)
        {
            value.Name = this.NameID.Text;
            value.HolidayDate = DateTime.Parse(this.DateTimeControl1.Text);
            value.Descript = this.DescriptionID.Text;
            value.Company = this.CurrentCompany;
            value.IsSendMsg = this.IsSendMsg.SelectedValue == "1";
            value.DateNum = int.Parse(this.DataNum.Text);
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
        //    if (!DateTimeControl1.Text.IsDateTime())
        //    {
        //        errorMsg = "日期格式不正确";
        //        return false;
        //    }
        //    if (!this.DataNum.Text.IsInt())
        //    {
        //        errorMsg = "提前几天发送需为数字";
        //        this.DataNum.Focus();
        //        return false;
        //    }
        //    return true;
        //}
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //string errorMsg;
            //if (!CheckData(out errorMsg))
            //{
            //    this.ShowMsg(errorMsg);
            //    return;
            //}
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
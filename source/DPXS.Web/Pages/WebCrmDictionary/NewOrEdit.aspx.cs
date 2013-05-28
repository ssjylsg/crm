using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WebCrm.Framework;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Web.Facade;


namespace WebCrm.Web.Pages.WebCrmDictionary
{
    public partial class NewOrEdit : BasePage
    {
        public ICrmDictionaryService Service
        {
            get { return DependencyResolver.Resolver<ICrmDictionaryService>(); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (NE == "edit")
                {
                    KeyID.Enabled = false;
                }
                this.CurrentModel = this.Service.FindById(this.Id);
            }
        }

        public CrmDictionary CurrentModel
        {
            get
            {
                var customer = Id != 0 ? this.Service.FindById(Id) : new CrmDictionary();
                FaceToData(ref customer);
                return customer;
            }
            set
            {
                DataToFace(value);
            }
        }

        private void DataToFace(CrmDictionary value)
        {
            if (value != null)
            {
                this.KeyID.Text = value.Key;
                this.ValueID.Text = value.Value;
                this.DepictID.Text = value.Depict;
            }
        }

        private void FaceToData(ref CrmDictionary value)
        {
            value.Key = this.KeyID.Text;
            value.Value = this.ValueID.Text;
            value.Depict = this.DepictID.Text;
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
        //    //if (string.IsNullOrEmpty(this.KeyID.Text))
        //    //{
        //    //    errorMsg = "键值为必填项";
        //    //    this.KeyID.Focus();
        //    //    return false;
        //    //}
        //    //if (string.IsNullOrEmpty(this.DepictID.Text))
        //    //{
        //    //    errorMsg = "信息不能为空";
        //    //    this.ValueID.Focus();
        //    //    return false;
        //    //}
        //    //if (string.IsNullOrEmpty(this.ValueID.Text))
        //    //{
        //    //    errorMsg = "信息不能为空";
        //    //    this.ValueID.Focus();
        //    //    return false;
        //    //}

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
                string keys = this.KeyID.Text;
                int count = this.Service.GetScalar(keys);
                if (count > 0)
                {
                    this.ShowMsg(keys + "键值不能重复");
                }
                else
                {
                    this.Service.Save(CurrentModel);
                    this.ShowMsg("操作成功", "List.aspx");
                }
            }
        }

    }
}
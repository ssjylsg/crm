using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebCrm.Framework;
using WebCrm.Framework.Model;
using WebCrm.Model;
using WebCrm.Model.Services;

namespace WebCrm.Web.Facade
{
    /// <summary>
    /// 
    /// </summary>
    public class BasePage : System.Web.UI.Page
    {

        protected override void OnLoadComplete(EventArgs e)
        {
            //if (Request.QueryString["read"] == "true")
            //{
            //    SetPageReadOnly();
            //}

            base.OnLoadComplete(e);
        }
        public OperatorUser CurrentOperatorUser
        {
            get { return HttpCurrentUserService.Current; }
        }


        public Company CurrentCompany
        {
            get
            {
                var opr = CurrentOperatorUser;
                return opr != null ? opr.Company : null;
            }
        }

        protected void SetPageReadOnly()
        {
            foreach (Control control in this.Controls)
            {
                this.SetReadOnly(control);
            }
        }

        private void SetReadOnly(System.Web.UI.Control control)
        {
            foreach (System.Web.UI.Control child in control.Controls)
            {
                if (child is TextBox)
                {
                    ((TextBox)child).ReadOnly = true;
                }
                if (child is DropDownList)
                {
                    ((DropDownList)child).Enabled = false;
                }
                if (child is ICanReadOnly)
                {
                    ((ICanReadOnly)child).ReadOnly = true;
                }
                if (child is Button)
                {
                    ((Button)child).Enabled = false;
                }
                this.SetReadOnly(child);
            }
        }
    }


    //public abstract class QueryPage<T, S, Q> : BasePage
    //    where S : IBaseRequestService<T>
    //    where T : CrmEntity, new()
    //{
    //    /// <summary>
    //    /// 调用Service
    //    /// </summary>
    //    protected S Service
    //    {
    //        get { return DependencyResolver.Resolver<S>(); }
    //    } 
    //}

    /// <summary>
    /// 编辑页面
    /// </summary>
    /// <typeparam name="T">保存或修改的Model</typeparam>
    /// <typeparam name="S">调用的 Service</typeparam>
    public abstract class EditPage<T, S> : BasePage
        where S : IBaseRequestService<T>
        where T : BaseEntity, new()
    {
        /// <summary>
        /// 页面Title
        /// </summary>
        protected abstract string PageTitle { get; }
        /// <summary>
        /// 是否编辑
        /// </summary>
        protected bool IsEdit
        {
            get { return Request.QueryString["NE"] == "edit"; }
        }
        /// <summary>
        /// 新增或编辑
        /// </summary>
        public string NE
        {
            get { return Request.QueryString["NE"]; }
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
        /// 当前对象
        /// </summary>
        protected virtual T CurrentModel
        {
            get
            {
                var customer = Id != 0 ? this.Service.FindById(Id) : new T();
                FaceToData(ref customer);
                return customer;
            }
            set
            {
                DataToFace(value);
            }
        }
        /// <summary>
        /// 页面显示数据
        /// </summary>
        /// <param name="model"></param>
        protected abstract void DataToFace(T model);
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="model"></param>
        protected abstract void FaceToData(ref T model);
        /// <summary>
        /// 调用Service
        /// </summary>
        protected S Service
        {
            get { return DependencyResolver.Resolver<S>(); }
        }
        /// <summary>
        /// 保存逻辑
        /// </summary>
        /// <param name="returnUrl"></param>
        protected virtual void SaveOrUpdate(string returnUrl = "List.aspx")
        {
            try
            {
                string errorMsg;
                if (!CheckData(out errorMsg))
                {
                    this.ShowMsg(errorMsg);
                    return;
                }
                var model = this.CurrentModel;
                if (!IsEdit)
                {
                    Service.Save(model);
                }
                else
                {
                    Service.Update(model);
                }
                SaveHist(model);
                this.ShowMsg("操作成功", returnUrl);
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(this.GetType()).Error(e);
                this.ShowMsg("出错，请尝试！");
            }
        }
        /// <summary>
        /// 保存操作历史
        /// </summary>
        /// <param name="model"></param>
        protected virtual void SaveHist(T model)
        {
            string info = string.Format("{0}信息", this.PageTitle);
            this.Service.SaveNewProcHist(string.Empty, model, this.CurrentOperatorUser,
                                        this.IsEdit ? "编辑" + info : "新建" + info, "");
        }
        /// <summary>
        /// 数据检查
        /// </summary>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        protected abstract bool CheckData(out string errorMsg);

    }

}

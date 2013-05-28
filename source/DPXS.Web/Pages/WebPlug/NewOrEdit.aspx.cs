using System;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Web.Facade;

namespace WebCX.Web.Pages.WebPlug
{
    public partial class NewOrEdit : EditPage<Plug, IPlugService>
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                txtParentName.Text = ParentName;
                if (NE == "edit")
                {
                    this.CurrentModel = this.Service.FindById(this.Id);
                }
            }
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
            get { return "插件"; }
        }

        protected override void DataToFace(Plug model)
        {
            this.SortID.Text = model.Sort.ToString();
            PlugWebFileID.Text = model.PlugWebFile;
            PlugCodeID.Text = model.PlugCode;
            PlugNameID.Text = model.PlugName;
            this.RemarkID.Text = model.Remark;
            if (model.Parent != null)
            {
                this.txtParentName.Text = model.Parent.PlugName;
            }
        }

        protected override void FaceToData(ref Plug model)
        {

            model.ModifyTime = DateTime.Now;

            model.Sort = int.Parse(this.SortID.Text);
            model.PlugWebFile = PlugWebFileID.Text;
            model.PlugCode = PlugCodeID.Text;
            model.PlugName = PlugNameID.Text;
            model.OptorCode = this.CurrentOperatorUser.OperatorName;
            model.State = true;
            model.Remark = this.RemarkID.Text;
            model.Parent = this.Service.FindById(ParentId);

        }

        protected override bool CheckData(out string errorMsg)
        {
            if (!SortID.Text.IsInt())
            {
                errorMsg = "排序需为数字";
                SortID.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.PlugCodeID.Text))
            {
                errorMsg = "名称为必填项";
                this.PlugCodeID.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.PlugNameID.Text))
            {
                errorMsg = "名称为必填项";
                this.PlugNameID.Focus();
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
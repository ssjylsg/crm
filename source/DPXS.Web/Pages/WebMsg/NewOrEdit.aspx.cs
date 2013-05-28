using System;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Web.Facade;
using WebCrm.Framework;

namespace WebCX.Web.Pages.WebMsg
{
    public partial class NewOrEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var category = DependencyResolver.Resolver<ICategoryService>().FindByCode("SendMobileInfo");
            if (category == null || string.IsNullOrEmpty(category.Value))
            {
               this.ShowMsg("发送者号码为空，请在分类中配置");
                return;
            }
            try
            {
                DependencyResolver.Resolver<IMessageService>().GenerateMessageInfo(category.Value,
                                                                    this.txtParentName.Text.Trim().Replace('，', ','),
                                                                    RemarkID.Text);
                this.ShowMsg("发送成功");
            }
            catch (Exception ex)
            {
                log4net.LogManager.GetLogger(this.GetType()).Error(ex);
                this.ShowMsg("发送失败，请联系管理员");
            }
        }
    }
}
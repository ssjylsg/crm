using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCrm.Web.Facade
{

    public enum Icorn
    {
        Error,
        Success
    }

    /// <summary>
    /// Msg 的摘要说明。
    /// </summary>
    public static class Msg
    {

        public static void ShowConfirm(string strMsg, string strUrl_Yes, string strUrl_No)
        {

            System.Web.HttpContext.Current.Response.Write("<Script Language='JavaScript'>if ( window.confirm('" + strMsg + "')) {  window.location.href='" + strUrl_Yes +
                              "' } else {window.location.href='" + strUrl_No + "' };</script>");
        }

        public static void ShowMsg(this Page page, string message)
        {
            MessageBox.Show(page, message);
        }
        public static void ShowMsg(this Page page, string message, string url)
        {
            MessageBox.ShowAndRedirect(page, message, url);
        }
        public static void ShowJqueryMsg(this Page page, string message)
        {
            MessageBox.ShowJqueryMessage(page, message, Icorn.Success);
        }
    }
    internal class MessageBox
    {
        // Methods
        private MessageBox()
        {
        }
        public static void ShowJqueryMessage(Page page, string message, Icorn icorn)
        {
            string endMsg =
                ".dialog({ height: 200, minHeight: 320, width: 300, title: '消息提示', autoOpen: true, modal: true, buttons: { '确定': function () { $(this).dialog('destroy'); } } });";

            var js =
                string.Format(
                    @" $('<div>{0}</div>'){1}", message, endMsg);

            ResponseScript(page, js);

        }
        public static void ResponseScript(Page page, string script)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>" + script + "</script>");
        }

        public static void Show(Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg + "');</script>");
        }

        public static void ShowAndBack(Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg + "');history.back();</script>");
        }

        public static void ShowAndRedirect(Page page, string msg, string url)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg + "');window.location=\"" + url + "\"</script>");
        }

        public static void ShowAndRedirects(Page page, string msg, string url)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<script language='javascript'defer>");
            builder.AppendFormat("alert('{0}');", msg);
            builder.AppendFormat("top.location.href='{0}'", url);
            builder.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", builder.ToString());
        }

        public static void ShowConfirm(WebControl Control, string msg)
        {
            Control.Attributes.Add("onclick", "return confirm('" + msg + "');");
        }

        public static void ShowFailTip(Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>ShowFailTip('" + msg + "');</script>");
        }

        public static void ShowFailTip(Page page, string msg, string url)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>ShowFailTip('" + msg + "');function jump(count){window.setTimeout(function(){count--;if(count>0){jump(count)}else{window.location.href=\"" + url + "\"}},1000)}jump(3);</script>");
        }

        public static void ShowLoadingTip(Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>ShowLoadingTip('" + msg + "');</script>");
        }

        public static void ShowLoadingTip(Page page, string msg, string url)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>ShowLoadingTip('" + msg + "');function jump(count){window.setTimeout(function(){count--;if(count>0){jump(count)}else{window.location.href=\"" + url + "\"}},1000)}jump(3);</script>");
        }

        public static void ShowServerBusyTip(Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>ShowServerBusyTip('" + msg + "');</script>");
        }

        public static void ShowServerBusyTip(Page page, string msg, string url)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>ShowServerBusyTip('" + msg + "');function jump(count){window.setTimeout(function(){count--;if(count>0){jump(count)}else{window.location.href=\"" + url + "\"}},1000)}jump(3);</script>");
        }

        public static void ShowSuccessTip(Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>ShowSuccessTip('" + msg + "');</script>");
        }

        public static void ShowSuccessTip(Page page, string msg, string url)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>ShowSuccessTip('" + msg + "');function jump(count){window.setTimeout(function(){count--;if(count>0){jump(count)}else{window.location.href=\"" + url + "\"}},1000)}jump(3);</script>");
        }
    }


}
using System;

namespace DPXS.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("Admin/Login.aspx");
        }
    }
}
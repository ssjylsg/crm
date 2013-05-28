using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using WebCrm.Model.Services;

namespace DPXS.Web.Admin
{
    public partial class Upload : WebCrm.Web.Facade.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Text = "　";
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {


            var model = WebCrm.Framework.DependencyResolver.Resolver<IFileService>().UpLoadFile(this.Request);

            string uploadPath = string.Format("/upload/{0}/{1}/XL/", DateTime.Now.Year, DateTime.Now.Month);

            if (!Directory.Exists(Server.MapPath(uploadPath)))
                Directory.CreateDirectory(Server.MapPath(uploadPath));

            string fileExt = System.IO.Path.GetExtension(fileUpload.FileName);
            if (true)
            {
                string filePath = uploadPath + DateTime.Now.ToString("yyyyMMddhhmmsss") + fileExt;
                try
                {
                    fileUpload.SaveAs(Server.MapPath(filePath));
                    hidFileName.Value = filePath;
                    this.RegisterStartupScript("Close", @"<script type='text/javascript'> 
                                                            window.returnValue = document.getElementById('hidFileName').value; 
                                                            window.close();
                                                      </script>");
                }
                catch
                {
                    lblMessage.Text = "上传失败";
                }
            }
            else
            {
                lblMessage.Text = "上传文件类型限制,请重新上传";
            }
        }
    }
}

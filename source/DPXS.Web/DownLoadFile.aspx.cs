using System;
using System.IO;
using System.Web;
using WebCrm.Framework;
using WebCrm.Model;
using WebCrm.Model.Services;
using WebCrm.Web.Facade;

namespace WebCrm.Web
{
    public partial class DownLoadFile : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                var fileId = this.Request.GetRequestValue("fileId");
                if (!string.IsNullOrEmpty(fileId))
                {
                    var fileInfo = DependencyResolver.Resolver<IFileService>().FindByGuid(fileId);

                    if (fileInfo != null)
                    {
                        string fileName = fileInfo.FileName;
                        string filePath = Server.MapPath(fileInfo.FullName);
                        if (File.Exists(filePath))
                        {
                            byte[] bytes;
                            using (FileStream fs = new FileStream(filePath, FileMode.Open))
                            {
                                bytes = new byte[(int)fs.Length];
                                fs.Read(bytes, 0, bytes.Length);
                            }
                            Response.ContentType = "application/octet-stream";
                            Response.AddHeader("Content-Disposition", "attachment;   filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));
                            Response.BinaryWrite(bytes);
                            Response.Flush();
                            Response.End();
                            return;
                        }
                    }
                }
                Response.Write("无效的资源");
                Response.End();
            }
        }
    }
}
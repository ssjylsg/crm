using System;
using System.Web;
using WebCrm.Model;
using WebCrm.Model.Services;

namespace FileUploadSample.Handler
{

    public class UploadHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            DataResult result = new DataResult();
            try
            {
                var model = WebCrm.Framework.DependencyResolver.Resolver<IFileService>().UpLoadFile(context.Request);
                if (model != null)
                {
                    result.Success = true;
                    result.Data =
                        new
                            {
                                ID = model.Id,
                                CreateTime = model.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                FileName = model.FileName,
                                FileSize = (int)model.FileSize / 1024
                            };
                }
                else
                {
                    result.Success = false;
                    result.Error = "没有文件";
                }
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Error = e.Message;
            }
            context.Response.Write(result.ToJson());
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}

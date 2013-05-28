using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace WebCrm.Model.Services
{
    public interface IFileService : IBaseRequestService<FileAttachement>
    {
        FileStream DownloadFileFromFileServerByStream(int fileId);
        FileAttachement UpLoadFile(HttpRequest request, string fileName = "fulFile");
        FileAttachement FindByGuid(string fileGuidId);
        IList<FileAttachement> FindByIds(params int[] ids);

    }
}

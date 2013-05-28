using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebCrm.Framework;
using WebCrm.Model;
using WebCrm.Model.Repositories;
using WebCrm.Model.Services;

namespace WebCrm.Service
{
    public class FileService : BaseRequestService<FileAttachement>, IFileService
    {
        private IFileRepository _fileRepository;
        public FileService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }
         

        public FileAttachement UpLoadFile(HttpRequest request, string fileName = "fulFile")
        {
            HttpPostedFile myFile = request.Files[fileName];

            if (myFile != null)
            {
                if (myFile.InputStream.Length != 0)
                {
                    var uploadFilePath = DependencyResolver.Resolver<ICrmDictionaryService>().FindByKey("UploadFile");

                    string uploadPath = string.Format("/{2}/{0}/{1}/", DateTime.Now.Year, DateTime.Now.Month,
                                                      uploadFilePath != null ? uploadFilePath.Value.Trim('/') : "UploadFile");

                    var context = HttpContext.Current;

                    if (!Directory.Exists(context.Server.MapPath(uploadPath)))
                        Directory.CreateDirectory(context.Server.MapPath(uploadPath));

                    string originalFileName = myFile.FileName; //原文件名


                    if (originalFileName.LastIndexOf("\\") > 0) // IE 下会带有磁盘名称,此处去掉
                    {
                        originalFileName = originalFileName.Substring(originalFileName.LastIndexOf("\\") + 1);
                    }

                    FileAttachement fileAttachement = new FileAttachement();
                    fileAttachement.FilePath = uploadPath;
                    fileAttachement.FileSize = (int)myFile.InputStream.Length;
                    fileAttachement.FileName = originalFileName;
                    var index = myFile.FileName.IndexOf(".");
                    if (index > 0)
                        fileAttachement.Extension = myFile.FileName.Substring(index + 1);

                    this.Save(fileAttachement);

                    string newFileName = fileAttachement.ActualName;

                    string fileAbsPath = context.Server.MapPath(uploadPath) + newFileName; //绝对路径

                    myFile.SaveAs(fileAbsPath);

                    return fileAttachement;
                }
            }
            return null;
        }

        public FileAttachement FindByGuid(string fileGuidId)
        {
            return
                this._fileRepository.Query(string.Format("From FileAttachement Where FileGuidId ='{0}'", fileGuidId), 1).
                    FirstOrDefault();
        }

        public void SaveOrUpdate(FileAttachement fileAttachement)
        {
            this._fileRepository.SaveOrUpdate(fileAttachement);
        }



        public System.IO.FileStream DownloadFileFromFileServerByStream(int fileId)
        {
            FileAttachement file = this.FindById(fileId);
            if (file == null)
            {
                return null;
            }

            string serverFilePath = HttpContext.Current.Request.MapPath(file.FilePath);
            string downLoadUrl = serverFilePath + file.ActualName;
            FileStream fs = null;
            if (System.IO.File.Exists(downLoadUrl))
            {
                fs = new FileStream(downLoadUrl, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            }
            return fs;
        }



        public IList<FileAttachement> FindByIds(params int[] ids)
        {
            if (ids.Length == 0)
            {
                return new List<FileAttachement>();
            }
            return ids.Select(m => this._fileRepository.FindByKey(m)).Where(m => m != null).ToList();
        }
    }
}

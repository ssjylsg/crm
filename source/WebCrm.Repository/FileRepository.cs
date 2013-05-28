using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;
using WebCrm.Model.Repositories;
using WebCrm.Model;
namespace WebCrm.Dao
{
    public class FileRepository : BaseNhibreateRepository<FileAttachement>, IFileRepository
    {
    }
}

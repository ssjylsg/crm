using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrm.Model.Services
{
    public interface ITaskService : IBaseRequestService<Task>
    {
        void Query(PageQuery<IDictionary<string, object>, Task> pageQuery);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Model;
using WebCrm.Model.Repositories;
using WebCrm.Model.Services;

namespace WebCrm.Service
{
    public class TaskService : BaseRequestService<Task>, ITaskService
    {
        private ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public void Query(PageQuery<IDictionary<string, object>, Task> pageQuery)
        {
            _taskRepository.Query(pageQuery);
        }
    }
}

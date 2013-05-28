using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrm.Model.Services
{
    public interface IPlugService : IBaseRequestService<Plug>
    {
        void Query(PageQuery<IDictionary<string, object>, Plug> pageQuery);

        IList<Plug> GetAllParent();
        /// <summary>
        /// 初始化插件数据
        /// </summary>
        void FunctionInsert();
    }
}

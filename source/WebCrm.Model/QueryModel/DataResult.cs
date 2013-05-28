using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrm.Model
{
    /// <summary>
    /// Mvc 返回Json
    /// </summary>
    public class DataResult
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string Error { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public object Data { get; set; }
    }
}

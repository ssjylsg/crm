using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework;
using WebCrm.Model.Services;

namespace WebCrm.Model
{
    public static class SysConfig
    {
        //public static string FolderName
        //{
            
        //}
        /// <summary>
        /// 系统名称
        /// </summary>
        public static string SystemName = "CRM";
        /// <summary>
        /// 
        /// </summary>
        public static int PlugType = 801;

        public static int QueryMaxResult = 10;
        /// <summary>
        /// 字符串最大长度
        /// </summary>
        public static int StringMaxLength = 1000;
    }
}

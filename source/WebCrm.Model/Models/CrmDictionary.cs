using System;
using System.Collections;

namespace WebCrm.Model
{
    /// <summary>
    /// Crm 数据字典
    /// </summary>
    public class CrmDictionary : CrmEntity
    {
        public CrmDictionary()
            : base()
        {

        }
        /// <summary>
        /// Key
        /// </summary>
        public virtual string Key { get; set; }
        /// <summary>
        /// Value
        /// </summary>
        public virtual string Value { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public virtual string Depict { get; set; }
    }
}

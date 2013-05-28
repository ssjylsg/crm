using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCX.Model
{
    public class WEB_REPORT_PARAMETER
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual int ID
        {
            get;
            set;
        }
        /// <summary>
        /// FIELDLABEL
        /// </summary>
        public virtual string FIELDLABEL
        {
            get;
            set;
        }
        /// <summary>
        /// 数据类型
        /// </summary>
        public virtual string DATATYPE
        {
            get;
            set;
        }
        /// <summary>
        /// Web_Report_DataSource.ID
        /// </summary>
        public virtual int DATASOURCEID
        {
            get;
            set;
        }
        /// <summary>
        /// 排序
        /// </summary>
        public virtual int? SORT
        {
            get;
            set;
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime? CREATETIME
        {
            get;
            set;
        }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        public virtual DateTime? MODIFYTIME
        {
            get;
            set;
        }
        /// <summary>
        /// 删除状态：1已删除，0：未删除
        /// </summary>
        public virtual int? DELETED
        {
            get;
            set;
        }
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string REMARK
        {
            get;
            set;
        }
        /// <summary>
        /// 创建人ID
        /// </summary>
        public virtual int? CREATE_LOGIN_ID
        {
            get;
            set;
        }

        /// <summary>
        /// 其他信息JSON
        /// </summary>
        public virtual string OTHERINFO
        {
            get;
            set;
        }
    }
}

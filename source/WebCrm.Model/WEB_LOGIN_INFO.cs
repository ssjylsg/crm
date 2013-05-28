using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCX.Model
{
    public class WEB_LOGIN_INFO
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
        /// 用户名
        /// </summary>
        public virtual string LOGIN_NAME
        {
            get;
            set;
        }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public virtual string LOGIN_REALNAME
        {
            get;
            set;
        }
        /// <summary>
        /// 密码
        /// </summary>
        public virtual string LOGIN_PASS
        {
            get;
            set;
        }
        /// <summary>
        /// 0:停用 1：启用
        /// </summary>
        public virtual int? USE_FLAG
        {
            get;
            set;
        }
        /// <summary>
        /// 0:非管理员 1：管理员
        /// </summary>
        public virtual int? ADMIN_FLAG
        {
            get;
            set;
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public virtual string EMAIL
        {
            get;
            set;
        }
        /// <summary>
        /// 手机号
        /// </summary>
        public virtual string MOBILE
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
        /// 登录次数
        /// </summary>
        public virtual int? LOGIN_COUNT
        {
            get;
            set;
        }
        /// <summary>
        /// 最后登录IP
        /// </summary>
        public virtual string LAST_IP
        {
            get;
            set;
        }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public virtual DateTime? LAST_LOGIN_TIME
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
        /// 创建时间
        /// </summary>
        public virtual DateTime CREATE_TIME
        {
            get;
            set;
        }
        /// <summary>
        /// 更改时间
        /// </summary>
        public virtual DateTime MODIFIED_TIME
        {
            get;
            set;
        }
        /// <summary>
        /// 删除状态：1已删除，0：未删除
        /// </summary>
        public virtual int DELETED
        {
            get;
            set;
        }  
    }
}

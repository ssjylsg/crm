using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WebCrm.Model
{
    #region Plug

    /// <summary>
    /// 插件
    /// </summary>
    public class Plug : CrmEntity
    {
        public Plug()
        {
            PlugType = SysConfig.PlugType;
        }


        #region Public Properties

        public virtual Plug Parent { get; set; }

        /// <summary>
        /// 填写插件文件的文件名
        /// </summary>
        public virtual string PlugCode { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        public virtual string PlugName { get; set; }

        /// <summary>
        /// 线下插件文件名，具体模块文件名称
        /// </summary>
        public virtual string PlugFile { get; set; }

        /// <summary>
        /// 页面地址
        /// </summary>
        public virtual string PlugWebFile { get; set; }


        public virtual int FileType { get; set; }


        public virtual int PlugType { get; set; }


        public virtual int Sort { get; set; }

        /// <summary>
        /// 启用状态：0、不启用 1、启用
        /// </summary>
        public virtual bool State { get; set; }


        public virtual string Version { get; set; }


        public virtual string VersionWeb { get; set; }


        public virtual string ShortCut { get; set; }


        public virtual int ImageIndex { get; set; }


        public virtual int GroupHead { get; set; }


        public virtual int RefreshData { get; set; }


        public virtual int SaveData { get; set; }


        public virtual int SaveToExcel { get; set; }


        public virtual int ImportData { get; set; }


        public virtual int ExportData { get; set; }


        public virtual int PrintSetup { get; set; }


        public virtual int PrintFlag { get; set; }


        public virtual int PrintPreview { get; set; }


        public virtual int FindValue { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; set; }

        /// <summary>
        /// 操作员
        /// </summary>
        public virtual string OptorCode { get; set; }
        public virtual string RunArgs { get; set; }

        //public virtual IList<Role> RoleCollection { get; set; }
        ///// <summary>
        ///// 当前插件是否在给定的角色中
        ///// </summary>
        ///// <param name="roleName"></param>
        ///// <returns></returns>
        //public virtual bool IsInRole(string roleName)
        //{
        //    if (RoleCollection == null || RoleCollection.Count == 0)
        //    {
        //        return false;
        //    }
        //    return this.RoleCollection.FirstOrDefault(m => m.RoleName == roleName && m.Deleted == false) != null;
        //}



        #endregion
    }
    #endregion
}
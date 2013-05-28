using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WebCrm.Model
{
    #region Plug

    /// <summary>
    /// ���
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
        /// ��д����ļ����ļ���
        /// </summary>
        public virtual string PlugCode { get; set; }

        /// <summary>
        /// ģ������
        /// </summary>
        public virtual string PlugName { get; set; }

        /// <summary>
        /// ���²���ļ���������ģ���ļ�����
        /// </summary>
        public virtual string PlugFile { get; set; }

        /// <summary>
        /// ҳ���ַ
        /// </summary>
        public virtual string PlugWebFile { get; set; }


        public virtual int FileType { get; set; }


        public virtual int PlugType { get; set; }


        public virtual int Sort { get; set; }

        /// <summary>
        /// ����״̬��0�������� 1������
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
        /// ��ע
        /// </summary>
        public virtual string Remark { get; set; }

        /// <summary>
        /// ����Ա
        /// </summary>
        public virtual string OptorCode { get; set; }
        public virtual string RunArgs { get; set; }

        //public virtual IList<Role> RoleCollection { get; set; }
        ///// <summary>
        ///// ��ǰ����Ƿ��ڸ����Ľ�ɫ��
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
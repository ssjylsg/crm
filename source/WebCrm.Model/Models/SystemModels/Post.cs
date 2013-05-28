using System;
using System.Collections;

namespace WebCrm.Model
{
    /// <summary>
    /// ��λ
    /// </summary>
    public class Post : CrmEntity
    {

        public Post()
        {
            this.CreateTime = DateTime.Now;
        }
        #region Public Properties
        /// <summary>
        /// ����
        /// </summary>
        public virtual Department Dept { get; set; }
        /// <summary>
        /// �ϼ���λ
        /// </summary>
        public virtual Post Parent { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        public virtual string PostCode { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public virtual string PostName { get; set; }
        /// <summary>
        /// ��ʵ����
        /// </summary>
        public virtual string RealName { get; set; }
        /// <summary>
        /// �ȼ�
        /// </summary>
        public virtual int PostLevel { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        public virtual string Remark { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        public virtual OperatorUser Optor { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public virtual int Sort { get; set; }
        /// <summary>
        /// ��˾
        /// </summary>
        public virtual Company Company { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual int ChartViewType { get; set; }



        #endregion
    }
}

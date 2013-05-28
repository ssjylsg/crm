using System;
using System.Collections;

namespace WebCrm.Model
{
    /// <summary>
    /// ��˾�ͻ���Ϣ
    /// </summary>
    public class CustomerCorpInfo : CrmEntity
    {

        #region Public Properties
        /// <summary>
        /// �ͻ���˾����
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// ��˾����
        /// </summary>
        public virtual CategoryItem CorpType { get; set; }
        /// <summary>
        /// ��վ
        /// </summary>
        public virtual string Url { get; set; }
        /// <summary>
        /// ��ϵ��
        /// </summary>
        public virtual string LinkMan { get; set; }
        /// <summary>
        /// ��ϵ�˵绰
        /// </summary>
        public virtual string LinkManTel { get; set; }
        /// <summary>
        /// �칫�ҵ绰
        /// </summary>
        public virtual string TelPhone { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public virtual string Fax { get; set; }
        /// <summary>
        /// ��ַ
        /// </summary>
        public virtual string Address { get; set; }
        /// <summary>
        /// QQ
        /// </summary>
        public virtual string QQ { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string Remark { get; set; }
        /// <summary>
        /// �ͻ���Ϣ
        /// </summary>
        public virtual Customer Customer { get; set; }
        #endregion
    }

}
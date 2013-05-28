using System;
using System.Collections;
using System.Collections.Generic;

namespace WebCrm.Model
{
    #region Company

    /// <summary>
    /// »ú¹¹
    /// </summary>
    public class Company : CrmEntity
    {
        public Company()
            : base()
        {
            CreateTime = DateTime.Now;
        }

        #region Public Properties

        public virtual string Name { get; set; }

        public virtual Company Parent { get; set; }


        public virtual string FullName { get; set; }

        public virtual string ZipCode { get; set; }


        public virtual string Address { get; set; }

        public virtual string Fax { get; set; }

        public virtual string Website { get; set; }

        public virtual string Remark { get; set; }

        public virtual OperatorUser Optor { get; set; }

        public virtual IList<Company> ChildCompany { get; set; }

        #endregion
    }
    #endregion
}
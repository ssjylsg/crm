using System;
using System.Collections;
using System.Collections.Generic;

namespace WebCrm.Model
{


    /// <summary>
    /// CategoryItem object for NHibernate mapped table 'CategoryItem'.
    /// </summary>
    public class CategoryItem : CrmEntity
    {
        public virtual Category Category { get; set; }

        public virtual CategoryItem ParentItem { get; set; }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual short OrderIndex { get; set; }

        public virtual IList<CategoryItem> ChildItems { get; set; }

        public virtual string OtherInfo { get; set; }

    }

}
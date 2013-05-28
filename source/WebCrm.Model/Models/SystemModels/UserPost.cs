using System;
using System.Collections;

namespace WebCrm.Model
{
    #region UserPost

    /// <summary>
    /// UserPost object for NHibernate mapped table 'Sys_UserPost'.
    /// </summary>
    public class UserPost : CrmEntity
    {


        

        #region Public Properties

        

        public virtual int PostID
        {
            get;

            set;
        }

        public virtual int UserID
        {
            get;

            set;
        }

        public virtual DateTime CreateTime
        {
            get;

            set;
        }

        public virtual DateTime ModifyTime
        {
            get;

            set;
        }

        public virtual int OptorID
        {
            get;

            set;
        }

        public virtual int Deleted
        {
            get;

            set;
        }

        public virtual int IsMainPost
        {
            get;

            set;
        }



        #endregion
    }
    #endregion
}
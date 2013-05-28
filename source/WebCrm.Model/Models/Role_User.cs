using System;
using System.Collections;

namespace WebCrm.Model
{
    #region RoleUser

    /// <summary>
    /// RoleUser object for NHibernate mapped table 'Role_User'.
    /// </summary>
    public class RoleUser : CrmEntity
    {
        #region Member Variables

        private Guid _id;
        private Guid _roleId;
        private Guid _userId;

        #endregion

        #region Constructors

        public RoleUser() : base() { }

        public RoleUser(Guid roleId, Guid userId)
            : base()
        {
            this._roleId = roleId;
            this._userId = userId;
        }

        #endregion

        #region Public Properties

        public virtual Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public virtual Guid RoleId
        {
            get { return _roleId; }
            set { _roleId = value; }
        }

        public virtual Guid UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }



        #endregion
    }
    #endregion
}
using System;
using System.Collections;

namespace WebCrm.Model
{
    #region PermissionUserInfo

    /// <summary>
    /// PermissionUserInfo object for NHibernate mapped table 'Permission_UserInfo'.
    /// </summary>
    public class PermissionUserInfo : CrmEntity
    {
        #region Member Variables

        private Guid _id;
        private Guid _permissionId;
        private Guid _userId;
        private bool _isDeleted;

        #endregion

        #region Constructors

        public PermissionUserInfo() : base() { }

        public PermissionUserInfo(Guid permissionId, Guid userId, bool isDeleted)
            : base()
        {
            this._permissionId = permissionId;
            this._userId = userId;
            this._isDeleted = isDeleted;
        }

        #endregion

        #region Public Properties

        public virtual Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public virtual Guid PermissionId
        {
            get { return _permissionId; }
            set { _permissionId = value; }
        }

        public virtual Guid UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public virtual bool IsDeleted
        {
            get { return _isDeleted; }
            set { _isDeleted = value; }
        }



        #endregion
    }
    #endregion
}
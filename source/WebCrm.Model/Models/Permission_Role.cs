using System;
using System.Collections;

namespace WebCrm.Model
{
    #region PermissionRole

    /// <summary>
    /// PermissionRole object for NHibernate mapped table 'Permission_Role'.
    /// </summary>
    public class PermissionRole : CrmEntity
    {
        #region Member Variables

        private Guid _id;
        private Guid _permissionId;
        private Guid _roleId;

        #endregion

        #region Constructors

        public PermissionRole() : base() { }

        public PermissionRole(Guid permissionId, Guid roleId)
            : base()
        {
            this._permissionId = permissionId;
            this._roleId = roleId;
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

        public virtual Guid RoleId
        {
            get { return _roleId; }
            set { _roleId = value; }
        }



        #endregion
    }
    #endregion
}
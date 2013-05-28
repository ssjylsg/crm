using System;
using System.Collections;

namespace WebCrm.Model
{
    #region Permission

    /// <summary>
    /// Permission object for NHibernate mapped table 'Permission'.
    /// </summary>
    public class Permission : CrmEntity
    {
        #region Member Variables

        private Guid _id;
        private string _name;
        private bool _isDeleted;

        #endregion

        #region Constructors

        public Permission() : base() { }

        public Permission(string name, bool isDeleted)
            : base()
        {
            this._name = name;
            this._isDeleted = isDeleted;
        }

        #endregion

        #region Public Properties

        public virtual Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public virtual string Name
        {
            get { return _name; }
            set
            {
                if (value != null && value.Length > 50)
                    throw new ArgumentOutOfRangeException("Invalid value for Name", value, value.ToString());
                _name = value;
            }
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
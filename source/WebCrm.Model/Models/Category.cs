using System;

namespace WebCrm.Model
{
    #region Category

    /// <summary>
    /// Category object for NHibernate mapped table 'Category'.
    /// </summary>
    public class Category : CrmEntity
    {
        #region Member Variables


        private string _name;
        private string _description;
       
        private string _value;

        #endregion

        #region Constructors

        public Category() : base() { }

        public Category(string name, string description, bool isDeleted, string value)
            : base()
        {
            this._name = name;
            this._description = description;
             
             
            this._value = value;
        }

        #endregion

        #region Public Properties


        public virtual string Name
        {
            get { return _name; }
            set
            {
                if (value != null && value.Length > 150)
                    throw new ArgumentOutOfRangeException("Invalid value for Name", value, value.ToString());
                _name = value;
            }
        }

        public virtual string Description
        {
            get { return _description; }
            set
            {
                if (value != null && value.Length > 150)
                    throw new ArgumentOutOfRangeException("Invalid value for Description", value, value.ToString());
                _description = value;
            }
        }

        public virtual string Value
        {
            get { return _value; }
            set
            {
                if (value != null && value.Length > 50)
                    throw new ArgumentOutOfRangeException("Invalid value for Value", value, value.ToString());
                _value = value;
            }
        }



        #endregion

        public virtual string Code { get; set; }
    }
    #endregion
}
using System;
using System.Collections;

namespace WebCrm.Model
{
    #region SpendScore

    /// <summary>
    /// SpendScore object for NHibernate mapped table 'SpendScore'.
    /// </summary>
    public class SpendScore : CrmEntity
    {
        #region Member Variables


        private int _scoreType;
        private bool _isDelete;
        private string _description;
        private string _remark;

        #endregion


        #region Public Properties

        public virtual int ScoreType
        {
            get { return _scoreType; }
            set { _scoreType = value; }
        }

        public virtual bool IsDelete
        {
            get { return _isDelete; }
            set { _isDelete = value; }
        }

        public virtual string Description
        {
            get { return _description; }
            set
            {

                _description = value;
            }
        }

        public virtual string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }



        #endregion
    }
    #endregion
}
using System;
using System.Collections;

namespace WebCrm.Model
{
    #region RolePlug

    /// <summary>
    ///  
    /// </summary>
    public class RolePlug : CrmEntity
    {

        #region Public Properties

        public virtual Role Role { get; set; }
        public virtual Plug Plug { get; set; }
        public virtual OperatorUser Optor { get; set; }
        #endregion
    }
    #endregion
}
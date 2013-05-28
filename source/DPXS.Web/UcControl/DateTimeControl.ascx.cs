using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebCrm.Web.Facade;

namespace WebCrm.Web.UcControler
{
    public partial class DateTimeControl : System.Web.UI.UserControl, ICanReadOnly
    {
        public DateTimeControl()
        {
            IsSetDefaultValue = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack && string.IsNullOrEmpty(this.Text) && IsSetDefaultValue)
            {
                this.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }
        /// <summary>
        /// 是否设置默认时间，默认为true
        /// </summary>
        public bool IsSetDefaultValue { get; set; }
        public string Text
        {
            get { return this.BirthDateID.Text; }
            set { this.BirthDateID.Text = value; }
        }
        public void SetDate(DateTime date)
        {
            this.BirthDateID.Text = date.ToString("yyyy-MM-dd");
        }
        public void SetDate(DateTime? date)
        {
            if (date.HasValue)
            {
                this.BirthDateID.Text = date.Value.ToString("yyyy-MM-dd");
            }
        }
        public Unit With
        {
            get { return this.BirthDateID.Width; }
            set { this.BirthDateID.Width = value; }
        }

        public bool ReadOnly
        {
            set
            {
                this.BirthDateID.ReadOnly = value;
                this.BirthDateID.Enabled = !value;
            }
        }
    }
}
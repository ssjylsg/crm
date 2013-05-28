using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WebCrm.Framework;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Web.Facade;

namespace WebCX.Web.Pages.WebCustomer
{
    public partial class NewOrEdit : BasePage
    {
        #region Service
        /// <summary>
        /// 
        /// </summary>
        public ICustomerService Service
        {
            get { return DependencyResolver.Resolver<ICustomerService>(); }
        }
        public ICategoryItemService CategoryItemService
        {
            get { return DependencyResolver.Resolver<ICategoryItemService>(); }
        }
        #endregion

        #region Model

        public bool IsPerson { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Customer CurrentCustomer
        {
            get
            {
                Customer customer = Id != 0 ? this.Service.FindById(Id) : new Customer();
                FaceToData(ref customer);
                return customer;
            }
            set
            {
                DataToFace(value);
                if (value != null && value.AccType == CustomerIdentification.Enterprise)
                {
                    CorpInfo = DependencyResolver.Resolver<ICustomerCorpInfoService>().FindByCustomerId(value.Id);
                }
                if (value != null && value.AccType == CustomerIdentification.Person)
                {
                    PersonInfo = DependencyResolver.Resolver<ICustomerInfoService>().FindByCustomerId(value.Id);
                }
            }
        }
        /// <summary>
        /// 客人扩展信息
        /// </summary>
        public CustomerInfo PersonInfo
        {
            get
            {
                var model = DependencyResolver.Resolver<ICustomerInfoService>().FindByCustomerId(Id);
                if (model == null)
                {
                    model = new CustomerInfo();
                }
                model.RealName = RealNameID.Text;
                model.Realauth = this.RealauthID.Checked;

                model.IdCard = this.IdCardID.Text;
                model.Tel = TelID.Text;

                model.Addr = this.AddrID.Text;
                model.Post = PostID.Text;
                model.Email = this.EmailId.Text;

                model.EmailAuth = this.EmailAuthID.Checked;
                model.Mobile = this.MobileId.Text;
                model.MobileAuth = this.MobileAuthID.Checked;
                model.Company = this.CurrentCompany;
                model.Sex = this.SexID.SelectedValue;
                if (this.BirthDate.Text.IsDateTime())
                {
                    model.BirthDate = DateTime.Parse(this.BirthDate.Text);
                }

                model.ModifyTime = DateTime.Now;

                return model;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                var model = value;

                RealNameID.Text = model.RealName;
                this.RealauthID.Checked = model.Realauth;

                this.IdCardID.Text = model.IdCard;
                TelID.Text = model.Tel;

                this.AddrID.Text = model.Addr;
                PostID.Text = model.Post;
                this.EmailId.Text = model.Email;

                this.EmailAuthID.Checked = model.EmailAuth;
                this.MobileId.Text = model.Mobile;
                this.MobileAuthID.Checked = model.MobileAuth;

                this.SexID.SelectedValue = model.Sex;
                if (model.BirthDate.HasValue)
                {
                    this.BirthDate.Text = model.BirthDate.Value.ToShortDateString();
                }
            }
        }
        /// <summary>
        /// 企业扩展信息
        /// </summary>
        public CustomerCorpInfo CorpInfo
        {
            get
            {
                var model = DependencyResolver.Resolver<ICustomerCorpInfoService>().FindByCustomerId(Id);
                if (model == null)
                {
                    model = new CustomerCorpInfo();
                }

                model.CorpType = AspNetHelper.GetItemByDropDownValue(this.CorpTypeID);
                model.Url = this.UrlID.Text;
                model.LinkMan = this.LinkManID.Text;
                model.LinkManTel = this.LinkManTelID.Text;
                model.TelPhone = this.TelPhoneID.Text;

                model.Name = CorpNameID.Text;
                model.Fax = this.FaxID.Text;
                model.Address = this.AddressID.Text;

                model.QQ = this.QQID.Text;
                model.ModifyTime = DateTime.Now;
                return model;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                var model = value;

                AspNetHelper.SetDropDownSelectedvalue(this.CorpTypeID, model.CorpType);
                this.UrlID.Text = model.Url;
                this.LinkManID.Text = model.LinkMan;
                this.LinkManTelID.Text = model.LinkManTel;
                this.TelPhoneID.Text = model.TelPhone;

                CorpNameID.Text = model.Name;
                this.FaxID.Text = model.Fax;
                this.AddressID.Text = model.Address;
                this.QQID.Text = model.QQ;
            }
        }
        private CategoryItem FindCategoryItem(string categoryItemId)
        {
            int itemId;
            return int.TryParse(categoryItemId, out itemId) ? DependencyResolver.Resolver<ICategoryItemService>().FindById(itemId) : null;
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="customer"></param>
        private void FaceToData(ref Customer customer)
        {
            if (customer == null)
            {
                return;
            }
            customer.Name = this.NameId.Text;
            customer.ShortName = this.ShortName.Text;
            customer.Cagegory = FindCategoryItem(this.CagegoryTypeId.SelectedValue);

            customer.Car = this.CarId.Text;
            customer.Code = this.Code.Text;
            customer.CreditRating = FindCategoryItem(CreditRatingID.SelectedValue);
            customer.CustomerType = this.FindCategoryItem(this.CustomerTypeItemId.SelectedValue);
            customer.AccType = this.IdentificationID.SelectedValue == "1"
                                          ? CustomerIdentification.Enterprise
                                          : CustomerIdentification.Person;
            customer.Area = this.FindCategoryItem(this.AreaId.SelectedValue);
            customer.Company = this.CurrentCompany;
            customer.Remark = this.RemarkID.Text;

            customer.CreatePerson = this.CurrentOperatorUser;

            customer.ImportantLevel = this.ImportantLevelId.SelectedValue.Convert<ImportantLevel>();
            customer.LevelSort = this.FindCategoryItem(this.LevelSort.SelectedValue);

            customer.RelationLevel = this.FindCategoryItem(this.RelationLevelID.SelectedValue);
            if (this.BelongPersonID.SelectedValue.IsInt())
            {
                customer.BelongPerson =
                DependencyResolver.Resolver<IUserInfoService>().FindById(int.Parse(this.BelongPersonID.SelectedValue));
            }
            customer.ModifyTime = DateTime.Now;
            customer.MemberCard =
                DependencyResolver.Resolver<IMembershipCardService>().FindByCode(this.MemberCardID.Text);
            customer.CustomerBusiness = AspNetHelper.GetItemByDropDownValue(this.CustomerBusinessID);
            customer.CustomerSource = AspNetHelper.GetItemByDropDownValue(this.CustomerSourceID);
        }
        /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="customer"></param>
        private void DataToFace(Customer customer)
        {
            if (customer == null)
            {
                // 新增 初始化数据
                this.CreateTime.Text = DateTime.Now.ToShortDateString();

                //this.CreatePerson.Text = this.CurrentOperatorUser.OperatorName;

                //this.BodyWeightID.Text = "0";
                //this.HeightID.Text = "0";
                if (string.IsNullOrEmpty(this.Code.Text))
                {
                    this.GetCutomerId_Click(null, null);
                }
                return;
            }
            this.NameId.Text = customer.Name;
            this.ShortName.Text = customer.ShortName;
            this.RemarkID.Text = customer.Remark;
            this.CreateTime.Text = customer.CreateTime.ToShortDateString();
            if (customer.Cagegory != null)
            {
                this.CagegoryTypeId.SelectedValue = customer.Cagegory.Id.ToString();
            }

            this.CarId.Text = customer.Car;
            this.Code.Text = customer.Code;
            if (customer.MemberCard != null)
            {
                MemberCardID.Text = customer.MemberCard.CardCode;
            }
            if (customer.CreditRating != null)
            {
                CreditRatingID.SelectedValue = customer.CreditRating.Id.ToString();
            }
            if (customer.CustomerType != null && customer.CustomerType.ParentItem != null)
            {
                CustomerTypeParentId.SelectedValue = customer.CustomerType.ParentItem.Id.ToString();
                this.CustomerTypeParentId_SelectedIndexChanged(null, null); // 加载子类ID
                this.CustomerTypeItemId.SelectedValue = customer.CustomerType.Id.ToString();
            }

            this.IdentificationID.SelectedValue = customer.AccType ==
                                                  CustomerIdentification.Enterprise
                                                      ? "1"
                                                      : "0";

            this.ImportantLevelId.SelectedValue = ((int)customer.ImportantLevel).ToString();

            AspNetHelper.SetDropDownSelectedvalue(LevelSort, customer.LevelSort);

            AspNetHelper.SetDropDownSelectedvalue(RelationLevelID, customer.RelationLevel);
            if (customer.BelongPerson != null)
            {
                this.BelongPersonID.SelectedValue = customer.BelongPerson.Id.ToString();

            }

            if (customer.MemberCard != null)
            {
                this.MemberCardID.Text = customer.MemberCard.CardCode;
            }


            if (customer.Area != null)
            {
                if (customer.Area.ParentItem != null)
                {
                    this.AreaParentId.SelectedValue = customer.Area.ParentItem.Id.ToString();
                    this.AreaParentId_SelectedIndexChanged(null, null);
                }
                this.AreaId.SelectedValue = customer.Area.Id.ToString();
            }

            AspNetHelper.SetDropDownSelectedvalue(this.CustomerBusinessID,customer.CustomerBusiness);
            AspNetHelper.SetDropDownSelectedvalue(this.CustomerSourceID,customer.CustomerSource);
        }


        #endregion

        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDown();
                BindEnumDropDown();
                var model = this.Service.FindById(Id);
                if (NE == "edit")
                {
                    lblTitle.Text = "编辑客户";
                    Code.Enabled = false;
                    this.IsPerson = model.AccType == CustomerIdentification.Person;
                    this.IdentificationID.Enabled = false;
                }
                else
                {
                    this.IsPerson = false;
                }
                CurrentCustomer = model;
            }
        }
        #endregion

        #region 请求ID
        /// <summary>
        /// ID
        /// </summary>
        public int Id
        {
            get
            {
                string strId = Request.QueryString["Id"];
                if (string.IsNullOrEmpty(strId))
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(strId);
                }
            }
        }
        /// <summary>
        /// 新增或编辑
        /// </summary>
        public string NE
        {
            get { return Request.QueryString["NE"]; }
        }

        #endregion

        #region 初始化下拉框
        /// <summary>
        /// 绑定下拉框
        /// </summary>
        private void BindDropDown()
        {
            Dictionary<DropDownList, string> requestList = new Dictionary<DropDownList, string>();
            requestList[this.CustomerTypeParentId] = "CustomerType"; // 客户类型
            requestList[this.AreaParentId] = "CustomerArea"; // 区域
            requestList[this.CagegoryTypeId] = "VipCategory";// 会员类型
            requestList[CreditRatingID] = "CreditRating";// 信用等级
            //requestList[this.BeliefID] = "Believe"; // 信仰
            //requestList[this.NationalitySateID] = "NationalitySate";
            requestList[this.RelationLevelID] = "Customer_RelationLevel"; // 客户管理
            requestList[this.LevelSort] = "Customer_LevelSort"; //认可程度
            requestList[this.CorpTypeID] = "Customer_CorpType";
            requestList[this.CustomerSourceID] = "CustomerSource";// 客户来源
            requestList[this.CustomerBusinessID] = "CustomerBusiness";// 客户行业
            AspNetHelper.BindDropDown(requestList);

            AspNetHelper.BindBussinessPerson(this.BelongPersonID);
        }
        /// <summary>
        /// 枚举下拉框绑定
        /// </summary>
        private void BindEnumDropDown()
        {
            Dictionary<DropDownList, Type> requestList = new Dictionary<DropDownList, Type>();
            //requestList[this.AnimalSignID] = typeof(AnimalSign);
            //requestList[this.ConstellationID] = typeof(Constellation);
            //requestList[this.EducationalID] = typeof(Educational);
            //requestList[this.FieldID] = typeof(Field);
            //requestList[HealthStateID] = typeof(HealthState);
            //requestList[this.DrinkingLevelID] = typeof(DrinkingLevel);
            //requestList[this.BodyTypeID] = typeof(BodyType);
            requestList[this.ImportantLevelId] = typeof(ImportantLevel);

            foreach (KeyValuePair<DropDownList, Type> keyValuePair in requestList)
            {
                keyValuePair.Key.Items.Clear();
                keyValuePair.Key.Items.AddRange(AspNetHelper.GetFieldDescription(keyValuePair.Value));
            }

        }
        #endregion

        #region 保存事件

        #region 页面数据检查
        private bool CheckData(out string errorMsg)
        {
            this.ShortName.Text = this.ShortName.Text.Trim();
            if (!string.IsNullOrEmpty(this.ShortName.Text))
            {
                bool result = this.Service.ExistName(this.ShortName.Text.Trim(), Id);
                if (result)
                {
                    errorMsg = "用户名已经存在，请更改";
                    return false;
                }
            }
            if (!this.RemarkID.Text.ValidStringLength())
            {
                errorMsg = "备注不能超过1000个字符";
                this.RemarkID.Focus();
                return false;
            }
            
            errorMsg = string.Empty;
            return true;
            //return this.DoubleCheck(this.HeightID, "身高", out errorMsg) &&
            //       this.DoubleCheck(this.BodyWeightID, "体重", out errorMsg);
        }
        private bool DoubleCheck(TextBox textBox, string name, out string errorMsg)
        {
            double defaultValue;
            if (!double.TryParse(textBox.Text, out defaultValue))
            {
                errorMsg = name + "需为数字";
                return false;
            }
            errorMsg = string.Empty;
            return true;
        }
        #endregion

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string errorMsg;
            if (!CheckData(out errorMsg))
            {
                this.ShowMsg(errorMsg);
                return;
            }
            else
            {
                Customer model = this.CurrentCustomer;
                if (NE == "edit")
                {
                    this.Service.Update(model);
                    if (model.AccType == CustomerIdentification.Person)
                    {
                        var personInfo = this.PersonInfo;
                        personInfo.Customer = model;
                        DependencyResolver.Resolver<ICustomerInfoService>().Update(personInfo);
                    }
                    else
                    {
                        var personInfo = this.CorpInfo;
                        personInfo.Customer = model;
                        DependencyResolver.Resolver<ICustomerCorpInfoService>().Update(personInfo);
                    }
                }
                else
                {
                    this.Service.Save(model); // 保存客户基本信息
                    if (model.AccType == CustomerIdentification.Person) // 个人扩展信息
                    {
                        var personInfo = this.PersonInfo;
                        personInfo.Customer = model;
                        DependencyResolver.Resolver<ICustomerInfoService>().Save(personInfo);
                    }
                    else
                    {
                        // 企业扩展信息
                        var personInfo = this.CorpInfo;
                        personInfo.Customer = model;
                        DependencyResolver.Resolver<ICustomerCorpInfoService>().Save(personInfo);
                    } 
                }
                this.Service.SaveNewProcHist(string.Empty, model, this.CurrentOperatorUser,
                                             NE == "edit" ? "编辑客户信息" : "新建客户信息", "");
                this.ShowMsg("操作成功", "List.aspx");
            }
        }
        #endregion

        #region 下拉框事件
        /// <summary>
        /// 地区下拉框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AreaParentId_SelectedIndexChanged(object sender, EventArgs e)
        {
            AspNetHelper.BindSubDropDown(AreaParentId, AreaId);
        }
        /// <summary>
        /// 客户类型绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CustomerTypeParentId_SelectedIndexChanged(object sender, EventArgs e)
        {
            AspNetHelper.BindSubDropDown(this.CustomerTypeParentId, this.CustomerTypeItemId);
        }
        /// <summary>
        /// 获取客户编号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GetCutomerId_Click(object sender, EventArgs e)
        {
            this.Code.Text = this.Service.GetCustomerNo();
        }
        #endregion
    }
}
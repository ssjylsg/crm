using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WebCrm.Framework;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Web.Facade;

namespace WebCrm.Web.Pages.WebConsume
{
    public partial class NewOrEdit : EditPage<CustormerConsumRecord, ICustormerConsumRecordService>
    {

        public ICustomerService CustomerService
        {
            get { return DependencyResolver.Resolver<ICustomerService>(); }
        }
        public ICategoryItemService CategoryItemService
        {
            get { return DependencyResolver.Resolver<ICategoryItemService>(); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropList();
                this.CurrentModel = this.Service.FindById(this.Id);
                if (this.NE == "edit")
                {
                    CustomerID.Enabled = false;
                }
            }
        }

        private void BindDropList()
        {
            var dic = new Dictionary<DropDownList, string>();
            dic[this.DiscountType] = "Customer_DiscountType";// 打折方式
            dic[ScoreRuleID] = "Customer_ScoreRule";// 积分规则
            dic[ConsumerBusinessType] = "ConsumerBusinessType";// 消费类型
            AspNetHelper.BindDropDown(dic);
            AspNetHelper.BindBussinessPerson(BussinessPersonID);
            AspNetHelper.BindCustomer(this.CustomerID);
        }


        protected override string PageTitle
        {
            get { return "消费记录"; }
        }

        protected override void DataToFace(CustormerConsumRecord value)
        {
            if (value == null)
            {
                WritePersonID.Text = this.CurrentOperatorUser.OperatorName;
                this.VisitDateID.Text = DateTime.Now.ToShortDateString();
                ScoreID.Text = "0";
                return;
            }
            if (value.Customer != null)
            {
                this.CustomerID.SelectedValue = value.Customer.Id.ToString();
            }
            if (value.ConsumptionDate.HasValue)
            {
                this.VisitDateID.Text = value.ConsumptionDate.Value.ToShortDateString();
            }
            if (value.ScoreRule != null)
            {
                this.ScoreRuleID.SelectedValue = value.ScoreRule.Id.ToString();
            }
            if (value.ConsumptionDate.HasValue)
            {
                this.VisitDateID.Text = value.ConsumptionDate.Value.ToShortDateString();
            }
            this.SpendTotalID.Text = value.SpendTotal.ToString();
            if (value.DiscountType != null)
            {
                DiscountType.SelectedValue = value.DiscountType.Id.ToString();
            }
            AfterDiscountFree.Text = value.AfterDiscountFree.ToString();
            if (value.ScoreRule != null)
            {
                ScoreRuleID.SelectedValue = value.ScoreRule.Id.ToString();
            }
            ScoreID.Text = value.Score.ToString();
            ReceiveMoneyID.Text = value.ReceiveMoney.ToString();

            RemarkID.Text = value.Remark;
            ConsumerDetailsID.Text = value.ConsumerDetails;

            if (value.WritePerson != null)
            {
                WritePersonID.Text = value.WritePerson.OperatorName;
            }
            AspNetHelper.SetDropDownSelectedvalue(ConsumerBusinessType, value.ConsumerBusinessType);
            files.InnerHtml = AspNetHelper.DownLoadFile(value.FiledIds);

            if (value.BussinessPerson != null)
            {
                BussinessPersonID.SelectedValue = value.BussinessPerson.Id.ToString();
            }
        }

        protected override void FaceToData(ref CustormerConsumRecord record)
        {
            if (this.CustomerID.Text.IsInt())
            {
                record.Customer = this.CustomerService.FindById(int.Parse(this.CustomerID.Text));
            }
            record.ConsumptionDate = DateTime.Parse(VisitDateID.Text);
            record.SpendTotal = int.Parse(SpendTotalID.Text);
            if (DiscountType.SelectedValue.IsInt())
            {
                record.DiscountType = this.CategoryItemService.FindById(int.Parse(this.DiscountType.SelectedValue));
            }
            record.AfterDiscountFree = decimal.Parse(AfterDiscountFree.Text);
            if (ScoreRuleID.SelectedValue.IsInt())
            {
                record.ScoreRule = this.CategoryItemService.FindById(int.Parse(this.ScoreRuleID.SelectedValue));
            }
            if (ScoreID.Text.IsInt())
            {
                record.Score = int.Parse(ScoreID.Text);
            }
            record.ReceiveMoney = decimal.Parse(ReceiveMoneyID.Text);
            record.WritePerson = this.CurrentOperatorUser;
            record.Company = this.CurrentCompany;

            record.Remark = RemarkID.Text;
            record.ConsumerDetails = ConsumerDetailsID.Text;
            record.ModifyTime = DateTime.Now;
            record.ConsumerBusinessType = AspNetHelper.GetItemByDropDownValue(ConsumerBusinessType);
            record.FiledIds = record.FiledIds + "," + Request.GetRequestValue("fileID").Trim(',');
            if (BussinessPersonID.SelectedValue.IsInt())
            {
                record.BussinessPerson =
                    DependencyResolver.Resolver<IUserInfoService>().FindById(int.Parse(BussinessPersonID.SelectedValue));
            }
        }



        /// <summary>
        /// 数据判断
        /// </summary>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        protected override bool CheckData(out string errorMsg)
        {
            errorMsg = string.Empty;
            if (!this.CustomerID.Text.IsInt())
            {
                errorMsg = "请正确填写客户";
                return false;
            }
            if (!this.VisitDateID.Text.IsDateTime())
            {
                errorMsg = "请正确填写消费日期";
                this.VisitDateID.Focus();
            }
            if (!this.SpendTotalID.Text.IsDecimal())
            {
                errorMsg = "请正确填写总花费";
                this.SpendTotalID.Focus();
                return false;
            }
            if (!AfterDiscountFree.Text.IsDecimal())
            {
                errorMsg = "请正确填写打折后总消费数";
                this.AfterDiscountFree.Focus();
                return false;
            }
            if (!ScoreID.Text.IsInt())
            {
                errorMsg = "请正确填写本次积分";
                this.ScoreID.Focus();
                return false;
            }
            if (!ReceiveMoneyID.Text.IsDecimal())
            {
                errorMsg = "请正确填收到款项";
                this.ScoreID.Focus();
                return false;
            }
            if (!this.RemarkID.Text.ValidStringLength())
            {
                errorMsg = string.Format("备注信息不能超过{0}个字符", SysConfig.StringMaxLength);
                this.RemarkID.Focus();
                return false;
            }
            if (!this.ConsumerDetailsID.Text.ValidStringLength())
            {
                errorMsg = string.Format("消费明细不能超过{0}个字符", SysConfig.StringMaxLength);
                this.ConsumerDetailsID.Focus();
                return false;
            }
            return true;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string errorMsg;
            if (!CheckData(out errorMsg))
            {
                this.ShowMsg(errorMsg);
                return;
            }
            var model = this.CurrentModel;
            if (this.IsEdit)
            {
                this.Service.Update(model);
                // 更新时，先本次积分从总积分中减去，然后再添加本次积分
                model.Customer.TotalScore -= this.Service.FindById(this.Id).Score;
                model.Customer.TotalScore += model.Score;
                if (model.ConsumptionDate.HasValue)
                {
                    // 更新最近消费时间
                    if (model.Customer.LastSpendDate < model.ConsumptionDate.Value)
                    {
                        model.Customer.LastSpendDate = model.ConsumptionDate.Value;
                    }
                }
                this.CustomerService.Update(model.Customer); // 更新总积分
            }
            else
            {
                this.Service.Save(model);
                model.Customer.TotalScore += model.Score;
                this.CustomerService.Update(model.Customer); // 更新总积分
            }
            this.SaveHist(model);
            this.ShowMsg("操作成功", "List.aspx");

        }
    }


}
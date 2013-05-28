using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Model;
using WebCrm.Model.Repositories;
using WebCrm.Model.Services;

namespace WebCrm.Service
{
    public class PlugService : BaseRequestService<Plug>, IPlugService
    {
        private IPlugRepository _plugRepository;
        public PlugService(IPlugRepository plugRepository)
        {
            _plugRepository = plugRepository;
        }

        public void Query(PageQuery<IDictionary<string, object>, Plug> pageQuery)
        {
            this._plugRepository.Query(pageQuery);
        }

        public IList<Plug> GetAllParent()
        {
            return _plugRepository.GetAllParent();
        }

        private class PageModel
        {
            public string Url { get; set; }
            public string PageName { get; set; }

        }
        public void FunctionInsert()
        {
            Dictionary<string, IList<PageModel>> pages = new Dictionary<string, IList<PageModel>>();


            pages["基础模块"] = GetSysModel();

            pages["客户管理"] = CustomerPageModels();

            pages["合同管理"] = GetContractPageModel();

            pages["财务管理"] = GetFinancialPageModel();

            pages["市场管理"] = this.GetMarketPageModel();

            pages["投诉建议管理"] = GetComplaSuggPageModel();

            pages["统计分析"] = GetChartModel();

            pages["消息发送"] = GetWebMsgModel();

            pages["消息模板"] = this.GetTemplateModel();

            pages["我的桌面"] = this.GetMySelftCustomerModel();

            int modelSort = 1;
            foreach (var page in pages)
            {
                var parent = InsertPlug(page.Key, null, modelSort, string.Empty);
                this.Log(string.Format("写入{0}", page.Key));
                int pageSort = 1;
                foreach (PageModel pageModel in page.Value)
                {
                    this.InsertPlug(pageModel.PageName, parent, pageSort, pageModel.Url);
                    this.Log(string.Format("写入{0} ,地址 {1} , 父节点ID {2} ", pageModel.PageName, pageModel.Url, parent.Id));
                    pageSort++;
                }
                modelSort++;
            }
        }
        private void Log(object message)
        {
            log4net.LogManager.GetLogger(this.GetType()).Info(message);
        }
        private Plug InsertPlug(string pageName, Plug parent, int sort, string url = "")
        {
            Plug plug = new Plug() { CreateTime = DateTime.Now, Deleted = false, PlugWebFile = url, PlugName = pageName, Parent = parent, State = true, Sort = sort };

            Save(plug);
            return plug;
        }


        private IList<PageModel> CustomerPageModels()
        {
            List<PageModel> list = new List<PageModel>();


            list.Add(new PageModel() { PageName = "客户详细信息", Url = "/Pages/WebCustomer/List.aspx" });
            list.Add(new PageModel() { PageName = "客户回访记录", Url = "/Pages/WebCustomer/VisitRecordList.aspx" });
            list.Add(new PageModel() { PageName = "客户洽谈记录", Url = "/Pages/WebDiscuss/List.aspx" });
            list.Add(new PageModel() { PageName = "客户消费记录", Url = "/Pages/WebConsume/List.aspx" });
            return list;
        }
        private IList<PageModel> GetContractPageModel()
        {
            return new List<PageModel>() { new PageModel() { PageName = "合同管理", Url = "/Pages/WebContract/List.aspx" } };
        }
        private IList<PageModel> GetFinancialPageModel()
        {
            return new List<PageModel>()
                       {
                           new PageModel() {PageName = "应收账款", Url = "/Pages/WebFinancial/List.aspx?FinancialType=receive"},
                           new PageModel() {PageName = "应付账款", Url = "/Pages/WebFinancial/List.aspx?FinancialType=pay"}
                       };
        }

        private IList<PageModel> GetMarketPageModel()
        {

            return new List<PageModel>()
                       {
                           new PageModel() {PageName = "广告", Url = "/Pages/WebMarket/WebAd/List.aspx"},
                           new PageModel() {PageName = "活动", Url = "/Pages/WebMarket/WebActivity/List.aspx"},
                             new PageModel() {PageName = "合作单位", Url = "/Pages/WebMarket/WebJowork/List.aspx"}
                       };
        }

        private IList<PageModel> GetComplaSuggPageModel()
        {

            return new List<PageModel>()
                       {
                           new PageModel() {PageName = "投诉", Url = "/Pages/WebComplaSugg/List.aspx?SuggestComplaints=Complaints"},
                           new PageModel() {PageName = "建议", Url = "/Pages/WebComplaSugg/List.aspx?SuggestComplaints=Suggest"},
                             
                       };
        }

        private IList<PageModel> GetChartModel()
        {

            return new List<PageModel>()
                       {
                           new PageModel() {PageName = "消费记录分析", Url = "/Pages/Chart/ExpenseRecord.aspx"},
                           new PageModel() {PageName = "客户结构分析", Url = "/Pages/Chart/CustomerArchitecture.aspx"},
                            new PageModel() {PageName = "市场活动分析", Url = "/Pages/Chart/MarketingActivity.aspx"},
                           new PageModel() {PageName = "销售人员业绩分析", Url = "/Pages/Chart/SalesPerformance.aspx"},
                             
                       };
        }

        private IList<PageModel> GetWebMsgModel()
        {

            return new List<PageModel>()
                       {
                           new PageModel() {PageName = "消息发送", Url = "/Pages/WebMsg/NewOrEdit.aspx"}, 
                       };
        }
        private IList<PageModel> GetTemplateModel()
        {

            return new List<PageModel>()
                       {
                           new PageModel() {PageName = "消息模板", Url = "/Pages/WebTemplate/List.aspx"}, 
                       };
        }
        private IList<PageModel> GetMySelftCustomerModel()
        {

            return new List<PageModel>()
                       {
                           new PageModel() {PageName = "我的客户", Url = "/Pages/WebNotify/MySelftCustomer.aspx"}, 
                           new PageModel() {PageName = "最近生日客户", Url = "/Pages/WebNotify/CustomerNotify/BirthdayNotify.aspx"}, 
                           new PageModel(){PageName = "我创建的任务",Url = "/Pages/WebTask/List.aspx"},
                           new PageModel(){PageName = "指派给我的任务",Url = "/Pages/WebTask/List.aspx?QueryType=assign"}
                       };
        }

        private IList<PageModel> GetSysModel()
        {


            return new List<PageModel>()
                       {
                           new PageModel() {PageName = "公司列表", Url = "/Pages/WebComapny/List.aspx"},
                           new PageModel() {PageName = "部门列表", Url = "/Pages/WebDept/List.aspx"},
                           new PageModel() {PageName = "用户列表", Url = "/Pages/WebUser/List.aspx"},
                           new PageModel() {PageName = "节假日列表", Url = "/Pages/WebHoliday/List.aspx"},

                           new PageModel() {PageName = "会员卡信息", Url = "/Pages/WebshipCard/List.aspx"},
                           new PageModel() {PageName = "角色管理", Url = "/Pages/WebSysRole/List.aspx"},
                           new PageModel() {PageName = "插件管理", Url = "/Pages/WebPlug/List.aspx"},
                           new PageModel() {PageName = "CRM数据字典", Url = "/Pages/WebCrmDictionary/List.aspx"},

                           new PageModel() {PageName = "分类列表", Url = "/Pages/WebCategory/List.aspx"},
                           new PageModel() {PageName = "CRM分类项列表", Url = "/Pages/WebCategoryItem/List.aspx"},
                       };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using WebCrm.Framework;
using WebCrm.Model;
using WebCrm.Model.Repositories;
using WebCrm.Model.Services;
using System.Data;

namespace WebCrm.Service
{
    public class CustomerService : BaseRequestService<Customer>, ICustomerService
    {
        private ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
        public void Query(PageQuery<IDictionary<string, object>, Customer> pageQuery)
        {
            this._customerRepository.Query(pageQuery);
        }

        public bool ExistName(string name, int id)
        {
            return
               this._customerRepository.Query(string.Format(
                   "From  Customer Where ShortName = '{0}' And Id != {1}", name, id)).ToList().Count > 0;
        }

        public string GetCustomerNo()
        {
            return "QC_" + this._customerRepository.GenerateNewId("CRM_CustomerNo").ToString("D10");
        }

        public DataTable GetStatisticsData(Dictionary<string, object> dict)
        {
            return _customerRepository.GetStatisticsData(dict);
        }

        public DataTable GetByCondition(Dictionary<string, object> dict, string selectFields = "*")
        {
            return _customerRepository.GetByCondition(dict, selectFields);
        }

        public void DeleteCustomer(Customer customer)
        {
            int id = customer.Id;
            customer.Deleted = true;
            customer.ModifyTime = DateTime.Now;
            if (customer.AccType == CustomerIdentification.Enterprise) // 企业扩展信息也做删除标记
            {
                var corpInfoService = DependencyResolver.Resolver<ICustomerCorpInfoService>();
                var corp = corpInfoService.FindByCustomerId(id);
                if (corp != null)
                {
                    corp.Deleted = true;
                    corp.ModifyTime = DateTime.Now;
                    corpInfoService.Update(corp);
                }
            }
            else
            {
                // 删除散客信息
                var infoService = DependencyResolver.Resolver<ICustomerInfoService>();
                var personInfo = infoService.FindByCustomerId(id);
                if (personInfo != null)
                {
                    personInfo.Deleted = true;
                    personInfo.ModifyTime = DateTime.Now;
                    infoService.Update(personInfo);
                }
            }
            // 删除联系人信息
            var contactService = DependencyResolver.Resolver<ICustomerContactInfoService>();
            var contactInfo = contactService.FindByCustomerId(id);
            foreach (CustomerContactInfo customerContactInfo in contactInfo)
            {
                customerContactInfo.Deleted = true;
                customerContactInfo.ModifyTime = DateTime.Now;
                contactService.Update(customerContactInfo);
            }
            // 删除客户
            this.Update(customer);
        }
    }
}

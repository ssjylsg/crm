using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Model;
using WebCrm.Model.Repositories;
using WebCrm.Model.Services;

namespace WebCrm.Service
{
    public class MembershipCardService : BaseRequestService<MembershipCard>, IMembershipCardService
    {
        private IMembershipCardRepository _membershipCardRepository;
       
        public MembershipCardService(IMembershipCardRepository membershipCardRepository)
        {
            _membershipCardRepository = membershipCardRepository;
        } 
        public void SaveOrUpdate(MembershipCard membershipCard)
        {
            this._membershipCardRepository.SaveOrUpdate(membershipCard);
        }

        public void Query(PageQuery<IDictionary<string, object>, MembershipCard> pageQuery)
        {
            this._membershipCardRepository.Query(pageQuery);
        }

        public MembershipCard FindByCode(string p)
        { 
            return this._membershipCardRepository.Query(string.Format("From MembershipCard Where CardCode ='{0}'", p)).FirstOrDefault();
        }
    }
}

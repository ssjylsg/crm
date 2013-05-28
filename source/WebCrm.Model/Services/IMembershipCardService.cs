using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrm.Model.Services
{
    public interface IMembershipCardService : IBaseRequestService<MembershipCard>
    {
        void Query(PageQuery<IDictionary<string, object>, MembershipCard> pageQuery);

        MembershipCard FindByCode(string p);
    }
}

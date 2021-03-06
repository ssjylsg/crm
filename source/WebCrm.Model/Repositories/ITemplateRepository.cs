﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;

namespace WebCrm.Model.Repositories
{
    public interface ITemplateRepository : IBaseNhibreateRepository<Template>
    {
        void Query(PageQuery<IDictionary<string, object>, Template> pageQuery);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace WebCrm.Framework
{
    public static class DependencyResolver
    {
        internal static Autofac.IContainer Container;

        public static T Resolver<T>()
        {
            return Container.Resolve<T>();
        }
     }
}

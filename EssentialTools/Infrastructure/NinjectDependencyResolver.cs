using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using EssentialTools.Models;

namespace EssentialTools.Infrastructure
{
    public class NinjectDependencyResolver : System.Web.Mvc.IDependencyResolver
    {

        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParm) {
            kernel = kernelParm;
            AddBindings();

        }

        private void AddBindings() {
            kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithConstructorArgument("discountSize", 50M);
            kernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechCom.App.Repository;
using TechCom.Model.Domain.Repository;

namespace TechCom.App.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<ICategories>().To<AppRepository>();
            kernel.Bind<IProduct>().To<AppRepository>();
            kernel.Bind<IOrderDetails>().To<AppRepository>();
            kernel.Bind<IMail>().To<PostMailRepository>();
          
        }
    }
}
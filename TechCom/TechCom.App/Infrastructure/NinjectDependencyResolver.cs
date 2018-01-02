using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechCom.App.Repository;
using TechCom.Infrastructure;
using TechCom.Model.Domain.Interface;

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
            kernel.Bind<ICategories>().To<CategoryRepository>();
            kernel.Bind<IProduct>().To<ProductRepository>();
            kernel.Bind<IOrderDetails>().To<OrderRepository>();
            kernel.Bind<IMail>().To<PostMailRepository>();
            kernel.Bind<ISubcategories>().To<SubcategoryRepository>();
            kernel.Bind<IDeliverOption>().To<DeliverOptionRepository>();

        }
    }
}
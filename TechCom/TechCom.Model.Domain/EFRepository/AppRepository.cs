using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCom.Model.Domain.Entities;
using TechCom.Model.Domain.Repository;

namespace TechCom.Model.Domain.EFRepository
{
    public class AppRepository : ICategories, IProduct
    {
        private EFAppContext context = new EFAppContext();
        public IEnumerable<Category> Categories
        {
            get
            {
                return context.Categories;
            }
        }

        public IEnumerable<Product> Products
        {
            get
            {
                return context.Products;
            }
        }
    }
}

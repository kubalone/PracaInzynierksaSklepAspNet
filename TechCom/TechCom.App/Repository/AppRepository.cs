using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechCom.App.DAL;
using TechCom.Model.Domain.Entities;
using TechCom.Model.Domain.Repository;

namespace TechCom.App.Repository
{
    public class AppRepository : ICategories, IProduct
    {
        private ApplicationDbContext context = new ApplicationDbContext();
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

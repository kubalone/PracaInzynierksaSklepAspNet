using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCom.Model.Domain.Domain;
using TechCom.Model.Domain.Interface;
using TechCom.Model.Domain.ViewModels;

namespace TechCom.Infrastructure
{
    public class CategoryRepository : ICategories
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        public IEnumerable<Category> Categories
        {
            get
            {
                return context.Categories;
            }
        }
        public void SaveCategory(EditProductVieModel editProduct)
        {
            var categories = context.Categories.ToList();
            editProduct.Categories = categories;
        }
    }
}

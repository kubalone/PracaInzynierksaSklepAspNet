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
    public class SubcategoryRepository : ISubcategories
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        public IEnumerable<Subcategory> Subcategories
        {
            get
            {
                return context.Subcategories;
            }
        }

        public void SaveSubcategory(EditProductVieModel editProduct)
        {
            var subategories = context.Subcategories.ToList();
            editProduct.Subcategories = subategories;
        }
        //sortowanie podkategorii wg kategorii
        public List<Subcategory> SortProductBySubcategoryName(string categoryName)
        {
            var subcategories = context.Subcategories.Where(p => p.Category.CategoryName == categoryName).ToList();
            return subcategories;
        }
        //wyszukiwanie podkategorii
        public List<Subcategory> GetSubcategories(int? idCategory)
        {
            var subcategories = context.Subcategories.Where(p => p.CategoryID == idCategory && p.SubcategoryName != null).ToList();
            return subcategories;
        }
        

     

    }
}

using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechCom.Model.Domain.Domain;

namespace TechCom.Model.Domain.ViewModels
{
    public class ProductListViewModel
    {
        public ProductListViewModel()
        {
            OrderList = new List<SelectListItem>();
        }
        public List<CountOfProduct> CountOfProductsInCategory{ get; set; }//id produktu w autowyszukiwaniu
        [Display(Name = "Sortuj wg: ")]
        public int? OrderBy { get; set; }
        public List<SelectListItem> OrderList { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public IEnumerable<Category> Categories{ get; set; }
        public List<Product> EnableCategories { get; set; }
      
        public List<Product> SaleProducts { get; set; }
        public List<Product> NewProducts { get; set; }
        public Product DetailsProduct { get; set; }
        public IPagedList<Product>Products{ get; set; }
        public string CurrentCategory{ get; set; }
        
        public int CountOfProduct { get; set; }

        //partial
        public IEnumerable<Subcategory> Subategories { get; set; }

        public string SubcategoryName { get; set; }

      
    }
}
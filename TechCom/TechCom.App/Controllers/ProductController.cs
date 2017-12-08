using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using System.Collections;
using Microsoft.Ajax.Utilities;
using TechCom.Model.Domain.Interface;
using TechCom.Model.Domain.ViewModels;
using TechCom.Model.Domain.Domain;

namespace TechCom.App.Controllers
{
    public class ProductController : Controller
    {

        // GET: Product
        private IProduct productRepository;
        private ICategories categoryRepository;
        
        public ProductController(IProduct productRepository, ICategories categoryRepository)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
        }
       

        public ActionResult ProductList(int? orderBy, string currentFilter,string categoryName, int? page, string searchString,int? id)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            int pageSize = 20;
            int pageNumber = page ?? 1;


             
            var price = new SelectListGroup { Name = "Cena" };
            var products = productRepository.Products.Where(b => b.Category.CategoryName == categoryName).ToList();
           
            switch (orderBy)
            {
                case 1:
                    products = productRepository.Products.Where(b => b.Category.CategoryName == categoryName).OrderByDescending(p => p.Price).ToList();
                    break;
                case 2:
                    products = productRepository.Products.Where(b => b.Category.CategoryName == categoryName).OrderBy(p => p.Price).ToList();
                    break;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                products = productRepository.Products.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()) && s.Category.CategoryName == categoryName).ToList();
                switch (orderBy)
                {
                    case 1:
                        products = productRepository.Products.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()) && s.Category.CategoryName == categoryName).OrderByDescending(p => p.Price).ToList();
                        break;
                    case 2:
                        products = productRepository.Products.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()) && s.Category.CategoryName == categoryName).OrderBy(p => p.Price).ToList();
                        break;
                }
            }

            var vm = new ProductListViewModel()
            {
                Products = products.Where(p=>p.Quantity>0).ToPagedList(pageNumber, pageSize),
                CurrentCategory = categoryName,
                OrderBy=orderBy,
              
                OrderList=new List<SelectListItem>
                {
                    new SelectListItem {Text="Malejąco",Value="1",Group=price},
                    new SelectListItem {Text="Rosnąco",Value="2" ,Group=price}
                }

            };
            
                return View(vm);    
        }
        public ActionResult SearchProduct(int? orderBy,string currentFilter, string searchString, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            List<Product> products = new List<Product>();
            ViewBag.CurrentFilter = searchString;
            int pageSize = 20;
            int pageNumber = page ?? 1;
            var price = new SelectListGroup { Name = "Cena" };
            if (!String.IsNullOrEmpty(searchString))
            {
                 products = productRepository.Products.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper())).ToList();
                switch (orderBy)
                {
                    case 1:
                        products = productRepository.Products.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper())).OrderByDescending(p => p.Price).ToList();
                        break;
                    case 2:
                        products = productRepository.Products.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper())).OrderBy(p => p.Price).ToList();
                        break;
                }
            }
            var categories = products.Where(s => s.CategoryID == s.Category.CategoryID).ToList();
            var countOfProductInCategory = categories.GroupBy(c=>c.Category.CategoryName).
                Select(group=>new
                                            {
                                                Name = group.Key,
                                                Count = group.Count(),

                                            }).ToList();
            List<CountOfProduct> ListOfProduct = new List<CountOfProduct>();
            for (int i = 0; i < countOfProductInCategory.ToList().Count; i++)
            {
                ListOfProduct.Add(new CountOfProduct { Categoryname = countOfProductInCategory[i].Name, Count = countOfProductInCategory[i].Count });
            }

            var vm = new ProductListViewModel()
            {
                EnableCategories = categories,
                OrderBy = orderBy,
                Products = products.Where(p => p.Quantity > 0).ToPagedList(pageNumber, pageSize),
                CountOfProductsInCategory=ListOfProduct,
                OrderList = new List<SelectListItem>
                {
                    new SelectListItem {Text="Malejąco",Value="1",Group=price},
                    new SelectListItem {Text="Rosnąco",Value="2" ,Group=price}
                }
            };

            return View(vm);
        }
        public ActionResult Details(int id)
        {
            var product = new ProductListViewModel()
            {
                DetailsProduct = productRepository.Products.Where(p => p.ProductID == id).Single()
            };
            return View(product);
        }
        public ActionResult SearchSuggestions(string term, string categoryName)
        {
            var products = productRepository.Products.Where(p => p.Name.ToLower().Contains(term.ToLower())
            && p.Category.CategoryName == categoryName).Take(3).Select(a => new { label = a.Name });
            return Json(products, JsonRequestBehavior.AllowGet);
        }

        public ActionResult HomeSearchSuggestions(string term)
        {
            var products = productRepository.Products.Where(p => p.Name.ToLower().Contains(term.ToLower())).Take(5).Select(a => new { label = a.Name });
            return Json(products, JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult CategoryMenu()
        {
            // IEnumerable<int> categories = categoryRepository.Categories.Select(x => x.CategoryID);
            // var cat = categoryRepository.Categories.Select(x=>x.CategoryName);
            return PartialView();

        }
    }
}
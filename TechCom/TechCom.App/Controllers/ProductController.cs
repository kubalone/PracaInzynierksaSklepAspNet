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
        private ISubcategories subcategoryRepository;

        static SelectListGroup price = new SelectListGroup { Name = "Cena" };
        private List<SelectListItem> list = new List<SelectListItem>
                {
                    new SelectListItem {Text="Malejąco",Value="1",Group=price },
                    new SelectListItem {Text="Rosnąco",Value="2" ,Group=price }
                };
        public ProductController(IProduct productRepository, ICategories categoryRepository, ISubcategories subcategoryRepository)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.subcategoryRepository = subcategoryRepository;
        }


        public ActionResult ProductList(int? orderBy, string categoryName, int? page,  int? id)
        {
            var products = productRepository.SortProductByCategoryName(categoryName);
            var subcategories = subcategoryRepository.SortProductBySubcategoryName(categoryName);
           
            if (orderBy != null)
            {
                products = productRepository.OrderProductInCategory(categoryName, orderBy, products);
            }

         
            var vm = new ProductListViewModel()
            {
               Products = products.Where(p => p.Quantity > 0).ToPagedList(page ?? 1, 20),
               CurrentCategory = categoryName,
               OrderBy = orderBy,
               Subategories = subcategories,
               OrderList =list

            };

            return View(vm);
        }
        public ActionResult DetailedProductList(int? orderBy, string currentFilter, string subCategory, int? page, string searchString,string categoryName)
        {
            
           
            var products = productRepository.SortProductBySubcategoryName(subCategory);
           
            var subcategories = subcategoryRepository.SortProductBySubcategoryName(categoryName);
            if (orderBy != null)
            {
                products = productRepository.OrderProductInSubcategory(subCategory, orderBy, products);
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                page = 1;
                products = productRepository.SearchProductInSubCategory(searchString, subCategory);
                if (orderBy != null)
                {
                    products = productRepository.OrderProductInSearchSubcategory(subCategory, orderBy, products, searchString);
                }
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var vm = new ProductListViewModel()
            {
                Products = products.ToPagedList(page ?? 1, 20),
                Subategories = subcategories,
                SubcategoryName= subCategory,
                OrderBy = orderBy,
                CurrentCategory = categoryName,
              
                OrderList = list
            };
            return View(vm);
        }
        public ActionResult SearchProduct(int? orderBy, string currentFilter, string searchString, int? page)
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
            List<Product> products = new List<Product>();

            if (!String.IsNullOrEmpty(searchString))
            {
                products = productRepository.SearchProductInMainView(searchString);
                if (orderBy!=null)
                {
                    products = productRepository.OrderSearchProductInMainView(orderBy, products, searchString);
                }  
            }
            var productInCategory = productRepository.ProductByCategory(products);
            var ListOfProduct = productRepository.CountOfProductInCategory(productInCategory);
            var vm = new ProductListViewModel()
            {
                EnableCategories = productInCategory,
                OrderBy = orderBy,
                Products = products.Where(p => p.Quantity > 0).ToPagedList(page ?? 1,20),
                CountOfProductsInCategory = ListOfProduct,               
                OrderList = list
            };

            return View(vm);
        }
        public ActionResult SearchProductInSubCategory(int? orderBy, string currentFilter, string searchString, int? page, string categoryName)
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
            List<Product> products = new List<Product>();
                    
            if (!String.IsNullOrEmpty(searchString))
            {
                products = productRepository.SearchProductInMainView(searchString);
                if (orderBy != null)
                {
                    products = productRepository.OrderSearchProductInMainView(orderBy, products, searchString);
                }
            }

            var productInSubcategory = productRepository.ProductBySubcategory(products);
            var ListOfProduct = productRepository.CountOfProductInSubategory(productInSubcategory);
            var vm = new ProductListViewModel()
            {
                EnableCategories = productInSubcategory,
                OrderBy = orderBy,
                Products = products.Where(p => p.Quantity > 0).ToPagedList(page ?? 1, 20),
                CountOfProductsInCategory = ListOfProduct,
                OrderList = list,
                CurrentCategory= categoryName
            };

            return View(vm);
        }

        public ActionResult DetailSearchProductInSubCategory(int? orderBy, string currentFilter, string searchString, int? page,string categoryName)
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
            List<Product> products = new List<Product>();

            if (!String.IsNullOrEmpty(searchString))
            {
                products = productRepository.SearchProductInSubCategory(searchString, categoryName);
                if (orderBy != null)
                {
                    products = productRepository.OrderProductInSearchSubcategory(categoryName,orderBy, products, searchString);
                }
            }

            var productInSubcategory = productRepository.ProductBySubcategory(products);
            var ListOfProduct = productRepository.CountOfProductInSubategory(productInSubcategory);
            var vm = new ProductListViewModel()
            {
                EnableCategories = productInSubcategory,
                OrderBy = orderBy,
                Products = products.Where(p => p.Quantity > 0).ToPagedList(page ?? 1, 20),
                CountOfProductsInCategory = ListOfProduct,
                CurrentCategory=categoryName,
                OrderList = list
            };

            return View(vm);
        }

        public ActionResult Details(int id)
        {
            var product = new ProductListViewModel()
            {
                DetailsProduct = productRepository.GetProductById(id)
            };
            return View(product);
        }
    
    }
}
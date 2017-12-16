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


        public ActionResult ProductList(int? orderBy, string currentFilter, string categoryName, int? page, string searchString, int? id)
        {
            var products = productRepository.SortProductByCategoryName(categoryName);
            var subcategories = subcategoryRepository.SortProductBySubcategoryName(categoryName);
            if (searchString != null)
            {
                page = 1;
               
            }
            else
            {
                searchString = currentFilter;
            }
           
            if (orderBy != null)
            {
                products = productRepository.OrderProductInCategory(categoryName, orderBy, products);
            }

            if (!String.IsNullOrEmpty(searchString))
            {

                products = productRepository.SearchProduct(searchString, categoryName);
                if (orderBy != null)
                {
                    products = productRepository.OrderSearchProductInCategory(searchString, categoryName, orderBy, products);
                }
            }

            var vm = new ProductListViewModel()
            {
               Products = products.Where(p => p.Quantity > 0).ToPagedList(page ?? 1, 1),
               CurrentCategory = categoryName,
               OrderBy = orderBy,
               Subategories = subcategories,
               CurrentFilter= searchString,
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

         
            var vm = new ProductListViewModel()
            {
                Products = products.ToPagedList(page ?? 1, 1),
                Subategories = subcategories,
                SubcategoryName= subCategory,
                OrderBy = orderBy,
                CurrentCategory = categoryName,
                CurrentFilter = searchString,
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
                Products = products.Where(p => p.Quantity > 0).ToPagedList(page ?? 1, 1),
                CountOfProductsInCategory = ListOfProduct,
                CurrentFilter = searchString,
                OrderList = list
            };

            return View(vm);
        }
        public ActionResult SearchProductInSubCategory(int? orderBy, string currentFilter, string searchString, int? page)
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
                Products = products.Where(p => p.Quantity > 0).ToPagedList(page ?? 1, 1),
                CountOfProductsInCategory = ListOfProduct,
                CurrentFilter = searchString,
                OrderList = list
            };

            return View(vm);
        }
        public ActionResult Details(int id)
        {
            var product = new ProductListViewModel()
            {
                DetailsProduct = productRepository.GetProductByID(id)
            };
            return View(product);
        }
    
    }
}
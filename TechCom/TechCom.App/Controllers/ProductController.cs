using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechCom.App.Models;
using TechCom.Model.Domain.Repository;
using PagedList.Mvc;
using PagedList;
using System.Collections;

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
        
        public ActionResult ProductList(string categoryName, int? page)
        {

            int pageSize = 1;
            int pageNumber = page ?? 1;

            if(categoryName != null) {
                var vm = new ProductListViewModel();
                vm.CurrentCategory = categoryName;
                var products = productRepository.Products.Where(b => b.Category.CategoryName== categoryName).ToList();
                if (vm != null)
                {
                   
                    vm.Products = products.ToPagedList(pageNumber, pageSize);
                    return View(vm);
                }
                return HttpNotFound();
            }

            return RedirectToAction("index", new { Controller = "Home" });
           

        }
        public  ActionResult Details(int id)
        {
            var product = new ProductListViewModel() {
                DetailsProduct = productRepository.Products.Where(p => p.ProductID == id).Single()
            };
            return View(product);
        }
        public PartialViewResult CategoryMenu()
        {
           // IEnumerable<int> categories = categoryRepository.Categories.Select(x => x.CategoryID);
           // var cat = categoryRepository.Categories.Select(x=>x.CategoryName);
            return PartialView();

        }
    }
}
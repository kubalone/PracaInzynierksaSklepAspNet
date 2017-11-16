using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechCom.App.Models;

using TechCom.Model.Domain.Entities;
using TechCom.Model.Domain.Repository;

namespace TechCom.App.Controllers
{
    public class HomeController : Controller
    {

        private ICategories categoryRepository;
        private IProduct productRepository;
        public HomeController(ICategories categoryRepository, IProduct productRepository)
        {
            this.categoryRepository = categoryRepository;
            this.productRepository = productRepository;
        }
        public ViewResult Index()
        {
            var categories = categoryRepository.Categories;
            var saleProduct = productRepository.Products.Where(p => p.ProductWithDiscount == true).OrderByDescending(a=>a.DateAdded).Take(3);
            ProductListViewModel model = new ProductListViewModel
            {
                Categories = categories,
                SaleProduct = saleProduct
            };
            return View(model);
        }
     
       


    }
}
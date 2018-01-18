using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechCom.Model.Domain.Interface;
using TechCom.Model.Domain.ViewModels;

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
            var saleProduct = productRepository.ProductWithDiscount();
            var newProducts = productRepository.NewProducts();
            ProductListViewModel model = new ProductListViewModel
            {
                Categories = categories,
                SaleProducts = saleProduct,
                NewProducts=newProducts

            };
            return View(model);
        }
     
       


    }
}
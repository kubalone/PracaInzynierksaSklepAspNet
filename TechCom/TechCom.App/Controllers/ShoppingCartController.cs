using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechCom.App.Models;
using TechCom.Model.Domain.EFRepository;
using TechCom.Model.Domain.Entities;
using TechCom.Model.Domain.Repository;

namespace TechCom.App.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        private IProduct productRepository;
        private EFAppContext db;
        public ShoppingCartController(IProduct productRepository)
        {
            this.productRepository = productRepository;
        }
        public ViewResult Index(string returnUrl)
        {
            var vm = new ShoppingCartViewModel()
            {
                ShoppingCartManager = GetShopppingCart(),
                ReturnUrl = returnUrl
            };
            return View(vm);
        }
        public RedirectToRouteResult AddToShoppingCart(int id, string returnUrl)
        {
            Product product = productRepository.Products.FirstOrDefault(p => p.ProductID == id);
            if (product!=null)
            {
                GetShopppingCart().AddProducts(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromShoppingCart(int id,string returnUrl)
        {
            Product product = productRepository.Products.FirstOrDefault(p => p.ProductID == id);
            if (product!=null)
            {
                GetShopppingCart().RemoveProduct(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        private ShoppingCartManager GetShopppingCart()
        {
            ShoppingCartManager cart = (ShoppingCartManager)Session["ShoppingCart"];//odczytywanie
            if (cart==null)
            {
                cart = new ShoppingCartManager(db);
                Session["Cart"] = cart;//ustawianie
            }
            return cart;
        }
    }
}
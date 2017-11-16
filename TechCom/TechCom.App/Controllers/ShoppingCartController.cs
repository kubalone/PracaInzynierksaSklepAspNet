using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TechCom.App.Models;
using TechCom.App.Services;
using TechCom.Model.Domain.Entities;
using TechCom.Model.Domain.Repository;

namespace TechCom.App.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        private IProduct productRepository;
       
        //private EFAppContext db=;
        public ShoppingCartController(IProduct productRepository, ShoppingCartManager cart)
        {
            this.productRepository = productRepository;
           // this.cart = cart;
        }
        public ViewResult Index(string returnUrl, ShoppingCartManager shoppingCartManager)
        {
            var vm=new ShoppingCartViewModel
            {
                ShoppingCartManager = shoppingCartManager,
                ReturnUrl = returnUrl
            };
            return View(vm);
        }
        [HttpPost]
        public RedirectToRouteResult AddToShoppingCart(int? id, int quantity,string returnUrl, ShoppingCartManager shoppingCartManager)
        {
           
           
            Product product = productRepository.Products.FirstOrDefault(p => p.ProductID == id);
            if (product!=null)
            {
                shoppingCartManager.AddProducts(product, quantity);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromShoppingCart(int id,string returnUrl, ShoppingCartManager shoppingCartManager)
        {
            Product product = productRepository.Products.FirstOrDefault(p => p.ProductID == id);
            if (product!=null)
            {
                shoppingCartManager.RemoveProduct(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public async Task <ActionResult> MakeAnOrder()
        {
            if (Request.IsAuthenticated)//jesli zalogowany
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                var oderDetails = new OrderDetail()
                {
                    Name = user.UserData.Name,
                    Surname = user.UserData.Surname,
                    Adress = user.UserData.Adress,
                    City = user.UserData.City,
                    ZipCode = user.UserData.ZipCode,
                    Email = user.UserData.Email,
                    Phone = user.UserData.Phone
                };
                return View(oderDetails);
            }
            else
            {
               return  RedirectToAction("Login","Account", new { returnUrl=Url.Action("MakeAnOrder", "ShoppingCart")});
            }
        }
        [HttpPost]
        public async Task<ActionResult> MakeAnOrder(ShoppingCartManager cart ,OrderDetail orderDetails)
        {
            if (ModelState.IsValid)
            {
                var userID = User.Identity.GetUserId();
                var newOrder = cart.CreateAnOrder(orderDetails, userID);

                var user = await UserManager.FindByIdAsync(userID);
                TryUpdateModel(user.UserData);//aktualizacja danych w przypadku aktualizacji danych wpr przez Usera
                await UserManager.UpdateAsync(user);
                cart.Clear();
                return RedirectToAction ("OrderConfirmation");
            }
            else
            {
                return View(orderDetails);
            }
           
        }
        public ActionResult OrderConfirmation()
        {
          
            return View();

        }

        public PartialViewResult Cart(ShoppingCartManager cart)
        {
            return PartialView(cart);
        }
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

    }
}
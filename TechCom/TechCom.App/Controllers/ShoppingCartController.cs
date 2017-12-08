using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TechCom.Infrastructure;
using TechCom.Infrastructure.ViewModels;
using TechCom.Model.Domain.Domain;
using TechCom.Model.Domain.Interface;

namespace TechCom.App.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        private IProduct productRepository;
        private IMail emailRepository;
        private IOrderDetails orderRepository;
        private ApplicationDbContext db;

        public ShoppingCartController(IProduct productRepository, IMail emailRepository, IOrderDetails orderRepository, ApplicationDbContext db)
        {
            this.productRepository = productRepository;
            this.emailRepository = emailRepository;
           this.orderRepository = orderRepository;
            this.db = db;
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
           
            db.SaveChanges();
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
                    Email = user.Email,
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
                TryUpdateModel(user.UserData);
                await UserManager.UpdateAsync(user);
                cart.Clear();
                
             
                emailRepository.SendConfirmationOrder(newOrder);
           
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
using System;
using System.Collections.Generic;
using System.Linq;
using TechCom.Model.Domain.Domain;
using TechCom.Model.Domain.Interface;
using TechCom.Model.Domain.ViewModels;

namespace TechCom.Infrastructure
{
    public class ShoppingCartManager
        
    {
        private ApplicationDbContext db=new ApplicationDbContext();
       // private IProduct productRepository;
        //private ISessionManager session;
        //public ShoppingCartManager(ISessionManager session,EFAppContext db)
        //{
        //    this.session = session;
        //    this.db = db;

        //}
        private List<ShoppingCart> productCollection = new List<ShoppingCart>();

        public void AddProducts(Product product, int quantity)
        {
            ShoppingCart cart = productCollection.Where(p => p.Product.ProductID == product.ProductID).FirstOrDefault();
            if (cart==null)
            {
                productCollection.Add(new ShoppingCart() { Product = product, Quantity = quantity });
            }
            else
            {
                cart.Quantity += quantity;
            }
            db.SaveChanges();

        }
     
        public void RemoveProduct(Product product)
        {
            productCollection.RemoveAll(p => p.Product.ProductID == product.ProductID);
        }
        public Decimal WorthOfProduct()
        {
            return productCollection.Sum(p => p.Product.Price*p.Quantity);
        }
        public void Clear()
        {
            productCollection.Clear();
        }
        public List<ShoppingCart> ContentOfCart
        {
           get{ return productCollection; }
        }
        public OrderListViewModel CreateAnOrder(OrderListViewModel newOrder, string userID, DeliveryOption delivery)
        {
            
            var shoppingCart = ContentOfCart;
            
            newOrder.OrderDetails.DateOfTheOrder = DateTime.Now;
            newOrder.OrderDetails.UserID = userID;
            newOrder.OrderDetails.ValueOfOrder = WorthOfProduct();
            newOrder.OrderDetails.TypeOfDelivery = delivery.TypeOfDelivery;
            newOrder.OrderDetails.PriceDelivery = delivery.PriceOfDelivery;

            db.ShippingDetails.Add(newOrder.OrderDetails);
            
            if (newOrder.OrderDetails.Orders == null)
            {
                newOrder.OrderDetails.Orders = new List<Order>();
            }
            decimal worthOfCard = 0;
            foreach (var item in shoppingCart)
            {
                var order = new Order()
                {
                    ProductID = item.Product.ProductID,
                    Quantity = item.Quantity,
                    Price = item.Product.Price,
                                           
               };
                             
                worthOfCard += (item.Quantity * item.Product.Price);
                newOrder.OrderDetails.Orders.Add(order);
                Product prod = (from p in db.Products where p.ProductID == order.ProductID select p).Single();
                prod.Quantity -= order.Quantity;
            }
            
            newOrder.OrderDetails.ValueOfOrder = worthOfCard + delivery.PriceOfDelivery; 

            db.SaveChanges();
            return newOrder;
        }
    }
}

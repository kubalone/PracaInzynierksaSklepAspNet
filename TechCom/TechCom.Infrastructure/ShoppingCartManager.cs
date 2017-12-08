using System;
using System.Collections.Generic;
using System.Linq;
using TechCom.Model.Domain.Domain;
using TechCom.Model.Domain.Interface;

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
        public OrderDetail CreateAnOrder(OrderDetail newOrder, string userID)
        {
            
            var shoppingCart = ContentOfCart;
            
            newOrder.DateOfTheOrder = DateTime.Now;
            newOrder.UserID = userID;
            newOrder.ValueOfOrder = WorthOfProduct();
            
            db.ShippingDetails.Add(newOrder);
            
            if (newOrder.Orders == null)
            {
                newOrder.Orders = new List<Order>();
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
                newOrder.Orders.Add(order);
                Product prod = (from p in db.Products where p.ProductID == order.ProductID select p).Single();
                prod.Quantity -= order.Quantity;
            }
            
            newOrder.ValueOfOrder = worthOfCard;

            db.SaveChanges();
            return newOrder;
        }
    }
}

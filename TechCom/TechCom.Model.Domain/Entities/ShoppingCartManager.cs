using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCom.Model.Domain.EFRepository;
using TechCom.Model.Domain.Repository;

namespace TechCom.Model.Domain.Entities
{
    public class ShoppingCartManager
        
    {
        private EFAppContext db; 
        public ShoppingCartManager(EFAppContext db)
        {
            this.db = db;
        }
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
        public IEnumerable<ShoppingCart> ContentOfCart
        {
           get{ return productCollection; }
        }
        public OrderDetail CreateAnOrder(OrderDetail newOrder,string userID)//przeanalizować połaączenie z kontem usera
        {
            var shoppingCart = ContentOfCart;
            newOrder.DateOfTheOrder = DateTime.Now;
            db.ShippingDetails.Add(newOrder);
            if (newOrder.Orders==null)
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
                    Price = item.Quantity

                };
                worthOfCard += item.Quantity * item.Product.Price;
                newOrder.Orders.Add(order);
            }
            newOrder.ValueOfOrder = worthOfCard;
            db.SaveChanges();
            return newOrder;
        }
    }
}

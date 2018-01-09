using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCom.Model.Domain.Domain;
using TechCom.Model.Domain.Interface;

namespace TechCom.Infrastructure
{
   public class OrderRepository:IOrderDetails
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        public DbSet<OrderDetail> Orders
        {
            get
            {
                return context.ShippingDetails;
            }
        }
        public OrderDetail NewOrderDetail(ApplicationUser user)
        {
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
            return oderDetails;
        }
        //zwraca wszystkie zamówienia
        public IEnumerable<OrderDetail> GetOrder()
        {
            var orderOfUser = context.ShippingDetails.Include("Orders").OrderByDescending(p => p.DateOfTheOrder).ToList();
            return orderOfUser;
        }
        //zwraca zamównie dla danego użytkownika
        public IEnumerable<OrderDetail> GetOrderForUser(string userID)
        {
           var orderOfUser = context.ShippingDetails.Where(p => p.UserID == userID).Include("Orders").OrderByDescending(p => p.DateOfTheOrder).ToList();
           return orderOfUser;

        }
        //sortowanie zamówień
        public IEnumerable<OrderDetail> SortOrder(OrderStatus status)
        {
            var orderOfUser = context.ShippingDetails.Where(p => p.OrderStatus == status).OrderByDescending(p => p.DateOfTheOrder).ToList();
            return orderOfUser;
        }
        //wyszukiwanie zamówień
        public IEnumerable<OrderDetail> SearchOrder(IEnumerable<OrderDetail> ordersOfUser,string searchString)
        {
            var orderOfUser = ordersOfUser.Where(s => s.Name.ToLower().Contains(searchString) || s.Surname.ToLower().Contains(searchString) || s.User.UserName.ToLower().Contains(searchString)).ToList();
            return orderOfUser;
        }
        //sortowanie wyszukanych zamówień
        public IEnumerable<OrderDetail> SortSearchOrders(string searchString, OrderStatus status)
        {
           var  orderOfUser = context.ShippingDetails.Where(s => s.OrderStatus == status && s.Name.ToLower().Contains(searchString) || s.Surname.ToLower().Contains(searchString) || s.User.UserName.ToLower().Contains(searchString)).OrderByDescending(p => p.DateOfTheOrder).ToList();
           return orderOfUser;
        }
        //zwraca wyszukane zamówienie
        public OrderDetail GetOrderByID(OrderDetail item)
        {
           var order = context.ShippingDetails.Find(item.ShippingID);
            order.OrderStatus = item.OrderStatus;
            context.SaveChanges();
            return order;
        }



    }
}

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
        
    }
}

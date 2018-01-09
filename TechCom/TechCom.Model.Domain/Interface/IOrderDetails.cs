using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCom.Model.Domain.Domain;

namespace TechCom.Model.Domain.Interface
{
   public interface IOrderDetails
    {
        DbSet< OrderDetail> Orders { get; }
        OrderDetail NewOrderDetail(ApplicationUser user);
        IEnumerable<OrderDetail> GetOrder();
        IEnumerable<OrderDetail> GetOrderForUser(string userID);
        IEnumerable<OrderDetail> SortOrder(OrderStatus status);
        IEnumerable<OrderDetail> SearchOrder(IEnumerable<OrderDetail> ordersOfUser, string searchString);
        IEnumerable<OrderDetail> SortSearchOrders(string searchString, OrderStatus status);
        OrderDetail GetOrderByID(OrderDetail item);
    }
}

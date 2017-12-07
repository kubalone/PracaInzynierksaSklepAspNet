using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechCom.App.Infrastructure.Helpers;
using TechCom.App.Models;
using TechCom.App.ViewModels;

namespace TechCom.App.Repository
{
    public class PostMailRepository : IMail
    {
        public void SendConfirmationOrder(OrderDetail order)
        {
            var email = new ConfirmationMakeOrder()
            {
                To = order.Email,
                From = "skleptechcom@gmail.com",
                Worth = order.ValueOfOrder,
                OrderID = order.ShippingID,
                Order = order.Orders      
            };
            email.Send();
        }
        public void SendAcceptanceOfTheOrder(OrderDetail order)
        {

            var email = new AcceptanceOfTheOrder()
            {
                To = order.Email,
                From = "skleptechcom@gmail.com",
                OrderID = order.ShippingID,
            };
            email.Send();
        }
        public void SendConfirmationRealizeOrder(OrderDetail order)
        {

            var email = new ConfirmationRealizedOrder()
            {
                To = order.Email,
                From = "skleptechcom@gmail.com",
                OrderID = order.ShippingID,
            };
            email.Send();
        }
      
       

    }
}
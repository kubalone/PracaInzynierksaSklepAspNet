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
                From = "ankakubalka@gmail.com",
                Worth = order.ValueOfOrder,
                OrderID = order.ShippingID,
                Order = order.Orders
                // ImageProduct = ImageConfig.ImageSource,

            };
            email.Send();
        }

        public void SendConfirmationRealizeOrder(OrderDetail order)
        {
            var email = new ConfirmationRealizedOrder()
            {
                To = order.Email,
                From = "skleptechcom@o2.pl",
                OrderID = order.ShippingID,
            };
            email.Send();
        }

    }
}
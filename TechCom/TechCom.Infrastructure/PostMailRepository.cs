//using TechCom.App.Infrastructure.Helpers;
using TechCom.Model.Domain.Domain;
using TechCom.Model.Domain.Interface;
using TechCom.Model.Domain.ViewModels;

namespace TechCom.Infrastructure
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
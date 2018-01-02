using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCom.Model.Domain.Domain;
using TechCom.Model.Domain.ViewModels;

namespace TechCom.Model.Domain.Interface
{
   public interface IDeliverOption
    {
        IEnumerable<DeliveryOption> DeliveryOptions { get; }
        List<DeliveryOption> SearchDeliveryOption(string searchString, List<DeliveryOption> deliveryOptions);
        DeliveryOption GetDeliveryByID(int idDelivery);
        void SaveDeliveryOption(DeliveryOption delivery);
        DeliveryOption Delete(int idDelivery);
        List<DeliveryOption> SortDeliveryOption();
        DeliveryOption GetDeliveryOption(OrderListViewModel model);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCom.Model.Domain.Domain;
using TechCom.Model.Domain.Interface;
using TechCom.Model.Domain.ViewModels;

namespace TechCom.Infrastructure
{
    public class DeliverOptionRepository : IDeliverOption
    {
        private ApplicationDbContext context = new ApplicationDbContext();

       
        public IEnumerable<DeliveryOption> DeliveryOptions
        {
            get
            {
                return context.DeliveryOptions;
            }
        }
        public List<DeliveryOption> SearchDeliveryOption(string searchString, List<DeliveryOption> deliveryOptions)
        {
            var deliveryOption = deliveryOptions.Where(s => s.TypeOfDelivery.ToUpper().Contains(searchString.ToUpper())).ToList();
            return deliveryOption;
        }
        public DeliveryOption GetDeliveryByID(int idDelivery)
        {
            var delivery=context.DeliveryOptions.FirstOrDefault(p => p.DeliveryOptionID == idDelivery);
            return delivery;

        }
        //zapisywanie opcji dostawy
        public void SaveDeliveryOption(DeliveryOption delivery)
        {
            if (delivery.DeliveryOptionID == 0)
            {
                context.DeliveryOptions.Add(delivery);
            }
            else
            {
                DeliveryOption dbEntry = context.DeliveryOptions.Find(delivery.DeliveryOptionID);
                if (dbEntry != null)
                {
                    dbEntry.TypeOfDelivery = delivery.TypeOfDelivery;
                    dbEntry.PriceOfDelivery = delivery.PriceOfDelivery;
                }
            }
            context.SaveChanges();
        }

        public DeliveryOption Delete(int idDelivery)
        {
            DeliveryOption dbEntry = context.DeliveryOptions.Find(idDelivery);
            if (dbEntry != null)
            {
                context.DeliveryOptions.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        //sortowanie Opcji dostawy
        public List<DeliveryOption> SortDeliveryOption()
        {
            var deliveryOptions = context.DeliveryOptions.OrderBy(p => p.PriceOfDelivery).ToList();
            return deliveryOptions;
        }
        //wyszukiwnie opcji dostawy przekazanej do kontrolera
        public DeliveryOption GetDeliveryOption(OrderListViewModel model)
        {
            var deliveryOption=context.DeliveryOptions.Where(p => p.DeliveryOptionID == model.OrderDetails.SelectedDeliveryId).Single();
            return deliveryOption;
        }
       
    }
}

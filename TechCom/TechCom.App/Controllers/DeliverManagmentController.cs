using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechCom.Model.Domain.Domain;
using TechCom.Model.Domain.Interface;

namespace TechCom.App.Controllers
{
    public class DeliverManagmentController : Controller
    {
        private IDeliverOption deliveryRepository;
        public DeliverManagmentController(IDeliverOption deliveryRepository)
        {
            this.deliveryRepository = deliveryRepository;
        }
        // GET: DeliverManagment
        public ActionResult DeliverOptionManagment(string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentFilter = searchString;
            var deliveryOptions = deliveryRepository.DeliveryOptions.OrderBy(p => p.DeliveryOptionID).ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                deliveryOptions = deliveryRepository.SearchDeliveryOption(searchString, deliveryOptions);
            }

            return View(deliveryOptions);
        }

        public ActionResult Edit(int idDelivery)
        {
            DeliveryOption delivery = deliveryRepository.GetDeliveryByID(idDelivery);
            return View(delivery);
        }
        [HttpPost]
        public ActionResult Edit(DeliveryOption delivery)
        {
            if (ModelState.IsValid)
            {
                deliveryRepository.SaveDeliveryOption(delivery);
                TempData["message"] = string.Format("Zapisano {0} ", delivery.TypeOfDelivery);
                return RedirectToAction("DeliverOptionManagment");
            }
            else
            {
               
                return View(delivery);
            }
        }
        public ViewResult Create()
        {
            return View("Edit", new DeliveryOption());
        }
      
        public ActionResult Delete(int idDelivery)
        {
            DeliveryOption deletedOption = deliveryRepository.Delete(idDelivery);
            if (deletedOption != null)
            {
                TempData["message"] = string.Format("Usunięto {0}", deletedOption.TypeOfDelivery);
            }
            return RedirectToAction("DeliverOptionManagment");
        }
    }
}
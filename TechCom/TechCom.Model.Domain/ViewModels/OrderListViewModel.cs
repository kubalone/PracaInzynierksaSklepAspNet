using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechCom.Model.Domain.Domain;

namespace TechCom.Model.Domain.ViewModels
{
    public class OrderListViewModel
    {
        public OrderListViewModel()
        {
            OrderUserList = new List<SelectListItem>();
        }
        public IPagedList<OrderDetail> OrderDetail { get; set; }
        public IEnumerable<SelectListItem> OrderUserList { get; set; }
        public OrderDetail OrderDetails { get; set; }
        public  List<DeliveryOption> DeliveryOptions { get; set; }
        public decimal DeliveryPrice { get; set; }
        public int? OrderBy { get; set; }
    }
}
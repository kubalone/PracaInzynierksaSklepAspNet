using Postal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechCom.Model.Domain.Domain;

namespace TechCom.Model.Domain.ViewModels
{
    public class ConfirmationMakeOrder:Email
    {
        public string To { get; set; }
        public string From { get; set; }
        public decimal Worth { get; set; }
        public int OrderID { get; set; }
        public List<Order> Order{ get; set; }
    }
    public class AcceptanceOfTheOrder : Email
    {
        public string To { get; set; }
        public string From { get; set; }
        public int OrderID { get; set; }
    }
    public class ConfirmationRealizedOrder : Email
    {
        public string To { get; set; }
        public string From { get; set; }
        public int OrderID { get; set; }
    }
}
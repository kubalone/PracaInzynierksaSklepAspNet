using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCom.Model.Domain.Entities
{
   public class OrderDetail
    {
        [Key]
        public int ShippingID { get; set; }
       
        public OrderStatus OrderStatus { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Comments  { get; set; }
        public DateTime DateOfTheOrder { get; set; }
      
        public decimal ValueOfOrder { get; set; }
        public List<Order> Orders { get; set; }

    }
    public enum OrderStatus
    {
        New,
        Completed
    }
}

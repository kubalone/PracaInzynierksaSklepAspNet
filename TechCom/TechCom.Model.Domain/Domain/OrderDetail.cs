using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace TechCom.Model.Domain.Domain
{
   public class OrderDetail
    {
        [Key]
        public int ShippingID { get; set; }
        public string UserID { get; set; }
        public virtual ApplicationUser User { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Adress { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Comments  { get; set; }
        public DateTime DateOfTheOrder { get; set; }
      
        public decimal ValueOfOrder { get; set; }
        public List<Order> Orders { get; set; }

    }
    public enum OrderStatus
    {
        Nowe,
        Przyjete,
        Zrealizowane
    }
}

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
        [Required(ErrorMessage = "Wprowadź imię")]
        [StringLength(50)]
        [RegularExpression(@"/^[a-z ,.'-]+$/i", ErrorMessage = "Błędnie wprowadzone imię")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Wprowadź nazwisko")]
        [StringLength(50)]
        [RegularExpression(@"/^[a-z ,.'-]+$/i", ErrorMessage = "Błędnie wprowadzone nazwisko")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Wprowadź adres")]
        [StringLength(100)] 
        [RegularExpression(@"/^\d+\w*\s*(?:(?:[\-\/]?\s*)?\d*(?:\s*\d+\/\s*)?\d+)?\s+/", ErrorMessage = "Błędnie wprowadzony adres")]
        public string Adress { get; set; }

       
        [Required(ErrorMessage = "Wprowadź miasto")]
        [StringLength(100)]
        [RegularExpression(@"^[a-zA-Z]+(?:[\s-][a-zA-Z]+)*$", ErrorMessage = "Błędna nazwa miasta")]
        public string City { get; set; }

        [Required(ErrorMessage = "Wprowadź kod pocztowy")]
        [StringLength(6)]
        [RegularExpression(@"^\d{2}(-\d{3})?$", ErrorMessage = "Błędny kod pocztowy")]
        public string ZipCode { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Musisz wprowadzić numer telefonu")]
        [StringLength(20)]
        [RegularExpression(@"(\+\d{2})*[\d\s-]+", ErrorMessage = "Błędny format numeru telefonu")]
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

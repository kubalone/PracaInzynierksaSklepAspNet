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
        [RegularExpression(@"^[A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ\-'\s]+$", ErrorMessage = "Błędnie wprowadzone imię")]
        [StringLength(50)]   
        public string Name { get; set; }

        [Required(ErrorMessage = "Wprowadź nazwisko")]
        [StringLength(50)]
        [RegularExpression(@"^[A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ\-'\s]+$", ErrorMessage = "Błędnie wprowadzone nazwisko")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Wprowadź adres")]
        [StringLength(100)]
        [RegularExpression(@"^[A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ]+[A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ0-9'\.\-\s\,\/]+$", ErrorMessage = "Błędnie wprowadzony adres")]
        public string Adress { get; set; }

       
        [Required(ErrorMessage = "Wprowadź miasto")]
        [StringLength(100)]
        [RegularExpression(@"^[A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ]+(?:[\s-][A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ]+)*$", ErrorMessage = "Błędna nazwa miasta")]
        public string City { get; set; }

        [Required(ErrorMessage = "Wprowadź kod pocztowy")]
        [StringLength(6)]
        [RegularExpression(@"^\d{2}(-\d{3})?$", ErrorMessage = "Błędny kod pocztowy")]
        public string ZipCode { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "Musisz wprowadzić numer telefonu")]
        [StringLength(20)]
        [RegularExpression(@"^[0-9\-\+\s\(\)]{7,15}$", ErrorMessage = "Błędny format numeru telefonu")]

        public string Phone { get; set; }
        public string Comments  { get; set; }
        public DateTime DateOfTheOrder { get; set; }
      
        public decimal ValueOfOrder { get; set; }
        public List<Order> Orders { get; set; }

        public decimal PriceDelivery { get; set; }
        public string TypeOfDelivery { get; set; }
        public virtual List<DeliveryOption> DeliveryOptions { get; set; }
        //public virtual DeliveryOption SelectedDelivery { get; set; }
        public int? SelectedDeliveryId { get; set; }

    }
    public enum OrderStatus
    {
        Nowe,
        Przyjete,
        Zrealizowane
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCom.Model.Domain.Domain
{
    public class UserData
    {
      
        [RegularExpression(@"^[A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ\-'\s]+$", ErrorMessage = "Błędnie wprowadzone imię")]
        public string Name { get; set; }

        
        [RegularExpression(@"^[A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ\-'\s]+$", ErrorMessage = "Błędnie wprowadzone nazwisko")]
        public string Surname { get; set; }
        [RegularExpression(@"^[A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ]+(?:[\s-][A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ]+)*$", ErrorMessage = "Błędna nazwa miasta")]
        public string City { get; set; }
      
        [RegularExpression(@"^[A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ]+[A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ0-9'\.\-\s\,\/]+$", ErrorMessage = "Błędnie wprowadzony adres")]
        public string Adress { get; set; }

       
        [RegularExpression(@"^\d{2}(-\d{3})?$", ErrorMessage = "Błędny kod pocztowy")]
        public string ZipCode { get; set; }

        
        [RegularExpression(@"^[0-9\-\+\s\(\)]{7,15}$", ErrorMessage = "Błędny format numeru telefonu")]
        public string Phone { get; set; }
    }
}

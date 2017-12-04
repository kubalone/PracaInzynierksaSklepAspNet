using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCom.Model.Domain.Entities
{
    public class UserData
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string ZipCode { get; set; }
        //public string Email { get; set; }
        
        public string Phone { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechCom.Model.Domain.Entities;

namespace TechCom.App.Models
{
    public class ShoppingCartViewModel
    {
        public ShoppingCartManager ShoppingCartManager{ get; set; }
        public string ReturnUrl { get; set; }
    }
}
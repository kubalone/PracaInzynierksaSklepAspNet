using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace TechCom.Infrastructure.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCartManager ShoppingCartManager{ get; set; }
        public string ReturnUrl { get; set; }
    }
}
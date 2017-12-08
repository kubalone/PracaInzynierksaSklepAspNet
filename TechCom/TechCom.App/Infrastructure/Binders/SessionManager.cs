using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using TechCom.Infrastructure;

namespace TechCom.App.Infrastructure.Binders
{
    public class SessionManager : System.Web.Mvc.IModelBinder
    {
        private const string key = "ShoppingCart"; 

        public object BindModel(ControllerContext controllerContext, System.Web.Mvc.ModelBindingContext bindingContext)
        {
            ShoppingCartManager shoppingCart = null;
            if (controllerContext.HttpContext.Session != null)
            {
                shoppingCart = (ShoppingCartManager)controllerContext.HttpContext.Session[key];
            }
            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCartManager();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[key] = shoppingCart;
                }
            }
            return shoppingCart;

        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TechCom.App.DAL;
using TechCom.App.Infrastructure.Binders;
using TechCom.App.Migrations;
using TechCom.App.Services;
using TechCom.Model.Domain.Entities;


namespace TechCom.App
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
     {
          //  Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ModelBinders.Binders.Add(typeof(ShoppingCartManager), new SessionManager());
        }
    }
}

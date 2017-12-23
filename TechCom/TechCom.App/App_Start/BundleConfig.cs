﻿using System.Web;
using System.Web.Optimization;

namespace TechCom.App
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.validate.unobtrusive.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                                        "~/Content/themes/base/core.css",
                                        "~/Content/themes/base/autocomplete.css",
                                        "~/Content/themes/base/theme.css",
                                        "~/Content/themes/base/menu.css"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                     "~/Content/Prototype/css/bootstrap.css",
                     "~/Content/Prototype/css/easy-responsive-tabs.css",
                     "~/Content/Prototype/css/flexslider.css",
                     "~/Content/Prototype/css/font-awesome.css",
                     "~/Content/Prototype/css/jquery-ui.css",
                     "~/Content/Prototype/css/style.css",
                     "~/Content/Prototype/css/team.css" ));
        }
    }
}

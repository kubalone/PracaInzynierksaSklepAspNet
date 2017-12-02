using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace TechCom.App.Infrastructure.Helpers
{
    public static class UrlHelpers
    {
        public static string ImageHelper(this UrlHelper helper, string fileName)
        {
            var ImageSource = ImageConfig.ImageSource;
            var source = Path.Combine(ImageSource, fileName);
            var absoluteSource = helper.Content(source);
            return absoluteSource;
        }
    }
}
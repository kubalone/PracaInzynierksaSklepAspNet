using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TechCom.App.Infrastructure.Helpers
{
    public class ImageConfig
    {
        private static string _imageSource = ConfigurationManager.AppSettings["ImageSource"];
        public static string ImageSource { get { return _imageSource; } }
    }
}
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace straks_nl.Web.App_Start.ViewEngines
{
    public class FeatureViewEngine : RazorViewEngine
    {
        public FeatureViewEngine() : base()
        {
            var featureFolderAreaViewLocationFormats = new[]
           {
                "~/Areas/{2}/Features/{1}/{0}.cshtml",
                "~/Areas/{2}/Features/{1}/{0}.cshtml",
                "~/Areas/{2}/Features/{1}/Views/{0}.cshtml",
                "~/Areas/{2}/Features/Shared/{1}/{0}.cshtml",
                "~/Areas/{2}/Features/Shared/{0}.cshtml",

            };

            var featureFolderAreaPartialViewLocationFormats = new[]
            {
                "~/Areas/{2}/Features/{1}/Partials/{0}.cshtml",
                "~/Areas/{2}/Features/Shared/Partials/{1}/{0}.cshtml",
                "~/Areas/{2}/Features/Shared/Partials/{0}.cshtml",
            };

            AreaViewLocationFormats = featureFolderAreaViewLocationFormats;
            AreaMasterLocationFormats = featureFolderAreaViewLocationFormats;
            AreaPartialViewLocationFormats = featureFolderAreaPartialViewLocationFormats;

            var featureFolderViewLocationFormats = new[]
            {
                "~/Features/{1}/{0}.cshtml",
                "~/Features/Shared/{1}/{0}.cshtml",
                "~/Features/Shared/{0}.cshtml",

            };

            var featureFolderPartialViewLocationFormats = new[]
            {
                "~/Features/{1}/Partials/{0}.cshtml",
                "~/Features/Shared/Partials/{1}/{0}.cshtml",
                "~/Features/Shared/Partials/{0}.cshtml",
            };

            ViewLocationFormats = featureFolderViewLocationFormats;
            MasterLocationFormats = featureFolderViewLocationFormats;
            PartialViewLocationFormats = featureFolderPartialViewLocationFormats;
        }
    }
    
}
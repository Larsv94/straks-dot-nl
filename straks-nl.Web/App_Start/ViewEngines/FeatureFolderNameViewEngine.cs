using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace straks_nl.Web.App_Start.ViewEngines
{
    public class FeatureFolderNameViewEngine : RazorViewEngine
    {
        public static readonly string FEATURE = "%feature%";
        public static readonly string MANY_FEATURES = "%manyfeature%";
        public FeatureFolderNameViewEngine() : base()
        {

            var featureFolderAreaViewLocationFormats = new[]
           {
                //Folder based naming conventions
                "~/Areas/{2}/Features/"+MANY_FEATURES+"/{0}.cshtml",
                "~/Areas/{2}/Features/"+MANY_FEATURES+"/Views/{0}.cshtml",
                "~/Areas/{2}/Features/"+FEATURE+"/{0}.cshtml",
                "~/Areas/{2}/Features/"+FEATURE+"/Views/{0}.cshtml",

            };

            var featureFolderAreaPartialViewLocationFormats = new[]
            {
                "~/Areas/{2}/Features/"+MANY_FEATURES+"/Partials/{0}.cshtml",
                "~/Areas/{2}/Features/"+FEATURE+"/Partials/{0}.cshtml",
            };

            AreaViewLocationFormats = featureFolderAreaViewLocationFormats;
            AreaMasterLocationFormats = featureFolderAreaViewLocationFormats;
            AreaPartialViewLocationFormats = featureFolderAreaPartialViewLocationFormats;

            var featureFolderViewLocationFormats = new[]
            {
                //Folder based naming conventions
                "~/Features/"+MANY_FEATURES+"/{0}.cshtml",
                "~/Features/"+MANY_FEATURES+"/Views/{0}.cshtml",
                "~/Features/"+FEATURE+"/{0}.cshtml",
                "~/Features/"+FEATURE+"/Views/{0}.cshtml",

            };

            var featureFolderPartialViewLocationFormats = new[]
            {
                "~/Features/"+MANY_FEATURES+"/Partials/{0}.cshtml",
                "~/Features/"+FEATURE+"/Partials/{0}.cshtml",
            };

            ViewLocationFormats = featureFolderViewLocationFormats;
            MasterLocationFormats = featureFolderViewLocationFormats;
            PartialViewLocationFormats = featureFolderPartialViewLocationFormats;
        }
        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            return base.CreateView(controllerContext, viewPath.ReplaceFeatures(controllerContext), masterPath);
        }

        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            return base.CreatePartialView(controllerContext, partialPath.ReplaceFeatures(controllerContext));
        }

        protected override bool FileExists(ControllerContext controllerContext, string virtualPath)
        {
            return base.FileExists(controllerContext, virtualPath.ReplaceFeatures(controllerContext));
        }
    }
    static class FeatureExtensions
    {
        internal static string ReplaceFeatures(this string path, ControllerContext context)
        {
            if (path.Contains(FeatureFolderNameViewEngine.MANY_FEATURES))
            {
                return path.Replace(FeatureFolderNameViewEngine.MANY_FEATURES, GetManyFeatureNames(context.Controller.GetType()));
            }
            return path.Replace(FeatureFolderNameViewEngine.FEATURE, GetFeatureName(context.Controller.GetType()));
        }

        private static string GetFeatureName(Type controllerType)
        {
            var tokens = controllerType.FullName.Split('.');
            if (tokens.All(t => t != "Features"))
                return "";
            var featureName = tokens
            .SkipWhile(t => !t.Equals("features", StringComparison.CurrentCultureIgnoreCase))
            .Skip(1)
            .Take(1)
            .FirstOrDefault();

            return featureName;
        }

        private static string GetManyFeatureNames(Type controllerType)
        {
            var tokens = controllerType.FullName.Split('.');
            if (tokens.All(t => t != "Features"))
                return "";
            var featureNames = tokens.Take(tokens.Length - 1)
            .SkipWhile(t => !t.Equals("features", StringComparison.CurrentCultureIgnoreCase))
            .Skip(1);

            return String.Join("/", featureNames);
        }
    }
}
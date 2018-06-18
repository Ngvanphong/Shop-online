using System.Web.Optimization;

namespace ShopOnline.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js/jquery").Include(
                        "~/Assets/client/js/jquery.min.js"
                        ));
            bundles.Add(new ScriptBundle("~/js/plugins").Include(
                       "~/Scripts/jquery.validate.min.js",
                       "~/Scripts/mustache.js",
                       "~/Scripts/numeral/numeral.min.js",
                        "~/Assets/client/js/jquery.easing.1.3.js",
                       "~/Assets/client/js/bootstrap.min.js",
                        "~/Assets/client/js/jquery.waypoints.min.js",
                        "~/Assets/client/js/jquery.flexslider-min.js",
                       "~/Assets/client/js/owl.carousel.min.js",
                       "~/Assets/client/js/jquery.magnific-popup.min.js",
                       "~/Assets/client/js/magnific-popup-options.js",
                       "~/Assets/client/js/bootstrap-datepicker.js",
                       "~/Assets/client/js/jquery.stellar.min.js",
                       "~/Assets/client/js/main.js"

                       ));
            bundles.Add(new ScriptBundle("~/js/shoppingcart").Include(
                       "~/Assets/client/js/shoppingCart.js"
                       ));

            bundles.Add(new StyleBundle("~/css/base")
                .Include("~/Assets/client/css/animate.css", new CssRewriteUrlTransform())
                .Include("~/Assets/client/css/icomoon.css", new CssRewriteUrlTransform())
                .Include("~/Assets/client/css/bootstrap.css", new CssRewriteUrlTransform())
                .Include("~/Assets/client/css/magnific-popup.css", new CssRewriteUrlTransform())
                .Include("~/Assets/client/css/flexslider.css", new CssRewriteUrlTransform())
                .Include("~/Assets/client/css/owl.carousel.min.css", new CssRewriteUrlTransform())
                .Include("~/Assets/client/css/owl.theme.default.min.css", new CssRewriteUrlTransform())
                .Include("~/Assets/client/css/font-awesome.css", new CssRewriteUrlTransform())
                .Include("~/Assets/client/css/bootstrap-datepicker.css", new CssRewriteUrlTransform())
                .Include("~/Assets/client/fonts/flaticon/font/flaticon.css", new CssRewriteUrlTransform())
                .Include("~/Assets/client/css/style.css", new CssRewriteUrlTransform())  
                     );
            BundleTable.EnableOptimizations = true;
        }
    }
}
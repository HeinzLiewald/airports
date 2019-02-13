using System.Web.Optimization;

namespace Web {
    public class BundleConfig {
        public static void RegisterBundles(BundleCollection bundles) {
            bundles.Add(new ScriptBundle("~/jquery").Include(
                        "~/Static/js/jquery.js"));

            bundles.Add(new StyleBundle("~/css").Include(
                      "~/Static/css/cognizant-style.css"));
        }
    }
}

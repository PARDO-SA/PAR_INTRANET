using System.Web;
using System.Web.Optimization;

namespace PAR_INTRANET
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/jquery.validate.unobtrusive.js"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));


            // JQuery validator. 
            bundles.Add(new ScriptBundle("~/bundles/custom-validator").Include(
                                  "~/Scripts/script-custom-validator.js"));


            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/jquery.dataTables.min.js",
                "~/Scripts/dataTables.buttons.min.js",
                "~/Scripts/buttons.flash.min.js",
                "~/Scripts/jszip.min.js",
                "~/Scripts/pdfmake.min.js",
                "~/Scripts/vfs_fonts.js",
                "~/Scripts/buttons.html5.min.js",
                "~/Scripts/buttons.print.min.js",
                "~/Scripts/bootstrap.js",
                "~/admin-lte/js/adminlte.js",
                "~/admin-lte/plugins/iCheck/icheck.js",
                "~/admin-lte/plugins/fastclick/fastclick.js",
                "~/Scripts/respond.js",
                "~/Scripts/table.js"      
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/jquery.dataTables.css",
                      "~/Content/buttons.dataTables.min.css",
                      "~/Content/custom.css",
                      "~/admin-lte/css/AdminLTE.css",
                      "~/admin-lte/css/skins/skin-blue.css"));
         
        }
    }
}

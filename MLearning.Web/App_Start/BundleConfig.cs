using System.Web;
using System.Web.Optimization;

namespace MLearning.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            /*bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));*/

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/kendo/2014.3.1411/jquery.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/style.css"));

            bundles.Add(new StyleBundle("~/Content/app").Include(
                      "~/Content/app/animate.css",
                      "~/Content/app/box.css",
                      "~/Content/app/main.css",
                      "~/Content/app/style.css"));


            bundles.Add(new StyleBundle("~/Content/kendo").Include(
                "~/Content/kendo/2014.3.1411/kendo.common.min.css",
	            "~/Content/kendo/2014.3.1411/kendo.mobile.all.min.css",
	            "~/Content/kendo/2014.3.1411/kendo.dataviz.min.css",
	            "~/Content/kendo/2014.3.1411/kendo.metro.min.css",
	            "~/Content/kendo/2014.3.1411/kendo.dataviz.default.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                "~/Scripts/kendo/2014.3.1411/jquery.min.js",
                "~/Scripts/kendo/2014.3.1411/jszip.min.js",
                "~/Scripts/kendo/2014.3.1411/kendo.all.min.js",
                "~/Scripts/kendo/2014.3.1411/kendo.aspnetmvc.min.js",
                "~/Scripts/kendo.modernizr.custom.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                      "~/Scripts/angular.js",
                      "~/Scripts/angular-route.js",
                      "~/Scripts/angular-animate.js",
                      "~/Scripts/angular-resource.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                        "~/Scripts/app/app.js",
                        "~/Scripts/app/globalService.js",
                        "~/Scripts/app/controllers/main.js",
                        "~/Scripts/app/controllers/about.js",
                        "~/Scripts/app/controllers/admin/instituciones.js",
                        "~/Scripts/app/controllers/admin/unidades.js",
                        "~/Scripts/app/controllers/admin/administrador.js",
                        "~/Scripts/app/services/admin/administrador.js",
                        "~/Scripts/app/services/admin/instituciones.js",
                        "~/Scripts/app/services/admin/unidades.js",
                        "~/Scripts/app/directives/slides-editor.js",
                        "~/Scripts/app/controllers/director/home.js",
                        "~/Scripts/app/controllers/director/profesores.js",
                        "~/Scripts/app/controllers/director/alumnos.js",
                        "~/Scripts/app/controllers/director/circulos.js",
                        "~/Scripts/app/directives/select-imagen.js",
                        
                        "~/Scripts/app/pagina/paginaController.js",
                        "~/Scripts/app/pagina/paginaService.js",

                        "~/Scripts/app/seccion/seccionController.js",
                        "~/Scripts/app/seccion/seccionService.js",

                        "~/Scripts/app/unidad/unidadController.js",
                        "~/Scripts/app/unidad/unidadService.js",

                        "~/Scripts/app/examen/examenController.js",
                        "~/Scripts/app/examen/examenService.js"));

            BundleTable.EnableOptimizations = false;           
        }
    }
}

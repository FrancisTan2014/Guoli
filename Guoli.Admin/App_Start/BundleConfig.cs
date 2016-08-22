using System.Web;
using System.Web.Optimization;

namespace Guoli.Admin
{
    public class BundleConfig
    {
        // 有关 Bundling 的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            // minovate模板样式
            bundles.Add(new StyleBundle("~/Content/minovate/css").Include(
                        "~/Content/minovate/css/vendor/bootstrap.min.css",
                        "~/Content/minovate/css/vendor/animate.css",
                        "~/Content/minovate/css/vendor/font-awesome.min.css",
                        "~/Content/minovate/js/vendor/animsition/css/animsition.min.css",
                        "~/Content/minovate/js/vendor/daterangepicker/daterangepicker-bs3.css",
                        "~/Content/minovate/js/vendor/morris/morris.css",
                        "~/Content/minovate/js/vendor/owl-carousel/owl.carousel.css",
                        "~/Content/minovate/js/vendor/owl-carousel/owl.theme.css",
                        "~/Content/minovate/js/vendor/rickshaw/rickshaw.min.css",
                        "~/Content/minovate/js/vendor/datetimepicker/css/bootstrap-datetimepicker.min.css",
                        "~/Content/minovate/js/vendor/datatables/css/jquery.dataTables.min.css",
                        "~/Content/minovate/js/vendor/datatables/datatables.bootstrap.min.css",
                        "~/Content/minovate/js/vendor/chosen/chosen.css",
                        "~/Content/minovate/js/vendor/summernote/summernote.css",
                        "~/Content/minovate/css/main.css"
                        ));

            // minovate模板js
            bundles.Add(new ScriptBundle("~/Content/minovate/js").Include(
                        "~/Scripts/jquery-1.8.2.min.js",
                        "~/Content/minovate/js/vendor/modernizr/modernizr-2.8.3-respond-1.4.2.min.js",
                        "~/Content/minovate/js/vendor/bootstrap/bootstrap.min.js",
                        "~/Content/minovate/js/vendor/jRespond/jRespond.min.js",
                        "~/Content/minovate/js/vendor/d3/d3.min.js",
                        "~/Content/minovate/js/vendor/d3/d3.layout.min.js",
                        "~/Content/minovate/js/vendor/rickshaw/rickshaw.min.js",
                        "~/Content/minovate/js/vendor/sparkline/jquery.sparkline.min.js",
                        "~/Content/minovate/js/vendor/slimscroll/jquery.slimscroll.min.js",
                        "~/Content/minovate/js/vendor/animsition/js/jquery.animsition.min.js",
                        "~/Content/minovate/js/vendor/daterangepicker/moment.min.js",
                        "~/Content/minovate/js/vendor/daterangepicker/daterangepicker.js",
                        "~/Content/minovate/js/vendor/screenfull/screenfull.min.js",
                        "~/Content/minovate/js/vendor/flot/jquery.flot.min.js",
                        "~/Content/minovate/js/vendor/flot-tooltip/jquery.flot.tooltip.min.js",
                        "~/Content/minovate/js/vendor/flot-spline/jquery.flot.spline.min.js",
                        "~/Content/minovate/js/vendor/easypiechart/jquery.easypiechart.min.js",
                        "~/Content/minovate/js/vendor/raphael/raphael-min.js",
                        "~/Content/minovate/js/vendor/morris/morris.min.js",
                        "~/Content/minovate/js/vendor/owl-carousel/owl.carousel.min.js",
                        "~/Content/minovate/js/vendor/datetimepicker/js/bootstrap-datetimepicker.min.js",
                        "~/Content/minovate/js/vendor/datatables/js/jquery.dataTables.min.js",
                        "~/Content/minovate/js/vendor/datatables/extensions/dataTables.bootstrap.js",
                        "~/Content/minovate/js/vendor/chosen/chosen.jquery.min.js",
                        "~/Content/minovate/js/vendor/summernote/summernote.min.js",
                        "~/Content/minovate/js/vendor/coolclock/coolclock.js",
                        "~/Content/minovate/js/vendor/coolclock/excanvas.js",
                        "~/Content/minovate/js/main.js"));
        }
    }
}
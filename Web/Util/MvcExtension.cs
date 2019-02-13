namespace System.Web.Mvc {
    public static class MvcExtension {
        public static MvcHtmlString IncludeVersionedJs(this HtmlHelper helper, string filename) {
            string _src = GetVersionedPath(helper, filename);
            return MvcHtmlString.Create($"<script type='text/javascript' src='{_src}'></script>");
        }

        public static MvcHtmlString IncludeVersionedCss(this HtmlHelper helper, string filename) {
            string _href = GetVersionedPath(helper, filename);
            return MvcHtmlString.Create($"<link rel='stylesheet' type='text/css' href='{_href}' />");
        }

        private static string GetVersionedPath(this HtmlHelper helper, string filename) {
            var _context = helper.ViewContext.RequestContext.HttpContext;
            var _physicalPath = _context.Server.MapPath($"~/{filename}");

            var _lastWriteTime = new System.IO.FileInfo(_physicalPath).LastWriteTime;
            var _version = $"?v={_lastWriteTime.ToString("yyyyMMddHHmmss")}";

            var _applicationPath = _context.Request.ApplicationPath;
            if (!_applicationPath.Equals("/")) {
                _applicationPath += "/";
            }

            return _applicationPath + filename + _version;
        }
    }
}

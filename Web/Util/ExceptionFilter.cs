using System;
using System.Web.Mvc;

namespace Web.Util {
    public class ExceptionFilter : ActionFilterAttribute, IExceptionFilter {

        private string _viewName = "~/Views/Error/Index.cshtml";

        public void OnException(ExceptionContext filterContext) {
            Exception _exception = filterContext.Exception;
            filterContext.ExceptionHandled = true;

            //TODO: write the error somewhere!

            filterContext.HttpContext.Response.StatusCode = 200;

            if (!filterContext.HttpContext.Request.IsAjaxRequest()) {
                var result = new ViewResult() {
                    ViewName = _viewName
                };

                result.ViewBag.Message = _exception.Message;

                filterContext.Result = result;
            } else {
                filterContext.Result = new JsonResult() {
                    Data = new { success = false, error = _exception.Message },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }
    }
}

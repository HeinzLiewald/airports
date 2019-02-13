using System;
using System.Web.Mvc;

namespace Web.Util {
    public class IncludeFeedTimeAttribute : ActionFilterAttribute {
        public override void OnResultExecuting(ResultExecutingContext context) {
            context.HttpContext.Response.Headers.Add("from-feed", DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"));
            base.OnResultExecuting(context);
        }
    }
}
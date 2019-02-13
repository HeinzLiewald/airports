using System.Web.Mvc;

namespace Web.Controllers {
    public class ErrorController : Controller {

        [HttpGet]
        public ActionResult PageNotFound() {
            Response.StatusCode = 200;

            if (ControllerContext.HttpContext.Request.IsAjaxRequest()) {
                return Json(new { success = false, error = "Page not found" }, JsonRequestBehavior.AllowGet);
            }

            return View();
        }
    }
}
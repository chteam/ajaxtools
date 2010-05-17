using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlexigridMvcDemo.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            TempData["a"] = "sss";
            Response.Redirect("/home/about");
            return RedirectToAction("About");
        }
        public ActionResult About()
        {
             
            return Content(TempData["a"].ToString());
        }   
    }
}

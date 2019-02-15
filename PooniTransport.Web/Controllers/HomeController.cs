using PooniTransport.Web.Helper;
using PooniTransport.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PooniTransport.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }


        [HttpPost]
        public JsonResult Contact(ContactViewModel model)
        {
            try
            {
                EmailSenderCls.SendMail(model);
                return Json("Email Sent Successfully!", JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(ex, JsonRequestBehavior.AllowGet);

            }
        }

        public ActionResult Gallery()
        {
            return View();
        }

        public ActionResult FlatbedServices()
        {
            return View();
        }

        public ActionResult RefrigeratedServices()
        {
            return View();
        }

        public ActionResult DryServices()
        {
            return View();
        }
    }
}
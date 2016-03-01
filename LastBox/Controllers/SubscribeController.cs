using LastBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LastBox.Controllers
{
    public class SubscribeController : Controller
    {
        // GET: Subscribe
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SubmitForm(Subscribe subscribe)
        {
            bool purchased = subscribe.Purchase;
            if (purchased == true)
            {

                TempData["BoxName"] = Session["SubBox"];
                TempData["BoxPrice"] = Session["SubPrice"];
                return RedirectToAction("../Manage/Index");
            }
            else
            {
                return View("Index");
            }

        }
    }
}
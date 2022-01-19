using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VillageWebApplication___Exam.NET.Controllers
{
    public class ChiefController : Controller
    {
       // Chief/GetChiefName
        public ActionResult GetChiefName()
        {
            try
            {
                ViewBag.WelcomeText = "Welcome Chief";
                return View();
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }


    }
}

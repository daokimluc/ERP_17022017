using ERP.Web.Models.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Web.Areas.HopLong.Controllers
{
    public class HopLongHomeController : Controller
    {
        // GET: HopLong/Home
        public ActionResult Index()
        {
            return RedirectToAction("Index", "HangHoaHL"); 
        }
    }
}
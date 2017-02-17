using ERP.Web.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Web.Areas.HopLong.Controllers
{
    public class NghiepVuNguoiDungController : Controller
    {
        private HOPLONG_DATABASEEntities db = new HOPLONG_DATABASEEntities();
        // GET: HopLong/NghiepVuNguoiDung
        public ActionResult Index()
        {
            return View();
        }

    }
}
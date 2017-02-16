using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERP.Web.Models.Database;

namespace ERP.Web.Areas.HopLong.Controllers
{
    public class KhoController : Controller
    {
        private HOPLONG_DATABASEEntities db = new HOPLONG_DATABASEEntities();

        // GET: HopLong/Kho
        public ActionResult Index()
        {
            var dM_KHO = db.DM_KHO.Include(d => d.CCTC_CONG_TY).Include(d => d.DM_KHO2);
            return View(dM_KHO.ToList());
        }

    }
}

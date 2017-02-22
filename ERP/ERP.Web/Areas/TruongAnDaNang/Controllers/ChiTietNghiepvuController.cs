using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERP.Web.Models.Database;
using ERP.Web.Models.BusinessModel;

namespace ERP.Web.Areas.TruongAnDaNang.Controllers
{
    [AuthorizeBussiness]
    public class ChiTietNghiepVuController : Controller
    {
        private HOPLONG_DATABASEEntities db = new HOPLONG_DATABASEEntities();

        // GET: HopLong/ChiTietNghiepVu
        public ActionResult Index()
        {
            var cN_CHI_TIET_NGHIEP_VU = db.CN_CHI_TIET_NGHIEP_VU.Include(c => c.CN_NGHIEP_VU);
            return View(cN_CHI_TIET_NGHIEP_VU.ToList());
        }

    }
}

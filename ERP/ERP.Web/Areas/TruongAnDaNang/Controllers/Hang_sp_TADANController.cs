using ERP.Web.Models.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Web.Areas.TruongAnDaNang.Controllers
{
    [AuthorizeBussiness]
    public class Hang_sp_TADANController : Controller
    {
        // GET: TruongAnDaNang/HANG_SP_TADAN
        public ActionResult Index()
        {
            return View();
        }
    }
}
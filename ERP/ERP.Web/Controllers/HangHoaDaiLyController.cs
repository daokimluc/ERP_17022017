using ERP.Web.Models.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Web.Controllers
{
    public class HangHoaDaiLyController : Controller
    {
        [AuthorizeBussiness]
        // GET: HangHoaDaiLy
        public ActionResult Index()
        {
            return View();
        }
    }
}
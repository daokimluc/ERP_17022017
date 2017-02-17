using ERP.Web.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ERP.Web.Areas.HopLong.Api.HeThong
{
    public class Api_ChitietnghiepvuController : ApiController
    {
        private HOPLONG_DATABASEEntities db = new HOPLONG_DATABASEEntities();
        // GET: api/Api_Chitietnghiepvu/5
        public List<CN_CHI_TIET_NGHIEP_VU> Get_Chitietnghiepvu(string id)
        {
            var vData = db.CN_CHI_TIET_NGHIEP_VU.Where(x => x.ID_NGHIEP_VU == id);
            var result = vData.ToList().Select(x => new CN_CHI_TIET_NGHIEP_VU()
            {
                ID = x.ID,
                TEN_CHI_TIET = x.TEN_CHI_TIET,
                ID_NGHIEP_VU = x.ID_NGHIEP_VU,
                MO_TA = x.MO_TA
            }).ToList();
            return result;
        }

    }
}

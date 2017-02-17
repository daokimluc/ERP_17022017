using ERP.Web.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ERP.Web.Areas.TruongAnHCM.Api.Kho
{
    public class Api_TonkhoTAHCMController : ApiController
    {
        private HOPLONG_DATABASEEntities db = new HOPLONG_DATABASEEntities();
        // GET: api/Api_TonkhoTAHCM
        public List<DM_HANG_TON_KHO> Get(string id)
        {
            var vData = db.DM_HANG_TON_KHO.Where(x => x.MA_HANG_HT == id);
            var result = vData.ToList().Select(x => new DM_HANG_TON_KHO()
            {
                MA_HANG_HT = x.MA_HANG_HT,
                MA_KHO = x.MA_KHO,
                SL_TON = x.SL_TON
            }).ToList();
            return result;
        }
        
    }
}

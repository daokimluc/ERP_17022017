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
            List<DM_HANG_TON_KHO> listtonkho = new List<DM_HANG_TON_KHO>();
            var dskho = db.DM_KHO.Where(x => x.TRUC_THUOC == "TAHCM").ToList();
            foreach (var item in dskho)
            {
                var vData = db.DM_HANG_TON_KHO.Where(x => x.MA_HANG_HT == id && x.MA_KHO == item.MA_KHO);
                if (vData.Count() > 0)
                {
                    var data = vData.FirstOrDefault();
                    DM_HANG_TON_KHO tonkho = new DM_HANG_TON_KHO();
                    tonkho.MA_HANG_HT = data.MA_HANG_HT;
                    tonkho.MA_KHO = data.MA_KHO;
                    tonkho.SL_TON = data.SL_TON;
                    listtonkho.Add(tonkho);
                }

            }



            var result = listtonkho.ToList().Select(x => new DM_HANG_TON_KHO()
            {
                MA_HANG_HT = x.MA_HANG_HT,
                MA_KHO = x.MA_KHO,
                SL_TON = x.SL_TON
            }).ToList();
            return result;
        }

       
    }
}

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

        [Route("api/Api_TonkhoTAHCM/{mahang}/{macongty}")]
        public List<DM_HANG_TON_KHO> Gettonkho(string mahang, string macongty)
        {
            List<DM_HANG_TON_KHO> result = new List<DM_HANG_TON_KHO>();
            var congty = db.CCTC_CONG_TY.Where(x => x.MA_CONG_TY == macongty).FirstOrDefault();
            string capquanly = congty.CAP_TO_CHUC;
            string tructhuoc = congty.CONG_TY_ME;

            if(capquanly == "DAI_LY")
            {
                var dskho = db.DM_KHO.Where(x => x.TRUC_THUOC == tructhuoc);
                var dskhoHL = db.DM_KHO.Where(x => x.TRUC_THUOC == "HOP_LONG");
                foreach (var item in dskho)
                {
                    foreach (var i in dskhoHL)
                    {
                        var vData = db.DM_HANG_TON_KHO.Where(x => x.MA_HANG_HT == mahang && (x.MA_KHO == item.MA_KHO || x.MA_KHO == i.MA_KHO));
                        result = vData.ToList().Select(x => new DM_HANG_TON_KHO()
                        {
                            MA_HANG_HT = x.MA_HANG_HT,
                            MA_KHO = x.MA_KHO,
                            SL_TON = x.SL_TON
                        }).ToList();
                    }
                    
                }
                
            }
            if (capquanly == "TONG_CONG_TY")
            {
                var dskhoHL = db.DM_KHO.Where(x => x.TRUC_THUOC == "HOP_LONG");
                
                    foreach (var i in dskhoHL)
                    {
                        var vData = db.DM_HANG_TON_KHO.Where(x => x.MA_HANG_HT == mahang && x.MA_KHO == i.MA_KHO);
                        result = vData.ToList().Select(x => new DM_HANG_TON_KHO()
                        {
                            MA_HANG_HT = x.MA_HANG_HT,
                            MA_KHO = x.MA_KHO,
                            SL_TON = x.SL_TON
                        }).ToList();
                    }

                

            }


            return result;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ERP.Web.Models.Database;

namespace ERP.Web.Areas.HopLong.Api.Kho
{
    public class Api_TonKhoHLController : ApiController
    {
        private HOPLONG_DATABASEEntities db = new HOPLONG_DATABASEEntities();

        // GET: api/Api_TonKhoHL
        public List<DM_HANG_TON_KHO> GetDM_HANG_TON_KHO(string id)
        {
            List<DM_HANG_TON_KHO> listtonkho = new List<DM_HANG_TON_KHO>();
           var dskho = db.DM_KHO.Where(x => x.TRUC_THUOC == "HOP_LONG").ToList();
            foreach (var item in dskho)
            {
                var vData = db.DM_HANG_TON_KHO.Where(x => x.MA_HANG_HT == id && x.MA_KHO == item.MA_KHO);
                if(vData.Count() >0)
                {
                    var data = vData.FirstOrDefault();
                    DM_HANG_TON_KHO tonkho = new DM_HANG_TON_KHO();
                    tonkho.MA_HANG_HT = data.MA_HANG_HT;
                    tonkho.MA_KHO = data.MA_KHO;
                    tonkho.SL_TON = data.SL_TON;
                    listtonkho.Add(tonkho);
                    
                    
                }
                
            }
            var tonhang = db.DM_TONKHO_HANG.Where(x => x.MA_HANG_HT == id);
            if (tonhang.Count() > 0)
            {
                var data1 = tonhang.FirstOrDefault();
                DM_HANG_TON_KHO tonkhohang = new DM_HANG_TON_KHO();
                tonkhohang.MA_HANG_HT = data1.MA_HANG_HT;
                tonkhohang.MA_KHO = "TỒN TẠI HÃNG";
                tonkhohang.SL_TON = data1.SL_TON;
                listtonkho.Add(tonkhohang);
            }
                


            var result = listtonkho.ToList().Select(x => new DM_HANG_TON_KHO()
            {
                MA_HANG_HT = x.MA_HANG_HT,
                MA_KHO = x.MA_KHO,
                SL_TON = x.SL_TON
            }).ToList();
            return result;
        }


        // PUT: api/Api_TonKhoHL/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDM_HANG_TON_KHO(string id, DM_HANG_TON_KHO dM_HANG_TON_KHO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dM_HANG_TON_KHO.MA_HANG_HT)
            {
                return BadRequest();
            }

            db.Entry(dM_HANG_TON_KHO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DM_HANG_TON_KHOExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Api_TonKhoHL
        [ResponseType(typeof(DM_HANG_TON_KHO))]
        public IHttpActionResult PostDM_HANG_TON_KHO(DM_HANG_TON_KHO dM_HANG_TON_KHO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DM_HANG_TON_KHO.Add(dM_HANG_TON_KHO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DM_HANG_TON_KHOExists(dM_HANG_TON_KHO.MA_HANG_HT))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = dM_HANG_TON_KHO.MA_HANG_HT }, dM_HANG_TON_KHO);
        }

        // DELETE: api/Api_TonKhoHL/5
        [ResponseType(typeof(DM_HANG_TON_KHO))]
        public IHttpActionResult DeleteDM_HANG_TON_KHO(string id)
        {
            DM_HANG_TON_KHO dM_HANG_TON_KHO = db.DM_HANG_TON_KHO.Find(id);
            if (dM_HANG_TON_KHO == null)
            {
                return NotFound();
            }

            db.DM_HANG_TON_KHO.Remove(dM_HANG_TON_KHO);
            db.SaveChanges();

            return Ok(dM_HANG_TON_KHO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DM_HANG_TON_KHOExists(string id)
        {
            return db.DM_HANG_TON_KHO.Count(e => e.MA_HANG_HT == id) > 0;
        }
    }
}
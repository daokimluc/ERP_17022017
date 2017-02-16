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

namespace ERP.Web.Areas.TruongAnHaNoi.Api.Kho
{
    public class Api_TonkhoTAHNController : ApiController
    {
        private HOPLONG_DATABASEEntities db = new HOPLONG_DATABASEEntities();

        // GET: api/Api_TonkhoTAHN
        public IQueryable<DM_HANG_TON_KHO> GetDM_HANG_TON_KHO()
        {
            return db.DM_HANG_TON_KHO;
        }

        // GET: api/Api_TonkhoTAHN/5
        [ResponseType(typeof(DM_HANG_TON_KHO))]
        public IHttpActionResult GetDM_HANG_TON_KHO(string id)
        {
            DM_HANG_TON_KHO dM_HANG_TON_KHO = db.DM_HANG_TON_KHO.Find(id);
            if (dM_HANG_TON_KHO == null)
            {
                return NotFound();
            }

            return Ok(dM_HANG_TON_KHO);
        }

        // PUT: api/Api_TonkhoTAHN/5
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

        // POST: api/Api_TonkhoTAHN
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

        // DELETE: api/Api_TonkhoTAHN/5
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
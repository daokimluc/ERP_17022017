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

namespace ERP.Web.Areas.TruongAnDaNang.Api.Kho
{
    public class Api_HanghoaDNController : ApiController
    {
        private HOPLONG_DATABASEEntities db = new HOPLONG_DATABASEEntities();

        // GET: api/Api_HanghoaDN
        public IQueryable<DM_HANG_HOA> GetDM_HANG_HOA()
        {
            return db.DM_HANG_HOA;
        }

        // GET: api/Api_HanghoaDN/5
        [ResponseType(typeof(DM_HANG_HOA))]
        public IHttpActionResult GetDM_HANG_HOA(string id)
        {
            DM_HANG_HOA dM_HANG_HOA = db.DM_HANG_HOA.Find(id);
            if (dM_HANG_HOA == null)
            {
                return NotFound();
            }

            return Ok(dM_HANG_HOA);
        }

        // PUT: api/Api_HanghoaDN/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDM_HANG_HOA(string id, DM_HANG_HOA dM_HANG_HOA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dM_HANG_HOA.MA_HANG_HT)
            {
                return BadRequest();
            }

            db.Entry(dM_HANG_HOA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DM_HANG_HOAExists(id))
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

        // POST: api/Api_HanghoaDN
        [ResponseType(typeof(DM_HANG_HOA))]
        public IHttpActionResult PostDM_HANG_HOA(DM_HANG_HOA dM_HANG_HOA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DM_HANG_HOA.Add(dM_HANG_HOA);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DM_HANG_HOAExists(dM_HANG_HOA.MA_HANG_HT))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = dM_HANG_HOA.MA_HANG_HT }, dM_HANG_HOA);
        }

        // DELETE: api/Api_HanghoaDN/5
        [ResponseType(typeof(DM_HANG_HOA))]
        public IHttpActionResult DeleteDM_HANG_HOA(string id)
        {
            DM_HANG_HOA dM_HANG_HOA = db.DM_HANG_HOA.Find(id);
            if (dM_HANG_HOA == null)
            {
                return NotFound();
            }

            db.DM_HANG_HOA.Remove(dM_HANG_HOA);
            db.SaveChanges();

            return Ok(dM_HANG_HOA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DM_HANG_HOAExists(string id)
        {
            return db.DM_HANG_HOA.Count(e => e.MA_HANG_HT == id) > 0;
        }
    }
}
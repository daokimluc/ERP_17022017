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

namespace ERP.Web.Areas.HopLong.Api.HeThong
{
    public class Api_ChitietnghiepvuController : ApiController
    {
        private HOPLONG_DATABASEEntities db = new HOPLONG_DATABASEEntities();

        // GET: api/Api_ChitietnghiepvuHL
        public IQueryable<CN_CHI_TIET_NGHIEP_VU> GetCN_CHI_TIET_NGHIEP_VU()
        {
            return db.CN_CHI_TIET_NGHIEP_VU;
        }

        // GET: api/Api_ChitietnghiepvuHL/5
        [ResponseType(typeof(CN_CHI_TIET_NGHIEP_VU))]
        public IHttpActionResult GetCN_CHI_TIET_NGHIEP_VU(int id)
        {
            CN_CHI_TIET_NGHIEP_VU cN_CHI_TIET_NGHIEP_VU = db.CN_CHI_TIET_NGHIEP_VU.Find(id);
            if (cN_CHI_TIET_NGHIEP_VU == null)
            {
                return NotFound();
            }

            return Ok(cN_CHI_TIET_NGHIEP_VU);
        }

        // PUT: api/Api_ChitietnghiepvuHL/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCN_CHI_TIET_NGHIEP_VU(int id, CN_CHI_TIET_NGHIEP_VU cN_CHI_TIET_NGHIEP_VU)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cN_CHI_TIET_NGHIEP_VU.ID)
            {
                return BadRequest();
            }

            db.Entry(cN_CHI_TIET_NGHIEP_VU).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CN_CHI_TIET_NGHIEP_VUExists(id))
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

        // POST: api/Api_ChitietnghiepvuHL
        [ResponseType(typeof(CN_CHI_TIET_NGHIEP_VU))]
        public IHttpActionResult PostCN_CHI_TIET_NGHIEP_VU(CN_CHI_TIET_NGHIEP_VU cN_CHI_TIET_NGHIEP_VU)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CN_CHI_TIET_NGHIEP_VU.Add(cN_CHI_TIET_NGHIEP_VU);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cN_CHI_TIET_NGHIEP_VU.ID }, cN_CHI_TIET_NGHIEP_VU);
        }

        // DELETE: api/Api_ChitietnghiepvuHL/5
        [ResponseType(typeof(CN_CHI_TIET_NGHIEP_VU))]
        public IHttpActionResult DeleteCN_CHI_TIET_NGHIEP_VU(int id)
        {
            CN_CHI_TIET_NGHIEP_VU cN_CHI_TIET_NGHIEP_VU = db.CN_CHI_TIET_NGHIEP_VU.Find(id);
            if (cN_CHI_TIET_NGHIEP_VU == null)
            {
                return NotFound();
            }

            db.CN_CHI_TIET_NGHIEP_VU.Remove(cN_CHI_TIET_NGHIEP_VU);
            db.SaveChanges();

            return Ok(cN_CHI_TIET_NGHIEP_VU);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CN_CHI_TIET_NGHIEP_VUExists(int id)
        {
            return db.CN_CHI_TIET_NGHIEP_VU.Count(e => e.ID == id) > 0;
        }
    }
}
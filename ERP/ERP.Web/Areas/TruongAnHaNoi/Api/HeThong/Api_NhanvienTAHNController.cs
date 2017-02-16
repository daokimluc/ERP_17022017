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

namespace ERP.Web.Areas.TruongAnHaNoi.Api.HeThong
{
    public class Api_NhanvienTAHNController : ApiController
    {
        private HOPLONG_DATABASEEntities db = new HOPLONG_DATABASEEntities();

        // GET: api/Api_NhanvienTAHN
        public IQueryable<CCTC_NHAN_VIEN> GetCCTC_NHAN_VIEN()
        {
            return db.CCTC_NHAN_VIEN;
        }

        // GET: api/Api_NhanvienTAHN/5
        [ResponseType(typeof(CCTC_NHAN_VIEN))]
        public IHttpActionResult GetCCTC_NHAN_VIEN(string id)
        {
            CCTC_NHAN_VIEN cCTC_NHAN_VIEN = db.CCTC_NHAN_VIEN.Find(id);
            if (cCTC_NHAN_VIEN == null)
            {
                return NotFound();
            }

            return Ok(cCTC_NHAN_VIEN);
        }

        // PUT: api/Api_NhanvienTAHN/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCCTC_NHAN_VIEN(string id, CCTC_NHAN_VIEN cCTC_NHAN_VIEN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cCTC_NHAN_VIEN.USERNAME)
            {
                return BadRequest();
            }

            db.Entry(cCTC_NHAN_VIEN).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CCTC_NHAN_VIENExists(id))
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

        // POST: api/Api_NhanvienTAHN
        [ResponseType(typeof(CCTC_NHAN_VIEN))]
        public IHttpActionResult PostCCTC_NHAN_VIEN(CCTC_NHAN_VIEN cCTC_NHAN_VIEN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CCTC_NHAN_VIEN.Add(cCTC_NHAN_VIEN);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CCTC_NHAN_VIENExists(cCTC_NHAN_VIEN.USERNAME))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cCTC_NHAN_VIEN.USERNAME }, cCTC_NHAN_VIEN);
        }

        // DELETE: api/Api_NhanvienTAHN/5
        [ResponseType(typeof(CCTC_NHAN_VIEN))]
        public IHttpActionResult DeleteCCTC_NHAN_VIEN(string id)
        {
            CCTC_NHAN_VIEN cCTC_NHAN_VIEN = db.CCTC_NHAN_VIEN.Find(id);
            if (cCTC_NHAN_VIEN == null)
            {
                return NotFound();
            }

            db.CCTC_NHAN_VIEN.Remove(cCTC_NHAN_VIEN);
            db.SaveChanges();

            return Ok(cCTC_NHAN_VIEN);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CCTC_NHAN_VIENExists(string id)
        {
            return db.CCTC_NHAN_VIEN.Count(e => e.USERNAME == id) > 0;
        }
    }
}
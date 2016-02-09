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
using PropertyManager.Api.Domain;
using PropertyManager.Api.Infrastructure;
using PropertyManager.Api.Models;
using AutoMapper;

namespace PropertyManager.Api.Controllers
{
    public class TenantsController : ApiController
    {
        private PropertyManagerDataContext db = new PropertyManagerDataContext();

        // GET: api/Tenants
        public IEnumerable<TenantModel> GetTenants()
        {
            return Mapper.Map<IEnumerable<TenantModel>>(db.Tenants);
        }

        // GET: api/Tenants/5
        [ResponseType(typeof(TenantModel))]
        public IHttpActionResult GetTenant(int id)
        {
            Tenant tenant = db.Tenants.Find(id);
            if (tenant == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<TenantModel>(tenant));
        }

        // GET: api/Tenants/5/Lease
        [Route("api/Tenants/{TenantId}/Leases")]
        public IEnumerable<LeaseModel> GetLeasesForTenant(int tenantId)
        {
            var leases = db.Leases.Where(l => l.TenantId == tenantId);

            return Mapper.Map<IEnumerable<LeaseModel>>(leases);
        }


        // GET: api/Tenants/5/WorkOrders
        [Route("api/Tenants/{TenantId}/WorkOrders")]
        public IEnumerable<WorkOrderModel> GetWorkOrdersForTenant(int tenantId)
        {
            var workOrders = db.WorkOrders.Where(wo => wo.TenantId == tenantId);

            return Mapper.Map<IEnumerable<WorkOrderModel>>(workOrders);
        }

        // PUT: api/Tenants/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTenant(int id, TenantModel tenant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tenant.TenantId)
            {
                return BadRequest();
            }

            var dbTenant = db.Tenants.Find(id);

            dbTenant.Update(tenant);

            db.Entry(dbTenant).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TenantExists(id))
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

        // POST: api/Tenants
        [ResponseType(typeof(TenantModel))]
        public IHttpActionResult PostTenant(TenantModel tenant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbTenant = new Tenant(tenant);

            db.Tenants.Add(dbTenant);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dbTenant.TenantId }, tenant);
        }

        // DELETE: api/Tenants/5
        [ResponseType(typeof(TenantModel))]
        public IHttpActionResult DeleteTenant(int id)
        {
            Tenant tenant = db.Tenants.Find(id);
            if (tenant == null)
            {
                return NotFound();
            }

            db.Tenants.Remove(tenant);
            db.SaveChanges();

            return Ok(Mapper.Map<TenantModel>(tenant));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TenantExists(int id)
        {
            return db.Tenants.Count(e => e.TenantId == id) > 0;
        }
    }
}
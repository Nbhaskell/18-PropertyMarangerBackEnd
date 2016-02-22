using PropertyManager.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyManager.Api.Domain
{
    public class Tenant
    {
        public Tenant(TenantModel model)
        {
            this.Address = new Address();
            this.Update(model);
        }

        public Tenant()
        {

        }

        public int TenantId { get; set; }
        public string UserId { get; set; }

        public int? AddressId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string EmailAddress { get; set; }

        public virtual Address Address { get; set; }

        public virtual PropertyManagerUser User { get; set; }

        public virtual ICollection<Lease> Leases { get; set; }
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }

      

        public void Update(TenantModel model)
        {
            FirstName = model.FirstName;
            LastName = model.LastName;
            Telephone = model.Telephone;
            EmailAddress = model.EmailAddress;
            Address.Update(model.Address);
        }
    }
}
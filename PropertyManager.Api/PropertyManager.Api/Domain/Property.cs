using PropertyManager.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyManager.Api.Domain
{
    public class Property
    {
        public Property(PropertyModel model)
        {
            this.Address = new Address(); 
            this.Update(model);
        }

        public Property()
        {

        }

        public int PropertyId { get; set; }
        public string UserId { get; set; }

        public int? AddressId { get; set; }
        public string PropertyType { get; set; }
        public int? SquareFeet { get; set; }
        public int? NumberOfBedrooms { get; set; }
        public float? NumberOfBathrooms { get; set; }
        public int? NumberOfVehicles { get; set; }
        
        public virtual Address Address { get; set; }

        public virtual PropertyManagerUser User { get; set; }

        public virtual ICollection<Lease> Leases { get; set; }
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
     

        public void Update(PropertyModel model)
        {
            PropertyType = model.PropertyType;
            SquareFeet = model.SquareFeet;
            NumberOfBedrooms = model.NumberOfBedrooms;
            NumberOfBathrooms = model.NumberOfBathrooms;
            NumberOfVehicles = model.NumberOfVehicles;
            
        }
    }
}
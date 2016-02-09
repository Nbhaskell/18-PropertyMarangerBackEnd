﻿using PropertyManager.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyManager.Api.Models
{
    public class PropertyModel
    {
        public int PropertyId { get; set; }
        public int? AddressId { get; set; }
        public string PropertyType { get; set; }
        public int? SquareFeet { get; set; }
        public int? NumberOfBedrooms { get; set; }
        public float? NumberOfBathrooms { get; set; }
        public int? NumberOfVehicles { get; set; }
    }
}
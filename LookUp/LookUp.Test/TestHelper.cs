using LookUp.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LookUp.Test
{
    public static class TestHelper
    {
        public static List<Listing> GetListingData()
        {
            var listing1 = new Listing { Name = "Listing 1", PricePerPassenger = 49.38, VehicleType=   new VehicleType {  Name = "Sedan", MaxPassengers = 2 } };
            var listing2 = new Listing { Name = "Listing 2", PricePerPassenger = 59.23, VehicleType = new VehicleType { Name = "SUV", MaxPassengers = 3 } };
            var listing3 = new Listing { Name = "Listing 3", PricePerPassenger = 64.2, VehicleType = new VehicleType { Name = "Sedan", MaxPassengers = 3 } };
            var listingData = new List<Listing> { listing1, listing2, listing3 };

            return listingData;
        }

    }
}

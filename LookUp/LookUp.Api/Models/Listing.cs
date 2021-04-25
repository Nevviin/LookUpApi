using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LookUp.Api.Models
{
    public class Listing
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("pricePerPassenger")]
        public double PricePerPassenger { get; set; }

        [JsonProperty("vehicleType")]
        public VehicleType VehicleType { get; set; }
    }

}

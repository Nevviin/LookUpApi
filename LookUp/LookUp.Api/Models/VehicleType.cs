using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LookUp.Api.Models
{
    public class VehicleType
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("maxPassengers")]
        public int MaxPassengers { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebApplication7.Models
{
    public class Street
    {
        public string name { get; set; }
        public Start start { get; set; }
        public End end { get; set; }

    }

    public class Start
    {
        [JsonProperty(PropertyName = "x")]
        public double x { get; set; }
        [JsonProperty(PropertyName = "y")]
        public double y { get; set; }
        
    }

    public class End
    {
        [JsonProperty(PropertyName = "x")]
        public double x { get; set; }
        [JsonProperty(PropertyName = "y")]
        public double y { get; set; }
    }
}

using Newtonsoft.Json;
using RailBox.JsonConverters;
using System;
using System.Collections.Generic;
using System.Text;

namespace RailBox.Models
{
    public class IsValidResponse
    {
        [JsonConverter(typeof(BoolStringConverter))]
        public bool Valid { get; set; }
    }
}

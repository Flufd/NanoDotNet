using Newtonsoft.Json;
using NanoDotNet.JsonConverters;
using System;
using System.Collections.Generic;
using System.Text;

namespace NanoDotNet
{
    public class IsValidResponse
    {
        [JsonConverter(typeof(BoolStringConverter))]
        public bool Valid { get; set; }
    }
}

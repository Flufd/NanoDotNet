using Newtonsoft.Json;
using RailBox.JsonConverters;
using System;
using System.Collections.Generic;
using System.Text;

namespace RailBox
{
    public class BlockInfo
    {
        public string BlockAccount { get; set; }

        [JsonConverter(typeof(RaiAmountJsonConverter))]
        public RaiAmount Amount { get; set; }

        [JsonConverter(typeof(RaiBlockJsonConverter))]
        public RaiBlock Contents { get; set; }
    }
}

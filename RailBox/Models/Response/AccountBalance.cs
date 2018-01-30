using Newtonsoft.Json;
using RailBox.JsonConverters;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace RailBox.Models
{
    public class AccountBalance
    {
        [JsonConverter(typeof(RaiAmountJsonConverter))]
        public RaiAmount Balance { get; set; }

        [JsonConverter(typeof(RaiAmountJsonConverter))]
        public RaiAmount Pending { get; set; }
    }
}

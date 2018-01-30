using Newtonsoft.Json;
using RailBox.JsonConverters;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace RailBox
{
    public class AccountHistoryItem
    {
        public string Hash { get; set; }
        public string Type { get; set; }
        public string Account { get; set; }

        [JsonConverter(typeof(RaiAmountJsonConverter))]
        public RaiAmount Amount { get; set; }
    }
}

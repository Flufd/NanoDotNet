using Newtonsoft.Json;
using RailBox.JsonConverters;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace RailBox.Models.Response
{
    public class AccountHistoryItem
    {
        public string Hash { get; set; }
        public string Receive { get; set; }
        public string Account { get; set; }

        [JsonConverter(typeof(RaiAmountJsonConverter))]
        public BigInteger Amount { get; set; }
    }
}

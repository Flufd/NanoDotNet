using Newtonsoft.Json;
using NanoDotNet.JsonConverters;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace NanoDotNet
{
    public class AccountHistoryItem
    {
        public string Hash { get; set; }
        public string Type { get; set; }
        public string Account { get; set; }

        [JsonConverter(typeof(NanoAmountJsonConverter))]
        public NanoAmount Amount { get; set; }
    }
}

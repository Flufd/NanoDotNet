using Newtonsoft.Json;
using NanoDotNet.JsonConverters;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace NanoDotNet
{
    public class AccountBalance
    {
        [JsonConverter(typeof(NanoAmountJsonConverter))]
        public NanoAmount Balance { get; set; }

        [JsonConverter(typeof(NanoAmountJsonConverter))]
        public NanoAmount Pending { get; set; }
    }
}

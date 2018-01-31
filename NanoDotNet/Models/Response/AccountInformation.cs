using Newtonsoft.Json;
using NanoDotNet.JsonConverters;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace NanoDotNet
{
    public class AccountInformationResponse
    {
        public string Frontier { get; set; }
        public string OpenBlock { get; set; }
        public string RepresentativeBlock { get; set; }

        [JsonConverter(typeof(NanoAmountJsonConverter))]
        public NanoAmount Balance { get; set; }
        public long ModifiedTimestamp { get; set; }
        public long BlockCount { get; set; }

        [JsonConverter(typeof(NanoAmountJsonConverter))]
        public NanoAmount? Pending { get; set; }
        public BigInteger? Weight { get; set; }
        public string Representative { get; set; }
    }
}

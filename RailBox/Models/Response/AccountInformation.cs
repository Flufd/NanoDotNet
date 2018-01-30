using Newtonsoft.Json;
using RailBox.JsonConverters;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace RailBox
{
    public class AccountInformationResponse
    {
        public string Frontier { get; set; }
        public string OpenBlock { get; set; }
        public string RepresentativeBlock { get; set; }

        [JsonConverter(typeof(RaiAmountJsonConverter))]
        public RaiAmount Balance { get; set; }
        public long ModifiedTimestamp { get; set; }
        public long BlockCount { get; set; }

        [JsonConverter(typeof(RaiAmountJsonConverter))]
        public RaiAmount? Pending { get; set; }
        public BigInteger? Weight { get; set; }
        public string Representative { get; set; }
    }
}

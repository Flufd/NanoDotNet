using Newtonsoft.Json;
using NanoDotNet.JsonConverters;
using System;
using System.Collections.Generic;
using System.Text;

namespace NanoDotNet
{
    public class BlockInfo
    {
        public string BlockAccount { get; set; }

        [JsonConverter(typeof(NanoAmountJsonConverter))]
        public NanoAmount Amount { get; set; }

        [JsonConverter(typeof(BlockJsonConverter))]
        public Block Contents { get; set; }
    }
}

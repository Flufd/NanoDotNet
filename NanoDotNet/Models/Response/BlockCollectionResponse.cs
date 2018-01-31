using Newtonsoft.Json;
using NanoDotNet.JsonConverters;
using System;
using System.Collections.Generic;
using System.Text;

namespace NanoDotNet
{
    public class BlockCollectionResponse
    {
        [JsonProperty(ItemConverterType = typeof(BlockJsonConverter))]
        public Dictionary<string, Block> Blocks { get; set; }
    }
}

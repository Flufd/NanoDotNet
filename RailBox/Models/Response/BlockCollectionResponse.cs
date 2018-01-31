using Newtonsoft.Json;
using RailBox.JsonConverters;
using System;
using System.Collections.Generic;
using System.Text;

namespace RailBox
{
    public class BlockCollectionResponse
    {
        [JsonProperty(ItemConverterType = typeof(RaiBlockJsonConverter))]
        public Dictionary<string, RaiBlock> Blocks { get; set; }
    }
}

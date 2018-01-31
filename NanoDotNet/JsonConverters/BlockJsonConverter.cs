using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NanoDotNet.JsonConverters
{
    public class BlockJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            //writer.WriteValue(((bool)value) ? "1" : "0");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var baseBlock = JsonConvert.DeserializeObject<Block>(reader.Value.ToString());

            switch (baseBlock.Type)
            {
                case "send":
                    return JsonConvert.DeserializeObject<SendBlock>(reader.Value.ToString());

                case "open":
                    return JsonConvert.DeserializeObject<SendBlock>(reader.Value.ToString());

                case "receive":
                    return JsonConvert.DeserializeObject<SendBlock>(reader.Value.ToString());

                case "change":
                    return JsonConvert.DeserializeObject<SendBlock>(reader.Value.ToString());

                default:
                    throw new InvalidOperationException("Unknown block type");
            }
            
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }
}


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RailBox.JsonConverters
{
    public class RaiBlockJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            //writer.WriteValue(((bool)value) ? "1" : "0");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var baseBlock = JsonConvert.DeserializeObject<RaiBlock>(reader.Value.ToString());

            switch (baseBlock.Type)
            {
                case "send":
                    return JsonConvert.DeserializeObject<SendRaiBlock>(reader.Value.ToString());

                case "open":
                    return JsonConvert.DeserializeObject<SendRaiBlock>(reader.Value.ToString());

                case "receive":
                    return JsonConvert.DeserializeObject<SendRaiBlock>(reader.Value.ToString());

                case "change":
                    return JsonConvert.DeserializeObject<SendRaiBlock>(reader.Value.ToString());

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


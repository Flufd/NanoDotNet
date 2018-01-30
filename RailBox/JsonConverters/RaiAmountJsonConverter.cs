using Newtonsoft.Json;
using RailBox.Models;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace RailBox.JsonConverters
{
    public class RaiAmountJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((RaiAmount)value).Raw);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return new RaiAmount(BigInteger.Parse(reader.Value.ToString()), RaiAmountBase.raw);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(RaiAmount);
        }
    }
}

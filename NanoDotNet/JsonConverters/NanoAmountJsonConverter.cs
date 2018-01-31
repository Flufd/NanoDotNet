using Newtonsoft.Json;
using System;
using System.Numerics;

namespace NanoDotNet.JsonConverters
{
    public class NanoAmountJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((NanoAmount)value).Raw);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return new NanoAmount(BigInteger.Parse(reader.Value.ToString()), AmountBase.raw);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(NanoAmount);
        }
    }
}

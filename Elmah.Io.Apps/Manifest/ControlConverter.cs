using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Elmah.Io.Apps.Manifest
{
    public class ControlConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            JObject jo = JObject.Load(reader);
            switch (jo["type"].Value<string>())
            {
                case "button":
                    return jo.ToObject<ButtonControl>(serializer);
            }

            return null;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IControl);
        }
    }
}
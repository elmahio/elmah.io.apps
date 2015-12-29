using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Elmah.Io.Apps.Manifest
{
    internal class ThenConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            switch (jo["type"].Value<string>())
            {
                case "http":
                    return jo.ToObject<ThenHttp>(serializer);
                case "email":
                    return jo.ToObject<ThenEmail>(serializer);
                case "ignore":
                    return jo.ToObject<ThenIgnore>(serializer);
                case "hide":
                    return jo.ToObject<ThenHide>(serializer);
            }

            return null;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (IThen);
        }
    }
}
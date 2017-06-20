using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Elmah.Io.Apps.Manifest
{
    public class AuthenticationConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var jo = JObject.Load(reader);
            switch (jo["type"].Value<string>())
            {
                case "basic":
                    return jo.ToObject<BasicAuthentication>(serializer);
                case "bearer":
                    return jo.ToObject<BearerTokenAuthentication>(serializer);
            }

            return null;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IAuthentication);
        }
    }
}
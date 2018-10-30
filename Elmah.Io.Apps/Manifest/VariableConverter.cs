using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Elmah.Io.Apps.Manifest
{
    internal class VariableConverter : JsonConverter
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
                case "text":
                    return jo.ToObject<TextVariable>(serializer);
                case "number":
                    return jo.ToObject<NumberVariable>(serializer);
                case "choice":
                    return jo.ToObject<ChoiceVariable>(serializer);
                case "bool":
                    return jo.ToObject<BoolVariable>(serializer);
                case "password":
                    return jo.ToObject<PasswordVariable>(serializer);
            }

            return null;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (IVariable);
        }
    }
}
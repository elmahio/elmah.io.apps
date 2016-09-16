using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Elmah.Io.Apps.Manifest
{
    public class AppManifest
    {
        public static App Parse(string json)
        {
            return JsonConvert.DeserializeObject<App>(json, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = new JsonConverter[] {new StringEnumConverter(), new ThenConverter(), new VariableConverter(), new AuthenticationConverter() }
            });
        }

        public static string Produce(App app)
        {
            return JsonConvert.SerializeObject(app,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    Converters = new JsonConverter[] {new StringEnumConverter(), new ThenConverter(), new VariableConverter(), new AuthenticationConverter() }
                });
        }
    }
}
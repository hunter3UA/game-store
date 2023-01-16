using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GameStore.Common.Extensions
{
    public static class ConfigurationManager
    {     
        public static T GetJsonSection<T>(this IConfiguration configuration, string section)
        {
            var jsonSection = configuration.GetSection(section).Get<Dictionary<string, object>>(); ;
            var serializedObject = JsonConvert.SerializeObject(jsonSection);
            var deserializedObject = JsonConvert.DeserializeObject<T>(serializedObject);

            return deserializedObject;
        }
    }
}

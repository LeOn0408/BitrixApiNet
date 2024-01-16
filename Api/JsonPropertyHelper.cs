using Newtonsoft.Json;
using System.Reflection;

namespace BitrixApiNet.Api
{
    public static class JsonPropertyHelper
    {
        public static string[] GetJsonPropertyNames(Type objectType)
        {
            PropertyInfo[] jsonProperties = objectType.GetProperties();              
            ICollection<string> names = new List<string>();
            foreach (var property in jsonProperties)
            {
                JsonPropertyAttribute? prop = property.GetCustomAttribute(typeof(JsonPropertyAttribute)) as JsonPropertyAttribute;
                string? name = prop?.PropertyName;
                if (!string.IsNullOrEmpty(name))
                {
                    names.Add(name);
                }
                else
                {
                    names.Add(property.Name);
                }
            }
            return names.ToArray();
        }
    }
}
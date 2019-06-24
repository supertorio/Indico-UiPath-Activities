using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Indico.Custom
{
    public class DictionaryToListConverter<T> : JsonConverter
    {

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            List<T> retVal = new List<T>();
            if (reader.TokenType == JsonToken.StartObject)
            {
                Dictionary<string, T> results = serializer.Deserialize<Dictionary<string, T>>(reader);
                foreach(KeyValuePair<string, T> entry in results)
                {
                    retVal.Add(entry.Value);
                }
            }
            return retVal;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("Unnecessary because CanWrite is false. The type will skip the converter.");
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.Equals(typeof(Dictionary<string,T>));
        }

        public override bool CanWrite
        {
            get { return false; }
        }
    }
}

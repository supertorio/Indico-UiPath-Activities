using Indico.Custom.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Indico.Custom.Tools
{
    class CollectionDataConverter : JsonConverter
    { 

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            List<CollectionData> dataList = (List<CollectionData>)value;
            List<object[]> convertedExamples = new List<object[]>();

            foreach (CollectionData dataPoint in dataList)
            {
                object[] example = { dataPoint.SampleText, dataPoint.Label };
                convertedExamples.Add(example);
            }

            serializer.Serialize(writer, convertedExamples);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.Equals(typeof(List<CollectionData>));
        }

        public override bool CanRead
        {
            get { return false; }
        }

    }
}

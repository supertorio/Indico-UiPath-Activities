using Newtonsoft.Json;
using System;

namespace Indico.Models.Finetune
{
    public class FinetuneCollection
    {
        [JsonProperty(PropertyName = "class_names")]
        public String[] ClassNames { get; set; }

        [JsonProperty(PropertyName = "dataset_id")]
        public int DatasetId { get; set; }

        [JsonProperty(PropertyName = "labelset_id")]
        public int LabelsetId { get; set; }

        [JsonProperty(PropertyName = "load_status")]
        public string LoadStatus { get; set; }

        [JsonProperty(PropertyName = "metrics")]
        public object Metrics { get; set; }

        [JsonProperty(PropertyName = "num_examples")]
        public int NumExamples { get; set; }

        [JsonProperty(PropertyName = "prediction_labelset_id")]
        public int PredictionLabelsetId { get; set; }

        [JsonProperty(PropertyName = "public")]
        public object Public { get; set; }

        [JsonProperty(PropertyName = "registered")]
        public object Registered { get; set; }

        [JsonProperty(PropertyName = "source_column_id")]
        public int SourceColumnId { get; set; }

        [JsonProperty(PropertyName = "split")]
        public float Split { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "task_type")]
        public string TaskType { get; set; }

        [JsonProperty(PropertyName = "warnings")]
        public object Warnings { get; set; }

        [JsonProperty(PropertyName = "worker")]
        public object Worker { get; set; }
    }
}

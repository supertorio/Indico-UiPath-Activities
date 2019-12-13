using Newtonsoft.Json;

namespace Indico.Models.PDFExtraction
{
    [JsonObject()]
    class ExtractPdfRequest : IndicoRequest
    {
        [JsonProperty(PropertyName = "text")]
        public bool TextFlag { get; set; }

        [JsonProperty(PropertyName = "images")]
        public bool ImagesFlag { get; set; }

        [JsonProperty(PropertyName = "metadata")]
        public bool MetadataFlag { get; set; }

        [JsonProperty(PropertyName = "tables")]
        public bool TablesFlag { get; set; }

        [JsonProperty(PropertyName = "raw_text")]
        public bool OCRDocument { get; set; }

        [JsonProperty(PropertyName = "single_column")]
        public bool SingleColumn { get; set; }

        [JsonProperty(PropertyName = "job")]
        public bool StartJob { get; set; }

        public ExtractPdfRequest(string apiKey, string data, bool ocrFlag, bool textFlag, bool metadataFlag, bool tablesFlag, bool singleColumnFlag) : base(apiKey, data)
        {
            OCRDocument = ocrFlag;
            TextFlag = textFlag;
            MetadataFlag = metadataFlag;
            TablesFlag = tablesFlag;
            SingleColumn = singleColumnFlag;

            StartJob = true;
            Version = 2;
        }
    }
}

using Newtonsoft.Json;
using System.Collections.Generic;

namespace Indico.Models.PDFExtraction
{
    [JsonObject()]
    public class ExtractedPDF
    {
        [JsonProperty(PropertyName = "pages")]
        public List<PDFPage> Pages;

        [JsonProperty(PropertyName = "metadata")]
        public Dictionary<string, object> Metadata;

        public ExtractedPDF()
        {
        }
    }
}

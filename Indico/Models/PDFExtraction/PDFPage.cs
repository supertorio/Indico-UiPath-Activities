using Newtonsoft.Json;
using System.Collections.Generic;

namespace Indico.Models.PDFExtraction
{
    [JsonObject()]
    public class PDFPage
    {
        [JsonProperty(PropertyName = "tables")]
        public List<PDFTable> Tables;

        [JsonProperty(PropertyName = "text")]
        public string Text;

        public PDFPage()
        {
        }
    }
}

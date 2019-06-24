using System.Collections.Generic;

namespace Indico.Custom.Models
{
    public class CustomCollection
    {
        public string domain { get; set; }
        public string input_type { get; set; }
        public Dictionary<string, string> metrics { get; set; }
        public string model_type { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public List<string> warnings { get; set; }
    }
}

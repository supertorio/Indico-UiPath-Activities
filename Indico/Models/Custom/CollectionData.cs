namespace Indico.Models.Custom
{
    public class CollectionData
    {
        public string SampleText { get; set; }
        public object Label { get; set; }

        public CollectionData(string text, string label)
        {
            SampleText = text;
            Label = label;
        }

        public CollectionData(string text, string[] labels)
        {
            SampleText = text;
            Label = labels;
        }

        public CollectionData(string text, AnnotationData[] labels)
        {
            SampleText = text;
            Label = labels;
        }
    }
}

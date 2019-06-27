using System.Activities.Presentation.Metadata;
using System.ComponentModel;
using System.ComponentModel.Design;
using Indico.Custom.Activities.Design.Properties;

namespace Indico.Custom.Activities.Design
{
    public class DesignerMetadata : IRegisterMetadata
    {
        public void Register()
        {
            var builder = new AttributeTableBuilder();
            builder.ValidateTable();

            var categoryAttribute =  new CategoryAttribute($"{Resources.Category}");


            builder.AddCustomAttributes(typeof(IndicoCustomScope), categoryAttribute);
            builder.AddCustomAttributes(typeof(IndicoCustomScope), new DesignerAttribute(typeof(ParentScopeDesigner)));
            builder.AddCustomAttributes(typeof(IndicoCustomScope), new HelpKeywordAttribute("https://indico.io/blog/docs/indico-api/custom-collections/"));

            builder.AddCustomAttributes(typeof(ListCollections), categoryAttribute);
            builder.AddCustomAttributes(typeof(ListCollections), new DesignerAttribute(typeof(ListCollectionsDesigner)));
            builder.AddCustomAttributes(typeof(ListCollections), new HelpKeywordAttribute("https://indico.io/blog/docs/indico-api/custom-collections/"));

            builder.AddCustomAttributes(typeof(CollectionInfo), categoryAttribute);
            builder.AddCustomAttributes(typeof(CollectionInfo), new DesignerAttribute(typeof(CollectionInfoDesigner)));
            builder.AddCustomAttributes(typeof(CollectionInfo), new HelpKeywordAttribute("https://indico.io/blog/docs/indico-api/custom-collections/checking-status/"));

            builder.AddCustomAttributes(typeof(AddData), categoryAttribute);
            builder.AddCustomAttributes(typeof(AddData), new DesignerAttribute(typeof(AddDataDesigner)));
            builder.AddCustomAttributes(typeof(AddData), new HelpKeywordAttribute("https://indico.io/blog/docs/indico-api/custom-collections/adding-data/"));

            builder.AddCustomAttributes(typeof(TrainCollection), categoryAttribute);
            builder.AddCustomAttributes(typeof(TrainCollection), new DesignerAttribute(typeof(TrainCollectionDesigner)));
            builder.AddCustomAttributes(typeof(TrainCollection), new HelpKeywordAttribute("https://indico.io/blog/docs/indico-api/custom-collections/training/"));

            builder.AddCustomAttributes(typeof(GetPredictions), categoryAttribute);
            builder.AddCustomAttributes(typeof(GetPredictions), new DesignerAttribute(typeof(GetPredictionsDesigner)));
            builder.AddCustomAttributes(typeof(GetPredictions), new HelpKeywordAttribute("https://indico.io/blog/docs/indico-api/custom-collections/making-predictions/"));

            builder.AddCustomAttributes(typeof(GetAnnotations), categoryAttribute);
            builder.AddCustomAttributes(typeof(GetAnnotations), new DesignerAttribute(typeof(GetAnnotationsDesigner)));
            builder.AddCustomAttributes(typeof(GetAnnotations), new HelpKeywordAttribute("https://indico.io/blog/docs/indico-api/custom-collections/making-predictions/"));

            builder.AddCustomAttributes(typeof(GetExplanations), categoryAttribute);
            builder.AddCustomAttributes(typeof(GetExplanations), new DesignerAttribute(typeof(GetExplanationsDesigner)));
            builder.AddCustomAttributes(typeof(GetExplanations), new HelpKeywordAttribute("https://indico.io/blog/docs/indico-api/custom-collections/explaining-predictions/"));

            MetadataStore.AddAttributeTable(builder.CreateTable());
        }
    }
}

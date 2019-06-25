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

            builder.AddCustomAttributes(typeof(AddData), categoryAttribute);
            builder.AddCustomAttributes(typeof(AddData), new DesignerAttribute(typeof(AddDataDesigner)));
            builder.AddCustomAttributes(typeof(AddData), new HelpKeywordAttribute("https://indico.io/blog/docs/indico-api/custom-collections/adding-data/"));


            MetadataStore.AddAttributeTable(builder.CreateTable());
        }
    }
}

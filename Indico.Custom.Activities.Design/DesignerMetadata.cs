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
            builder.AddCustomAttributes(typeof(IndicoCustomScope), new HelpKeywordAttribute("https://go.uipath.com"));

            builder.AddCustomAttributes(typeof(ChildActivity), categoryAttribute);
            builder.AddCustomAttributes(typeof(ChildActivity), new DesignerAttribute(typeof(ChildActivityDesigner)));
            builder.AddCustomAttributes(typeof(ChildActivity), new HelpKeywordAttribute("https://go.uipath.com"));

            MetadataStore.AddAttributeTable(builder.CreateTable());
        }
    }
}

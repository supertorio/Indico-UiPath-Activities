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

            var baseCategoryAttribute =  new CategoryAttribute($"{Resources.BaseCategory}");
            var sharingCategoryAttribute = new CategoryAttribute($"{Resources.SharingCategory}");


            builder.AddCustomAttributes(typeof(IndicoCustomScope), baseCategoryAttribute);
            builder.AddCustomAttributes(typeof(IndicoCustomScope), new DesignerAttribute(typeof(ParentScopeDesigner)));
            builder.AddCustomAttributes(typeof(IndicoCustomScope), new HelpKeywordAttribute("https://indico.io/blog/docs/indico-api/custom-collections/"));

            builder.AddCustomAttributes(typeof(ListCollections), baseCategoryAttribute);
            builder.AddCustomAttributes(typeof(ListCollections), new DesignerAttribute(typeof(ListCollectionsDesigner)));
            builder.AddCustomAttributes(typeof(ListCollections), new HelpKeywordAttribute("https://indico.io/blog/docs/indico-api/custom-collections/"));

            builder.AddCustomAttributes(typeof(RemoveCollection), baseCategoryAttribute);
            builder.AddCustomAttributes(typeof(RemoveCollection), new DesignerAttribute(typeof(RemoveCollectionDesigner)));
            builder.AddCustomAttributes(typeof(RemoveCollection), new HelpKeywordAttribute("https://indico.io/blog/docs/indico-api/custom-collections/deleting-collections/"));

            builder.AddCustomAttributes(typeof(CollectionInfo), baseCategoryAttribute);
            builder.AddCustomAttributes(typeof(CollectionInfo), new DesignerAttribute(typeof(CollectionInfoDesigner)));
            builder.AddCustomAttributes(typeof(CollectionInfo), new HelpKeywordAttribute("https://indico.io/blog/docs/indico-api/custom-collections/checking-status/"));

            builder.AddCustomAttributes(typeof(AddData), baseCategoryAttribute);
            builder.AddCustomAttributes(typeof(AddData), new DesignerAttribute(typeof(AddDataDesigner)));
            builder.AddCustomAttributes(typeof(AddData), new HelpKeywordAttribute("https://indico.io/blog/docs/indico-api/custom-collections/adding-data/"));

            builder.AddCustomAttributes(typeof(RemoveData), baseCategoryAttribute);
            builder.AddCustomAttributes(typeof(RemoveData), new DesignerAttribute(typeof(RemoveDataDesigner)));
            builder.AddCustomAttributes(typeof(RemoveData), new HelpKeywordAttribute("https://indico.io/blog/docs/indico-api/custom-collections/removing-data/"));

            builder.AddCustomAttributes(typeof(TrainCollection), baseCategoryAttribute);
            builder.AddCustomAttributes(typeof(TrainCollection), new DesignerAttribute(typeof(TrainCollectionDesigner)));
            builder.AddCustomAttributes(typeof(TrainCollection), new HelpKeywordAttribute("https://indico.io/blog/docs/indico-api/custom-collections/training/"));

            builder.AddCustomAttributes(typeof(GetPredictions), baseCategoryAttribute);
            builder.AddCustomAttributes(typeof(GetPredictions), new DesignerAttribute(typeof(GetPredictionsDesigner)));
            builder.AddCustomAttributes(typeof(GetPredictions), new HelpKeywordAttribute("https://indico.io/blog/docs/indico-api/custom-collections/making-predictions/"));

            builder.AddCustomAttributes(typeof(GetAnnotations), baseCategoryAttribute);
            builder.AddCustomAttributes(typeof(GetAnnotations), new DesignerAttribute(typeof(GetAnnotationsDesigner)));
            builder.AddCustomAttributes(typeof(GetAnnotations), new HelpKeywordAttribute("https://indico.io/blog/docs/indico-api/custom-collections/making-predictions/"));

            builder.AddCustomAttributes(typeof(GetExplanations), baseCategoryAttribute);
            builder.AddCustomAttributes(typeof(GetExplanations), new DesignerAttribute(typeof(GetExplanationsDesigner)));
            builder.AddCustomAttributes(typeof(GetExplanations), new HelpKeywordAttribute("https://indico.io/blog/docs/indico-api/custom-collections/explaining-predictions/"));

            builder.AddCustomAttributes(typeof(RegisterCollection), sharingCategoryAttribute);
            builder.AddCustomAttributes(typeof(RegisterCollection), new DesignerAttribute(typeof(RegisterCollectionDesigner)));
            builder.AddCustomAttributes(typeof(RegisterCollection), new HelpKeywordAttribute("https://indico.io/blog/docs/indico-api/custom-collections/publishing-collections//"));

            builder.AddCustomAttributes(typeof(DeRegisterCollection), sharingCategoryAttribute);
            builder.AddCustomAttributes(typeof(DeRegisterCollection), new DesignerAttribute(typeof(DeRegisterCollectionDesigner)));
            builder.AddCustomAttributes(typeof(DeRegisterCollection), new HelpKeywordAttribute("https://indico.io/blog/docs/indico-api/custom-collections/publishing-collections/"));

            builder.AddCustomAttributes(typeof(AuthorizeUser), sharingCategoryAttribute);
            builder.AddCustomAttributes(typeof(AuthorizeUser), new DesignerAttribute(typeof(AuthorizeUserDesigner)));
            builder.AddCustomAttributes(typeof(AuthorizeUser), new HelpKeywordAttribute("https://indico.io/blog/docs/indico-api/custom-collections/sharing/"));

            builder.AddCustomAttributes(typeof(DeAuthorizeUser), sharingCategoryAttribute);
            builder.AddCustomAttributes(typeof(DeAuthorizeUser), new DesignerAttribute(typeof(DeAuthorizeUserDesigner)));
            builder.AddCustomAttributes(typeof(DeAuthorizeUser), new HelpKeywordAttribute("https://indico.io/blog/docs/indico-api/custom-collections/sharing/"));

            MetadataStore.AddAttributeTable(builder.CreateTable());
        }
    }
}

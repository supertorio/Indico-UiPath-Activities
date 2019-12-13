using System.Activities.Presentation.Metadata;
using System.ComponentModel;
using System.ComponentModel.Design;
using Indico.Activities.Design.Properties;

namespace Indico.Activities.Design
{
    public class DesignerMetadata : IRegisterMetadata
    {
        public void Register()
        {
            var builder = new AttributeTableBuilder();
            builder.ValidateTable();

            var baseCategoryAttribute =  new CategoryAttribute($"{Resources.BaseCategory}");
            var customCategoryAttribute = new CategoryAttribute($"{Resources.CustomCategory}");
            var finetuneCategoryAttribute = new CategoryAttribute($"{Resources.FinetuneCategory}");
            var pdfExtractionCategoryAttribute = new CategoryAttribute($"{Resources.PDFExtractionCategory}");


            builder.AddCustomAttributes(typeof(IndicoCustomScope), baseCategoryAttribute);
            builder.AddCustomAttributes(typeof(IndicoCustomScope), new DesignerAttribute(typeof(ParentScopeDesigner)));
            builder.AddCustomAttributes(typeof(IndicoCustomScope), new HelpKeywordAttribute("https://indico.io/blog/docs/indico-api/custom-collections/"));

            builder.AddCustomAttributes(typeof(ListCollections), customCategoryAttribute);
            builder.AddCustomAttributes(typeof(ListCollections), new DesignerAttribute(typeof(ListCollectionsDesigner)));
            builder.AddCustomAttributes(typeof(ListCollections), new HelpKeywordAttribute("https://indico.io/blog/docs/indico-api/custom-collections/"));

            builder.AddCustomAttributes(typeof(RemoveCollection), customCategoryAttribute);
            builder.AddCustomAttributes(typeof(RemoveCollection), new DesignerAttribute(typeof(RemoveCollectionDesigner)));
            builder.AddCustomAttributes(typeof(RemoveCollection), new HelpKeywordAttribute("https://indico.io/blog/docs/indico-api/custom-collections/deleting-collections/"));

            builder.AddCustomAttributes(typeof(CollectionInfo), customCategoryAttribute);
            builder.AddCustomAttributes(typeof(CollectionInfo), new DesignerAttribute(typeof(CollectionInfoDesigner)));
            builder.AddCustomAttributes(typeof(CollectionInfo), new HelpKeywordAttribute("https://indico.io/blog/docs/indico-api/custom-collections/checking-status/"));

            builder.AddCustomAttributes(typeof(AddData), customCategoryAttribute);
            builder.AddCustomAttributes(typeof(AddData), new DesignerAttribute(typeof(AddDataDesigner)));
            builder.AddCustomAttributes(typeof(AddData), new HelpKeywordAttribute("https://indico.io/blog/docs/indico-api/custom-collections/adding-data/"));

            builder.AddCustomAttributes(typeof(RemoveData), customCategoryAttribute);
            builder.AddCustomAttributes(typeof(RemoveData), new DesignerAttribute(typeof(RemoveDataDesigner)));
            builder.AddCustomAttributes(typeof(RemoveData), new HelpKeywordAttribute("https://indico.io/blog/docs/indico-api/custom-collections/removing-data/"));

            builder.AddCustomAttributes(typeof(TrainCollection), customCategoryAttribute);
            builder.AddCustomAttributes(typeof(TrainCollection), new DesignerAttribute(typeof(TrainCollectionDesigner)));
            builder.AddCustomAttributes(typeof(TrainCollection), new HelpKeywordAttribute("https://indico.io/blog/docs/indico-api/custom-collections/training/"));

            builder.AddCustomAttributes(typeof(GetPredictions), customCategoryAttribute);
            builder.AddCustomAttributes(typeof(GetPredictions), new DesignerAttribute(typeof(GetPredictionsDesigner)));
            builder.AddCustomAttributes(typeof(GetPredictions), new HelpKeywordAttribute("https://indico.io/blog/docs/indico-api/custom-collections/making-predictions/"));

            builder.AddCustomAttributes(typeof(GetAnnotations), customCategoryAttribute);
            builder.AddCustomAttributes(typeof(GetAnnotations), new DesignerAttribute(typeof(GetAnnotationsDesigner)));
            builder.AddCustomAttributes(typeof(GetAnnotations), new HelpKeywordAttribute("https://indico.io/blog/docs/indico-api/custom-collections/making-predictions/"));

            builder.AddCustomAttributes(typeof(GetExplanations), customCategoryAttribute);
            builder.AddCustomAttributes(typeof(GetExplanations), new DesignerAttribute(typeof(GetExplanationsDesigner)));
            builder.AddCustomAttributes(typeof(GetExplanations), new HelpKeywordAttribute("https://indico.io/blog/docs/indico-api/custom-collections/explaining-predictions/"));

            builder.AddCustomAttributes(typeof(RegisterCollection), customCategoryAttribute);
            builder.AddCustomAttributes(typeof(RegisterCollection), new DesignerAttribute(typeof(RegisterCollectionDesigner)));
            builder.AddCustomAttributes(typeof(RegisterCollection), new HelpKeywordAttribute("https://indico.io/blog/docs/indico-api/custom-collections/publishing-collections//"));

            builder.AddCustomAttributes(typeof(DeRegisterCollection), customCategoryAttribute);
            builder.AddCustomAttributes(typeof(DeRegisterCollection), new DesignerAttribute(typeof(DeRegisterCollectionDesigner)));
            builder.AddCustomAttributes(typeof(DeRegisterCollection), new HelpKeywordAttribute("https://indico.io/blog/docs/indico-api/custom-collections/publishing-collections/"));

            builder.AddCustomAttributes(typeof(AuthorizeUser), customCategoryAttribute);
            builder.AddCustomAttributes(typeof(AuthorizeUser), new DesignerAttribute(typeof(AuthorizeUserDesigner)));
            builder.AddCustomAttributes(typeof(AuthorizeUser), new HelpKeywordAttribute("https://indico.io/blog/docs/indico-api/custom-collections/sharing/"));

            builder.AddCustomAttributes(typeof(DeAuthorizeUser), customCategoryAttribute);
            builder.AddCustomAttributes(typeof(DeAuthorizeUser), new DesignerAttribute(typeof(DeAuthorizeUserDesigner)));
            builder.AddCustomAttributes(typeof(DeAuthorizeUser), new HelpKeywordAttribute("https://indico.io/blog/docs/indico-api/custom-collections/sharing/"));

            builder.AddCustomAttributes(typeof(FinetuneCollectionInfo), finetuneCategoryAttribute);
            builder.AddCustomAttributes(typeof(FinetuneCollectionInfo), new DesignerAttribute(typeof(FinetuneCollectionInfoDesigner)));

            builder.AddCustomAttributes(typeof(LoadFinetuneCollection), finetuneCategoryAttribute);
            builder.AddCustomAttributes(typeof(LoadFinetuneCollection), new DesignerAttribute(typeof(LoadFinetuneCollectionDesigner)));

            builder.AddCustomAttributes(typeof(GetFinetunePredictions), finetuneCategoryAttribute);
            builder.AddCustomAttributes(typeof(GetFinetunePredictions), new DesignerAttribute(typeof(GetFinetunePredictionsDesigner)));

            builder.AddCustomAttributes(typeof(PdfExtraction), pdfExtractionCategoryAttribute);
            builder.AddCustomAttributes(typeof(PdfExtraction), new DesignerAttribute(typeof(PdfExtractionDesigner)));

            MetadataStore.AddAttributeTable(builder.CreateTable());
        }
    }
}

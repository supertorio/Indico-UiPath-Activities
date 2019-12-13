using Indico.Activities.Properties;
using Indico.Enums;
using Indico.Models.Custom;
using System.Activities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Indico.Activities
{
    [LocalizedDisplayName(nameof(Resources.AddDataDisplayName))]
    [LocalizedDescription(nameof(Resources.AddDataDescription))]
    public class AddData : AsyncTaskCodeActivity<bool>
    {
        [LocalizedCategory(nameof(Resources.CollectionInfoCategoryName))]
        [LocalizedDisplayName(nameof(Resources.ModelNameDisplayName))]
        [LocalizedDescription(nameof(Resources.ModelNameDescription))]
        public InArgument<string> CollectionName { get; set; }

        [LocalizedCategory(nameof(Resources.CollectionInfoCategoryName))]
        [LocalizedDisplayName(nameof(Resources.ModelDomainDisplayName))]
        [LocalizedDescription(nameof(Resources.ModelDomainDescription))]
        public ModelDomain CollectionDomain { get; set; }

        [LocalizedDisplayName(nameof(Resources.LabeledDataArgumentDisplayName))]
        [LocalizedDescription(nameof(Resources.LabeledDataArgumentDescription))]
        [LocalizedCategory(nameof(Resources.Input))]
        [RequiredArgument]
        public InArgument<List<CollectionData>> Data { get; set; }

        [LocalizedDisplayName(nameof(Resources.LabeledDataResultsDisplayName))]
        [LocalizedDescription(nameof(Resources.LabeledDataResultsDescription))]
        [LocalizedCategory(nameof(Resources.Output))]
        public OutArgument<bool> Result { get; set; }

        public AddData()
        {
            CollectionDomain = ModelDomain.Standard;
        }

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);
            if (Data == null) metadata.AddValidationError(string.Format(Resources.MetadataValidationError, nameof(Data)));
        }

        protected override Task<bool> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken, Application client)
        {
            var collectionName = CollectionName.Get(context);
            var labeledData = Data.Get(context);
            var modelDomain = CollectionDomain;
            return client.AddCustomCollectionData(collectionName, labeledData, modelDomain);
        }

        protected override void OutputResult(AsyncCodeActivityContext context, bool response)
        {
            Result.Set(context, response);
        }
    }
}

using Indico.Custom.Activities.Properties;
using Indico.Custom.Models;
using System.Activities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Indico.Custom.Activities
{
    [LocalizedDisplayName(nameof(Resources.AddDataDisplayName))]
    [LocalizedDescription(nameof(Resources.AddDataDescription))]
    public class AddData : AsyncTaskCodeActivity<AddDataResponse>
    {

        [LocalizedDisplayName(nameof(Resources.LabeledDataArgumentDisplayName))]
        [LocalizedDescription(nameof(Resources.LabeledDataArgumentDescription))]
        [LocalizedCategory(nameof(Resources.Input))]
        [RequiredArgument]
        public InArgument<List<CollectionData>> Data { get; set; }

        [LocalizedDisplayName(nameof(Resources.LabeledDataResultsDisplayName))]
        [LocalizedDescription(nameof(Resources.LabeledDataResultsDescription))]
        [LocalizedCategory(nameof(Resources.Output))]
        public OutArgument<bool> Result { get; set; }

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);
            if (Data == null) metadata.AddValidationError(string.Format(Resources.MetadataValidationError, nameof(Data)));
        }

        protected override Task<AddDataResponse> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken, Application client)
        {
            var labeledData = Data.Get(context);
            return client.AddCollectionData(labeledData);
        }

        protected override void OutputResult(AsyncCodeActivityContext context, AddDataResponse response)
        {
            Result.Set(context, response.Results);
        }
    }
}

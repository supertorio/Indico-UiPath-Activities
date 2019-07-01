using Indico.Custom.Activities.Properties;
using Indico.Custom.Models;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;

namespace Indico.Custom.Activities
{
    [LocalizedDisplayName(nameof(Resources.TrainCollectionDisplayName))]
    [LocalizedDescription(nameof(Resources.TrainCollectionDescription))]
    public class TrainCollection : AsyncTaskCodeActivity<CollectionResponse>
    {

        [LocalizedDisplayName(nameof(Resources.CollectionInfoResultsDisplayName))]
        [LocalizedDescription(nameof(Resources.CollectionInfoResultsDescription))]
        [LocalizedCategory(nameof(Resources.LabeledDataResultsDisplayName))]
        public OutArgument<CustomCollection> Result { get; set; }

        protected override Task<CollectionResponse> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken, Application client)
        {
            return client.TrainCollection();
        }

        protected override void OutputResult(AsyncCodeActivityContext context, CollectionResponse response)
        {
            Result.Set(context, response.Results);
        }
    }
}

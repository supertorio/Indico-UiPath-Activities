using Indico.Activities.Properties;
using Indico.Models.Custom;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;

namespace Indico.Activities
{
    [LocalizedDisplayName(nameof(Resources.TrainCollectionDisplayName))]
    [LocalizedDescription(nameof(Resources.TrainCollectionDescription))]
    public class TrainCollection : AsyncTaskCodeActivity<CustomCollection>
    {
        [LocalizedCategory(nameof(Resources.CollectionInfoCategoryName))]
        [LocalizedDisplayName(nameof(Resources.ModelNameDisplayName))]
        [LocalizedDescription(nameof(Resources.ModelNameDescription))]
        public InArgument<string> CollectionName { get; set; }

        [LocalizedDisplayName(nameof(Resources.CollectionInfoResultsDisplayName))]
        [LocalizedDescription(nameof(Resources.CollectionInfoResultsDescription))]
        [LocalizedCategory(nameof(Resources.LabeledDataResultsDisplayName))]
        public OutArgument<CustomCollection> Result { get; set; }

        protected override Task<CustomCollection> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken, Application client)
        {
            var collectionName = CollectionName.Get(context);
            return client.TrainCustomCollection(collectionName);
        }

        protected override void OutputResult(AsyncCodeActivityContext context, CustomCollection response)
        {
            Result.Set(context, response);
        }
    }
}

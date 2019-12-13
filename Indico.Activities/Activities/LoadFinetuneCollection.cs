using Indico.Activities.Properties;
using Indico.Models.Finetune;
using System.Activities;
using System.Threading;

namespace Indico.Activities
{
    [LocalizedDisplayName(nameof(Resources.LoadFinetuneCollectionDisplayName))]
    [LocalizedDescription(nameof(Resources.LoadFinetuneCollectionDescription))]
    public class LoadFinetuneCollection : AsyncTaskCodeActivity<FinetuneCollection>
    {
        [LocalizedCategory(nameof(Resources.CollectionInfoCategoryName))]
        [LocalizedDisplayName(nameof(Resources.FinetuneModelNameDisplayName))]
        [LocalizedDescription(nameof(Resources.FinetuneModelNameDescription))]
        public InArgument<string> CollectionName { get; set; }

        [LocalizedDisplayName(nameof(Resources.CollectionInfoResultsDisplayName))]
        [LocalizedDescription(nameof(Resources.CollectionInfoResultsDescription))]
        [LocalizedCategory(nameof(Resources.LabeledDataResultsDisplayName))]
        public OutArgument<FinetuneCollection> Result { get; set; }

        protected override System.Threading.Tasks.Task<FinetuneCollection> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken, Application client)
        {
            var collectionName = CollectionName.Get(context);
            return client.LoadFinetuneCollection(collectionName);
        }

        protected override void OutputResult(AsyncCodeActivityContext context, FinetuneCollection response)
        {
            Result.Set(context, response);
        }
    }
}

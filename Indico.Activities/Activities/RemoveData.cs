using Indico.Activities.Properties;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;

namespace Indico.Activities
{
    [LocalizedDisplayName(nameof(Resources.RemoveDataDisplayName))]
    [LocalizedDescription(nameof(Resources.RemoveDataDescription))]
    public class RemoveData : AsyncTaskCodeActivity<bool>
    {
        [LocalizedCategory(nameof(Resources.CollectionInfoCategoryName))]
        [LocalizedDisplayName(nameof(Resources.ModelNameDisplayName))]
        [LocalizedDescription(nameof(Resources.ModelNameDescription))]
        public InArgument<string> CollectionName { get; set; }

        [LocalizedDisplayName(nameof(Resources.RemoveExamplesDisplayName))]
        [LocalizedDescription(nameof(Resources.RemoveExamplesDescription))]
        [LocalizedCategory(nameof(Resources.Input))]
        public InArgument<string[]> Examples { get; set; }

        [LocalizedDisplayName(nameof(Resources.RemoveSuccessDisplayName))]
        [LocalizedDescription(nameof(Resources.RemoveSuccessDescription))]
        [LocalizedCategory(nameof(Resources.Output))]
        public OutArgument<bool> Result { get; set; }

        protected override Task<bool> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken, Application client)
        {
            var collectionName = CollectionName.Get(context);
            var examples = Examples.Get(context);
            return client.RemoveCustomCollectionData(collectionName, examples);
        }

        protected override void OutputResult(AsyncCodeActivityContext context, bool response)
        {
            Result.Set(context, response);
        }
    }
}

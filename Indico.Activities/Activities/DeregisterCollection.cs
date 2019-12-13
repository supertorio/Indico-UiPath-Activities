using Indico.Activities.Properties;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;

namespace Indico.Activities
{
    [LocalizedDisplayName(nameof(Resources.DeregisterCollectionDisplayName))]
    [LocalizedDescription(nameof(Resources.DeregisterCollectionDescription))]
    public class DeRegisterCollection : AsyncTaskCodeActivity<bool>
    {
        [LocalizedCategory(nameof(Resources.CollectionInfoCategoryName))]
        [LocalizedDisplayName(nameof(Resources.ModelNameDisplayName))]
        [LocalizedDescription(nameof(Resources.ModelNameDescription))]
        public InArgument<string> CollectionName { get; set; }

        [LocalizedDisplayName(nameof(Resources.DeregisterSuccessDisplayName))]
        [LocalizedDescription(nameof(Resources.DeregisterSuccessDescription))]
        [LocalizedCategory(nameof(Resources.Output))]
        public OutArgument<bool> Result { get; set; }

        protected override Task<bool> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken, Application client)
        {
            var collectionName = CollectionName.Get(context);
            return client.DeregisterCustomCollection(collectionName);
        }

        protected override void OutputResult(AsyncCodeActivityContext context, bool response)
        {
            Result.Set(context, response);
        }
    }
}

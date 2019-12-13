using System.Activities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Indico.Activities.Properties;
using Indico.Models.Custom;

namespace Indico.Activities
{
    [LocalizedDisplayName(nameof(Resources.ListCollectionsDisplayName))]
    [LocalizedDescription(nameof(Resources.ListCollectionsDescription))]
    public class ListCollections : AsyncTaskCodeActivity<List<CustomCollection>>
    {
        [LocalizedDisplayName(nameof(Resources.CollectionListResultsDisplayName))]
        [LocalizedDescription(nameof(Resources.CollectionListResultsDescription))]
        [LocalizedCategory(nameof(Resources.Output))]
        public OutArgument<List<CustomCollection>> Result { get; set; }

        protected override Task<List<CustomCollection>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken, Application client)
        {
            return client.GetCustomCollections();
        }

        protected override void OutputResult(AsyncCodeActivityContext context, List<CustomCollection> response)
        {
            Result.Set(context, response);
        }
    }
}

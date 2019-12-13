using Indico.Activities.Properties;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;

namespace Indico.Activities
{
    [LocalizedDisplayName(nameof(Resources.RegisterCollectionDisplayName))]
    [LocalizedDescription(nameof(Resources.RegisterCollectionDescription))]
    public class RegisterCollection : AsyncTaskCodeActivity<bool>
    {
        [LocalizedCategory(nameof(Resources.CollectionInfoCategoryName))]
        [LocalizedDisplayName(nameof(Resources.ModelNameDisplayName))]
        [LocalizedDescription(nameof(Resources.ModelNameDescription))]
        public InArgument<string> CollectionName { get; set; }

        [LocalizedDisplayName(nameof(Resources.RegisterCollectionMakePublicDisplayName))]
        [LocalizedDescription(nameof(Resources.RegisterCollectionMakePublicDescription))]
        [LocalizedCategory(nameof(Resources.Input))]
        public InArgument<bool> IsPublic { get; set; }

        [LocalizedDisplayName(nameof(Resources.RegisterSuccessDisplayName))]
        [LocalizedDescription(nameof(Resources.RegisterSuccessDescription))]
        [LocalizedCategory(nameof(Resources.Output))]
        public OutArgument<bool> Result { get; set; }

        public RegisterCollection()
        {
            IsPublic = false;
        }

        protected override Task<bool> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken, Application client)
        {
            var collectionName = CollectionName.Get(context);
            var isPublic = IsPublic.Get(context);
            return client.RegisterCustomCollection(collectionName, isPublic);
        }

        protected override void OutputResult(AsyncCodeActivityContext context, bool response)
        {
            Result.Set(context, response);
        }
    }
}

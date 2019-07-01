using Indico.Custom.Activities.Properties;
using Indico.Custom.Models;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;

namespace Indico.Custom.Activities
{
    [LocalizedDisplayName(nameof(Resources.RegisterCollectionDisplayName))]
    [LocalizedDescription(nameof(Resources.RegisterCollectionDescription))]
    public class RegisterCollection : AsyncTaskCodeActivity<SimpleResponse>
    {
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

        protected override Task<SimpleResponse> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken, Application client)
        {
            var isPublic = IsPublic.Get(context);
            return client.RegisterCollection(isPublic);
        }

        protected override void OutputResult(AsyncCodeActivityContext context, SimpleResponse response)
        {
            Result.Set(context, response.Results);
        }
    }
}

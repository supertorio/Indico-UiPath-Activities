using Indico.Activities.Properties;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;

namespace Indico.Activities
{
    [LocalizedDisplayName(nameof(Resources.DeAuthorizeUserDisplayName))]
    [LocalizedDescription(nameof(Resources.DeAuthorizeUserDescription))]
    public class DeAuthorizeUser : AsyncTaskCodeActivity<bool>
    {
        [LocalizedCategory(nameof(Resources.CollectionInfoCategoryName))]
        [LocalizedDisplayName(nameof(Resources.ModelNameDisplayName))]
        [LocalizedDescription(nameof(Resources.ModelNameDescription))]
        public InArgument<string> CollectionName { get; set; }

        [LocalizedDisplayName(nameof(Resources.DeAuthorizeUserEmailDisplayName))]
        [LocalizedDescription(nameof(Resources.DeAuthorizeUserEmailsDescription))]
        [LocalizedCategory(nameof(Resources.Input))]
        [RequiredArgument]
        public InArgument<string> UserEmail { get; set; }

        [LocalizedDisplayName(nameof(Resources.DeAuthorizeSuccessDisplayName))]
        [LocalizedDescription(nameof(Resources.DeAuthorizeSuccessDescription))]
        [LocalizedCategory(nameof(Resources.Output))]
        public OutArgument<bool> Result { get; set; }

        protected override Task<bool> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken, Application client)
        {
            var collectionName = CollectionName.Get(context);
            var email = UserEmail.Get(context);
            return client.RemoveUserFromCustomCollection(collectionName, email);
        }

        protected override void OutputResult(AsyncCodeActivityContext context, bool response)
        {
            Result.Set(context, response);
        }
    }
}

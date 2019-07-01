using Indico.Custom.Activities.Properties;
using Indico.Custom.Models;
using System;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;

namespace Indico.Custom.Activities
{
    [LocalizedDisplayName(nameof(Resources.DeAuthorizeUserDisplayName))]
    [LocalizedDescription(nameof(Resources.DeAuthorizeUserDescription))]
    public class DeAuthorizeUser : AsyncTaskCodeActivity<SimpleResponse>
    {
        [LocalizedDisplayName(nameof(Resources.DeAuthorizeUserEmailDisplayName))]
        [LocalizedDescription(nameof(Resources.DeAuthorizeUserEmailsDescription))]
        [LocalizedCategory(nameof(Resources.Input))]
        [RequiredArgument]
        public InArgument<string> UserEmail { get; set; }

        [LocalizedDisplayName(nameof(Resources.DeAuthorizeSuccessDisplayName))]
        [LocalizedDescription(nameof(Resources.DeAuthorizeSuccessDescription))]
        [LocalizedCategory(nameof(Resources.Output))]
        public OutArgument<bool> Result { get; set; }

        protected override Task<SimpleResponse> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken, Application client)
        {
            var email = UserEmail.Get(context);
            return client.RemoveUserFromCollection(email);
        }

        protected override void OutputResult(AsyncCodeActivityContext context, SimpleResponse response)
        {
            Result.Set(context, response.Results);
        }
    }
}

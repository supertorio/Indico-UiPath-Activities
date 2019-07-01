using Indico.Custom.Activities.Properties;
using Indico.Custom.Enums;
using Indico.Custom.Models;
using System;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;

namespace Indico.Custom.Activities
{
    [LocalizedDisplayName(nameof(Resources.AuthorizeUserDisplayName))]
    [LocalizedDescription(nameof(Resources.AuthorizeUserDescription))]
    public class AuthorizeUser : AsyncTaskCodeActivity<SimpleResponse>
    {
        [LocalizedDisplayName(nameof(Resources.AuthorizeUserEmailDisplayName))]
        [LocalizedDescription(nameof(Resources.AuthorizeUserEmailsDescription))]
        [LocalizedCategory(nameof(Resources.Input))]
        [RequiredArgument]
        public InArgument<string> UserEmail { get; set; }

        [LocalizedDisplayName(nameof(Resources.AuthorizeUserPermissionDisplayName))]
        [LocalizedDescription(nameof(Resources.AuthorizeUserPermissionDescription))]
        [LocalizedCategory(nameof(Resources.Input))]
        [RequiredArgument]
        public CollectionPermission UserPermission { get; set; }

        [LocalizedDisplayName(nameof(Resources.AuthorizeSuccessDisplayName))]
        [LocalizedDescription(nameof(Resources.AuthorizeSuccessDescription))]
        [LocalizedCategory(nameof(Resources.Output))]
        public OutArgument<bool> Result { get; set; }

        public AuthorizeUser()
        {
            UserPermission = CollectionPermission.Read;
        }

        protected override Task<SimpleResponse> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken, Application client)
        {
            var email = UserEmail.Get(context);
            var permission = UserPermission;
            return client.AddUserToCollection(email, permission);
        }

        protected override void OutputResult(AsyncCodeActivityContext context, SimpleResponse response)
        {
            Result.Set(context, response.Results);
        }
    }
}

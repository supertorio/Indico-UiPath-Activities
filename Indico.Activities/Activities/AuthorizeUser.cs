using Indico.Activities.Properties;
using Indico.Enums;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;

namespace Indico.Activities
{
    [LocalizedDisplayName(nameof(Resources.AuthorizeUserDisplayName))]
    [LocalizedDescription(nameof(Resources.AuthorizeUserDescription))]
    public class AuthorizeUser : AsyncTaskCodeActivity<bool>
    {
        [LocalizedCategory(nameof(Resources.CollectionInfoCategoryName))]
        [LocalizedDisplayName(nameof(Resources.ModelNameDisplayName))]
        [LocalizedDescription(nameof(Resources.ModelNameDescription))]
        public InArgument<string> CollectionName { get; set; }

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

        protected override Task<bool> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken, Application client)
        {
            var collectionName = CollectionName.Get(context);
            var email = UserEmail.Get(context);
            var permission = UserPermission;
            return client.AddUserToCustomCollection(collectionName, email, permission);
        }

        protected override void OutputResult(AsyncCodeActivityContext context, bool response)
        {
            Result.Set(context, response);
        }
    }
}

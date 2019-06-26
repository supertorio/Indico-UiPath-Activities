﻿using System;
using System.Activities;
using System.ComponentModel;
using System.Activities.Statements;
using Indico.Custom.Activities.Properties;
using Indico.Custom.Enums;

namespace Indico.Custom.Activities
{

    [LocalizedDescription(nameof(Resources.IndicoScopeDescription))]
    [LocalizedDisplayName(nameof(Resources.IndicoScope))]
    public class IndicoCustomScope : NativeActivity
    {
        #region Properties

        [Browsable(false)]
        public ActivityAction<Application> Body { get; set; }

        [LocalizedCategory(nameof(Resources.Authentication))]
        [LocalizedDisplayName(nameof(Resources.IndicoScopeApiKeyDisplayName))]
        [LocalizedDescription(nameof(Resources.IndicoScopeApiKeyDescription))]
        [RequiredArgument]
        public InArgument<string> ApiKey { get; set; }

        [LocalizedCategory(nameof(Resources.Authentication))]
        [LocalizedDisplayName(nameof(Resources.IndicoScopeApiURLDisplayName))]
        [LocalizedDescription(nameof(Resources.IndicoScopeApiURLDescription))]
        [RequiredArgument]
        public InArgument<string> ApiURL { get; set; }

        [LocalizedCategory(nameof(Resources.CollectionInfoCategoryName))]
        [LocalizedDisplayName(nameof(Resources.IndicoScopeModelNameDisplayName))]
        [LocalizedDescription(nameof(Resources.IndicoScopeModelNameDescription))]
        public InArgument<string> CollectionName { get; set; }

        [LocalizedCategory(nameof(Resources.CollectionInfoCategoryName))]
        [LocalizedDisplayName(nameof(Resources.IndicoScopeModelDomainDisplayName))]
        [LocalizedDescription(nameof(Resources.IndicoScopeModelDomainDescription))]
        public ModelDomain CollectionDomain { get; set; }

        internal static string ParentContainerPropertyTag => "IndicoScope";

        #endregion


        #region Constructors

        public IndicoCustomScope()
        {
            Body = new ActivityAction<Application>
            {
                Argument = new DelegateInArgument<Application>(ParentContainerPropertyTag),
                Handler = new Sequence { DisplayName = "Do" }
            };

            ApiURL = "https://apiv2.indico.io/";
            CollectionDomain = ModelDomain.Standard;
        }

        #endregion


        #region Private Methods

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);
        }

        protected override void Execute(NativeActivityContext context)
        {
            var apiKey = ApiKey.Get(context);
            var apiUrl = ApiURL.Get(context);
            var collectionName = CollectionName.Get(context);
            var collectionDomain = CollectionDomain;
            var application = new Application(apiKey, apiUrl, collectionName, collectionDomain);

            if (Body != null)
            {
                context.ScheduleAction<Application>(Body, application, OnCompleted, OnFaulted);
            }
        }

        private void OnFaulted(NativeActivityFaultContext faultContext, Exception propagatedException, ActivityInstance propagatedFrom)
        {
            //TODO
        }

        private void OnCompleted(NativeActivityContext context, ActivityInstance completedInstance)
        {
            //TODO
        }

        #endregion
    }
}

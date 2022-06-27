﻿#if NETFRAMEWORK
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Core.Logging;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Forms.Core.Data.Storage;
using Umbraco.Forms.Integrations.Automation.Zapier.Extensions;
using Umbraco.Forms.Integrations.Automation.Zapier.Helpers;
using Umbraco.Forms.Integrations.Automation.Zapier.Services;
using Umbraco.Web;

namespace Umbraco.Forms.Integrations.Automation.Zapier.Components
{
    [RuntimeLevel(MinLevel = RuntimeLevel.Run)]
    public class NewFormSubmittedComposer : ComponentComposer<NewFormSubmittedComponent>
    { }

    public class NewFormSubmittedComponent : IComponent
    {
        private readonly UmbUrlHelper _umbUrlHelper;

        private readonly IRecordStorage _recordStorage;

        private readonly ZapierService _zapierService;

        private readonly ZapierFormSubscriptionHookService _zapierFormSubscriptionHookService;
        
        private readonly ILogger _logger;

        public NewFormSubmittedComponent(
            UmbUrlHelper umbUrlHelper, 
            IRecordStorage recordStorage, 
            ZapierService zapierService, 
            ZapierFormSubscriptionHookService zapierFormSubscriptionHookService,
            ILogger logger)
        {
            _umbUrlHelper = umbUrlHelper;

            _recordStorage = recordStorage;

            _zapierService = zapierService;

            _zapierFormSubscriptionHookService = zapierFormSubscriptionHookService;

            _logger = logger;
        }

        public void Initialize()
        {
            _recordStorage.RecordInserting += RecordStorage_RecordInserting;
        }

        public void Terminate()
        {
        }

        private void RecordStorage_RecordInserting(object sender, Core.RecordEventArgs e)
        {
            var triggerHelper = new TriggerHelper(_zapierService);

            if (_zapierFormSubscriptionHookService.TryGetById(e.Form.Id.ToString(), out var subscriptionHooks))
            {
                var content = e.Form.ToFormDictionary(e.Record, _umbUrlHelper.GetPageUrl(e.Record.UmbracoPageId));

                foreach (var subscriptionHook in subscriptionHooks)
                {
                    var result = triggerHelper.FormExecute(subscriptionHook.HookUrl, content);

                    if (!string.IsNullOrEmpty(result))
                        _logger.Error<NewFormSubmittedComponent>(result);
                }
            }
        }
    }
}
#endif

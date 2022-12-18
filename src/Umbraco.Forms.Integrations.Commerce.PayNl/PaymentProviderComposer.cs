

using Microsoft.Extensions.DependencyInjection;
using Umbraco.Forms.Core.Providers;
using Umbraco.Forms.Integrations.Commerce.Emerchantpay.Services;
using Umbraco.Forms.Integrations.Commerce.PayNl.Configuration;
using Umbraco.Forms.Integrations.Commerce.PayNl.Helpers;
using Umbraco.Forms.Integrations.Commerce.PayNl.Models.Dtos;
using Umbraco.Forms.Integrations.Commerce.PayNl.Services;

#if NETCOREAPP
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
#else
using Umbraco.Core;
using Umbraco.Core.Composing;
#endif

namespace Umbraco.Forms.Integrations.Commerce.PayNl
{
    public class PaymentProviderComposer : IComposer
    {
#if NETCOREAPP
        public void Compose(IUmbracoBuilder builder)
        {
            var options = builder.Services
                .AddOptions<PaymentProviderSettings>()
                .Bind(builder.Config.GetSection(Constants.Configuration.Settings));

            builder.WithCollectionBuilder<WorkflowCollectionBuilder>()
                .Add<PaymentProviderWorkflow>();

            builder.Services.AddSingleton<ConsumerService>();

            builder.Services.AddSingleton<PaymentService>();

            builder.Services.AddSingleton<UrlHelper>();

            builder.Services.AddSingleton<CurrencyHelper>();

            builder.Services.AddSingleton<MappingFieldHelper>();

            builder.Services.AddSingleton<IMappingService<Mapping>, MappingService>();

            builder.Services.AddSingleton<ISettingsParser, ObjectParser>();
        }
#else
        public void Compose(Composition composition)
        {
            composition.Register<ConsumerService>(Lifetime.Singleton);

            composition.Register<PaymentService>(Lifetime.Singleton);

            composition.Register<UrlHelper>(Lifetime.Singleton);

            composition.Register<CurrencyHelper>(Lifetime.Singleton);

            composition.Register<MappingFieldHelper>(Lifetime.Singleton);

            composition.Register<IMappingService<Mapping>, MappingService>(Lifetime.Singleton);

            composition.Register<ISettingsParser, StringParser>(Lifetime.Singleton);
        }
#endif
    }
}

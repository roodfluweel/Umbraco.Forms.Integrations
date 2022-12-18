using System.Collections.Generic;
using System.Linq;

using Umbraco.Forms.Integrations.Commerce.PayNl.Configuration;
using Umbraco.Forms.Integrations.Commerce.PayNl.Models.Dtos;
using Umbraco.Forms.Integrations.Commerce.PayNl.Configuration;

namespace Umbraco.Forms.Integrations.Commerce.PayNl.Helpers
{
    public class CurrencyHelper
    {
        private readonly ISettingsParser _settingsParser;

        public CurrencyHelper(ISettingsParser settingsParser)
        {
            _settingsParser = settingsParser;
        }

        public IEnumerable<CurrencyDto> GetCurrencies()
        {
            var currencies = _settingsParser.AsDictionary(nameof(PaymentProviderSettings.Currencies));

            if (currencies.Count == 0) return Enumerable.Empty<CurrencyDto>();

            try
            {
                return currencies.Select(p => new CurrencyDto { Code = p.Key, Name = p.Value });
            }
            catch 
            {
                return Enumerable.Empty<CurrencyDto>();
            }

        }

    }
}


namespace Umbraco.Forms.Integrations.Commerce.PayNl
{
    public class Constants
    {
        public const string WorkflowId = "B8740105-80DD-459F-B189-F28B4FEA38E3";

        public static class Configuration
        {
            public const string Settings = "Umbraco:Forms:Integrations:Commerce:PayNl:Settings";

            public const string GatewayBaseUrlKey = "Umbraco.Forms.Integrations.Commerce.PayNl.GatewayBaseurl";

            public const string WpfUrlKey = "Umbraco.Forms.Integrations.Commerce.PayNl.WpfUrl";

            public const string UsernameKey = "Umbraco.Forms.Integrations.Commerce.PayNl.Username";

            public const string PasswordKey = "Umbraco.Forms.Integrations.Commerce.PayNl.Password";

            public const string SupplierKey = "Umbraco.Forms.Integrations.Commerce.PayNl.Supplier";

            public const string UsageKey = "Umbraco.Forms.Integrations.Commerce.PayNl.Usage";

            public const string CurrenciesKey = "Umbraco.Forms.Integrations.Commerce.PayNl.Currencies";

            public const string TransactionTypesKey = "Umbraco.Forms.Integrations.Commerce.PayNl.TransactionTypes";

            public const string MappingFieldsKey = "Umbraco.Forms.Integrations.Commerce.PayNl.MappingFields";

            public const string UmbracoBaseUrlKey = "Umbraco.Forms.Integrations.Commerce.PayNl.UmbracoBaseUrl";
        }

        public static class ErrorCode
        {
            public const string ConsumerExists = "701";

            public const string WorkflowError = "400";
        }

        public static class RootNode
        {
            public const string CreateConsumerRequest = "create_consumer_request";

            public const string CreateConsumerResponse = "create_consumer_response";

            public const string RetrieveConsumerRequest = "retrieve_consumer_request";

            public const string RetrieveConsumerResponse = "retrieve_consumer_response";

            public const string WpfPayment = "wpf_payment";

            public const string WpfReconcile = "wpf_reconcile";
        }

        public static class NotificationProperty
        {
            public const string TransactionId = "wpf_transaction_id";

            public const string UniqueId = "wpf_unique_id";

            public const string Status = "wpf_status";
        }

        public static class PaymentStatus
        {
            public const string Approved = "approved";
        }
    }
}

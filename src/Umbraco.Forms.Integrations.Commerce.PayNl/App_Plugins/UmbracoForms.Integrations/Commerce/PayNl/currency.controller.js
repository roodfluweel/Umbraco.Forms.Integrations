function CurrencyController($scope, umbracoFormsIntegrationsCommercePayNlResource) {

    var vm = this;

    if ($scope.setting && $scope.setting.value) vm.selectedCurrency = $scope.setting.value;

    umbracoFormsIntegrationsCommerceEmerchantpayResource.getCurrencies().then(function (response) {
        vm.currencies = response;
    });

    vm.saveCurrency = function () {
        $scope.setting.value = vm.selectedCurrency;
    }
}

angular.module("umbraco")
    .controller("UmbracoForms.Integrations.Commerce.PayNl.CurrencyController", CurrencyController);

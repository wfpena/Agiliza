(function () {
    angular.module('app').controller('app.views.products.createStoryModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.productBack',
        function ($scope, $uibModalInstance, productService) {
            var vm = this;

            vm.save = function () {
                productService.createProduct(vm.product)
                    .then(function () {
                        abp.notify.info(App.localize('SavedSuccessfully'));
                        $uibModalInstance.close();
                    });
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss({});
            };

        }
    ]);
})();
(function () {
    angular.module('app').controller('app.views.products.editStoryModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.productBack', 'id',
        function ($scope, $uibModalInstance, productService, id) {
            var vm = this;

            getStory();
            
            function getStory() {
                productService.getUserStory(id).then(function (result) {
                    vm.story = result.data;
                });
            }

            vm.save = function () {
                productService.updateStory(vm.story)
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
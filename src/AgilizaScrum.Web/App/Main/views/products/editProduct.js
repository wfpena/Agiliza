(function () {
    angular.module('app').controller('app.views.products.editProduct', [
        '$scope', '$uibModal', 'abp.services.app.productBack', '$stateParams',
        function ($scope, $uibModal, productService, $stateParams) {
            var vm = this;

            getProduct();
            getStories();

            vm.userStories = [{ name: "asdaw", description: "WDADWADWA" }, { name: "a22sdaw", description: "WDAD2222WADWA" }, { name: "a22sdaw", description: "WDAD2222WADWA" }, { name: "a22sdaw", description: "WDAD2222WADWA" }];

            function getProduct() {
                productService.get($stateParams.id).then(function (result) {
                    vm.product = result.data;
                });
            }

            function getStories() {
                productService.getAllStories($stateParams.id).then(function (result) {
                    vm.stories = result.data;
                });
            }

            vm.createStory = function () {
                
                productService.createStory()
            };

            vm.openUserStoryModal = function () {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/products/createModal.cshtml',
                    controller: 'app.views.products.createModal as vm',
                    backdrop: 'static'
                });

                modalInstance.rendered.then(function () {
                    $.AdminBSB.input.activate();
                });

                modalInstance.result.then(function () {
                    getProducts();
                });
            };

            vm.cancel = function () {
                //$uibModalInstance.dismiss({});
            };
        }
    ]);
})();
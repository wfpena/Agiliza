(function () {
    angular.module('app').controller('app.views.products.index', [
        '$scope', '$timeout', '$uibModal', 'abp.services.app.productBack','$state',
        function ($scope, $timeout, $uibModal, productService, $state) {
            var vm = this;

            vm.products = [];

            getProducts();
            
            function getProducts() {
                productService.getAll().then(function (result) {
                    vm.products = result.data;
                });
            }

            vm.openProductCreationModal = function () {
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

            vm.refresh = function () {
                getProducts();
            };

            
        }
    ]);
})();
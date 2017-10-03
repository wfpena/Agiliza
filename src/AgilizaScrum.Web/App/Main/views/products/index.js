(function () {
    angular.module('app').controller('app.views.products.index', [
        '$scope', '$timeout', '$uibModal', 'abp.services.app.productBack',
        function ($scope, $timeout, $uibModal, productService) {
            var vm = this;

            vm.products = [];

            getProducts();

            function getProducts() {
                productService.getAll({}).then(function (result) {
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

            //vm.openUserEditModal = function (user) {
            //    var modalInstance = $uibModal.open({
            //        templateUrl: '/App/Main/views/products/editModal.cshtml',
            //        controller: 'app.views.products.editModal as vm',
            //        backdrop: 'static',
            //        resolve: {
            //            id: function () {
            //                return user.id;
            //            }
            //        }
            //    });

            //    modalInstance.rendered.then(function () {
            //        $timeout(function () {
            //            $.AdminBSB.input.activate();
            //        }, 0);
            //    });

            //    modalInstance.result.then(function () {
            //        getUsers();
            //    });
            //};

            //vm.delete = function (user) {
            //    abp.message.confirm(
            //        "Delete user '" + user.userName + "'?",
            //        function (result) {
            //            if (result) {
            //                userService.delete({ id: user.id })
            //                    .then(function () {
            //                        abp.notify.info("Deleted user: " + user.userName);
            //                        getUsers();
            //                    });
            //            }
            //        });
            //}

            vm.refresh = function () {
                getProducts();
            };

            
        }
    ]);
})();
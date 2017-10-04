(function () {
    angular.module('app').controller('app.views.products.editProduct', [
        '$scope', '$uibModal', 'abp.services.app.productBack', '$stateParams',
        function ($scope, $uibModal, productService, $stateParams) {
            var vm = this;

            getProduct();
            getStories();

            vm.toRelease = [{ name: "asdaw", description: "WDADWADWA" }, { name: "a22sdaw", description: "WDAD2222WADWA" }, { name: "a22sdaw", description: "WDAD2222WADWA" }, { name: "a22sdaw", description: "WDAD2222WADWA" }];

            vm.models = {
                selected: null,
                templates: [
                    { type: "item", id: 2 },
                    { type: "container", id: 1, columns: [[], []] }
                ],
                dropzones: {
                    "Product": vm.stories,
                    "Release": vm.toRelease

                }

            };


            function getProduct() {
                productService.get($stateParams.id).then(function (result) {
                    vm.product = result.data;
                });
            }

            function getStories() {
                productService.getStories($stateParams.id).then(function (result) {
                    vm.stories = result.data;
                    vm.models.dropzones.Product = vm.stories;
                });
            }

            vm.createStory = function () {
                var story = { name: "Story", description: "Description", productBackId : $stateParams.id}
                productService.createStory(story)
                    .then(function () {
                        abp.notify.info(App.localize('SavedSuccessfully'));
                        getStories();
                        
                    });
            };

            vm.openStoryModal = function (story) {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/products/userStory/editStoryModal.cshtml',
                    controller: 'app.views.products.editStoryModal as vm',
                    backdrop: 'static',
                    resolve: {
                        id: function () {
                            return story.id;
                        }
                    }
                });

                modalInstance.rendered.then(function () {
                    $.AdminBSB.input.activate();
                });

                modalInstance.result.then(function () {
                    getStories();
                });
            };

            vm.cancel = function () {
                //$uibModalInstance.dismiss({});
            };
        }
    ]);
})();
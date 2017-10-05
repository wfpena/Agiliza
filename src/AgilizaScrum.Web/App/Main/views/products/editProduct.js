(function () {
    angular.module('app').controller('app.views.products.editProduct', [
        '$scope', '$uibModal', 'abp.services.app.productBack', 'abp.services.app.userStory', 'abp.services.app.releaseBack','$stateParams',
        function ($scope, $uibModal, productService, storyService, releaseService, $stateParams) {
            var vm = this;

            getProduct();
            getStories();
            
            vm.models = {
                selected: null,
                templates: [
                    { type: "item", id: 2 },
                    { type: "container", id: 1, columns: [[], []] }
                ],
                dropzones: {
                    "Product": vm.stories,
                    "Release": vm.stories
                }

            };


            function getProduct() {
                productService.get($stateParams.id).then(function (result) {
                    vm.product = result.data;
                });
            }

            function getStories() {
                storyService.getCreatedStories($stateParams.id).then(function (result) {
                    vm.stories = result.data;
                    vm.models.dropzones.Product = vm.stories;
                    vm.models.dropzones.Release = vm.stories;
                });
            }

            vm.createStory = function () {
                var story = { name: "Story", description: "Description", productBackId : $stateParams.id}
                storyService.createStory(story)
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

            vm.deleteStory = function (story) {
                vm.toRelease = [];
                abp.message.confirm(
                    "Delete story '" + story.name + "'?",
                    function (result) {
                        if (result) {
                            storyService.deleteStory(story.id)
                                .then(function () {
                                    abp.notify.info(App.localize('DelteSuccessfully'));
                                    getStories();
                                });
                        }
                    });
            };

            vm.releaseBacklog = function () {
                abp.message.confirm(
                    "Release back '" + vm.release.name + "'?",
                    function (result) {
                        if (result) {
                            releaseService.createRelease(vm.release)
                                .then(function (result) {
                                    storyService.releasedState(vm.toRelease)
                                        .then(function () {
                                            getStories();
                                        });
                                });
                            
                        }
                    });

            };

            vm.refresh = function () {
                initialize();
            };
        }
    ]);
})();
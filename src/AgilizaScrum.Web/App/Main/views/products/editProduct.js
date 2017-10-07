﻿(function () {
    angular.module('app').controller('app.views.products.edit', [
        '$scope', '$uibModal', 'abp.services.app.productBack', 'abp.services.app.userStory', 'abp.services.app.releaseBack','$stateParams',
        function ($scope, $uibModal, productService, storyService, releaseService, $stateParams) {
            var vm = this;

            getProduct();
            getStories();

            vm.releaseStories = [];
            vm.release = [];
            vm.release.name = "Release Name";
            
            vm.models = {
                selected: null,
                templates: [
                    { type: "item", id: 2 },
                    { type: "container", id: 1, columns: [[], []] }
                ],
                dropzones: {
                    "Product" : [],
                    "Release": []
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
                    angular.forEach(vm.models.dropzones.Release, function (data) {
                        vm.models.dropzones.Product = vm.models.dropzones.Product.filter(function (obj) {
                            return obj.id !== data.id;
                        });
                    });
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
                        },
                        user: function () {
                            return 0;
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
                if (vm.models.dropzones.Release)
                abp.message.confirm(
                    "Release back '" + vm.release.name + "'?",
                    function (result) {
                        if (result) {
                            vm.release.description = "Release Description";
                            releaseService.createRelease({ name: vm.release.name, description: vm.release.description, productBackId: $stateParams.id })
                                .then(function (result) {
                                    storyService.releasedState(vm.models.dropzones.Release, result.data)
                                        .then(function () {
                                            abp.notify.info(App.localize('CreatedRelease'));
                                            vm.models.dropzones.Release = [];
                                            getStories();
                                        });
                                });
                            
                        }
                    });

            };

            vm.refresh = function () {
               // initialize();
            };
        }
    ]);
})();
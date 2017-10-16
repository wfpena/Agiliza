(function () {
    angular.module('app').controller('app.views.sprints.sprintplanning.startSprint', [
        '$scope', '$timeout', '$uibModal', 'abp.services.app.productBack', 'abp.services.app.releaseBack', 'abp.services.app.userStory',
        function ($scope, $timeout, $uibModal, productService, releaseService, storyService) {
            var vm = this;

            vm.releases = [];
            vm.storiesSprint = [];

            getReleases();

            vm.current = 0;
            vm.currentMain = 0;

            vm.rightClick = function () {
                if (vm.current < vm.releases.length-1)
                    vm.current = vm.current + 1;
                else
                    vm.current = 0;

                vm.currentRelease = vm.releases[vm.current];
                storyService.getStoriesRelease(vm.currentRelease.id).then(function (result) {
                    vm.stories = result.data;
                });
            }

            vm.leftClick = function () {
                if (vm.current != 0)
                    vm.current = vm.current - 1;
                else
                    vm.current = vm.releases.length - 1;

                vm.currentRelease = vm.releases[vm.current];
                storyService.getStoriesRelease(vm.currentRelease.id).then(function (result) {
                    vm.stories = result.data;
                });
            }


            function getReleases() {
                releaseService.getAll().then(function (result) {
                    vm.releases = result.data;
                    vm.currentRelease = vm.releases[0];
                    storyService.getStoriesRelease(vm.currentRelease.id).then(function (data) {
                        vm.stories = data.data;
                    });
                });
            }
            
        }
    ]);
})();
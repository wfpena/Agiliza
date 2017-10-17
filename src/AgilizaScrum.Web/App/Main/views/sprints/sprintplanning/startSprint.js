(function () {
    angular.module('app').controller('app.views.sprints.sprintplanning.startSprint', [
        '$scope', '$timeout', '$uibModal', 'abp.services.app.sprint', 'abp.services.app.releaseBack', 'abp.services.app.userStory',
        function ($scope, $timeout, $uibModal, sprintService, releaseService, storyService) {
            var vm = this;

            vm.releases = [];
            vm.storiesSprint = [];
            vm.sprint = [];

            getReleases();

            vm.current = 0;
            vm.currentMain = 0;

            vm.rightClick = function () {
                if (vm.current < vm.releases.length-1)
                    vm.current = vm.current + 1;
                else
                    vm.current = 0;

                vm.currentRelease = vm.releases[vm.current];
                getUnselectedStories();
            }

            vm.leftClick = function () {
                if (vm.current != 0)
                    vm.current = vm.current - 1;
                else
                    vm.current = vm.releases.length - 1;

                vm.currentRelease = vm.releases[vm.current];
                getUnselectedStories();
            }

            vm.createSprint = function () {
                abp.message.confirm(
                    //"Create Sprint'" + vm.sprint.name + "'?",
                    "Create Sprint?",
                    function (result) {
                        if (result) {
                            vm.sprint.description = "Sprint Description";
                            sprintService.createSprint({ name: "Sprint", description: vm.sprint.description })
                                .then(function (result) {
                                    storyService.sprintState(vm.storiesSprint, result.data)
                                        .then(function () {
                                            abp.notify.info(App.localize('CreatedRelease'));
                                            vm.storiesSprint = [];
                                        });
                                });
                            
                        }
                    });

            };

            function getReleases() {
                releaseService.getAll().then(function (result) {
                    vm.releases = result.data;
                    vm.currentRelease = vm.releases[0];
                    getUnselectedStories();
                });
            }

            function getUnselectedStories() {
                storyService.getStoriesRelease(vm.currentRelease.id).then(function (result) {
                    vm.stories = result.data;
                    angular.forEach(vm.storiesSprint, function (data) {
                        vm.stories = vm.stories.filter(function (obj) {
                            return obj.id !== data.id;
                        });
                    });
                });
            }
            
        }
    ]);
})();
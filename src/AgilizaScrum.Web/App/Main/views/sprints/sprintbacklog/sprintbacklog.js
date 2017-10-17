(function () {
    angular.module('app').controller('app.views.sprints.sprintbacklog', [
        '$scope', '$timeout', '$uibModal', 'abp.services.app.sprint', 'abp.services.app.releaseBack',
        function ($scope, $timeout, $uibModal, sprintService, releaseService) {
            var vm = this;

            vm.sprints = [];

            getSprints();

            function getSprints() {
                sprintService.getAll().then(function (result) {
                    vm.sprints = result.data;
                });
            }

            vm.refresh = function () {
                getReleases();
            };

            
        }
    ]);
})();
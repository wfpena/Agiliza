(function () {
    angular.module('app').controller('app.views.sprints.sprintplanning.startSprint', [
        '$scope', '$timeout', '$uibModal', 'abp.services.app.productBack', 'abp.services.app.releaseBack',
        function ($scope, $timeout, $uibModal, productService, releaseService) {
            var vm = this;

            vm.releases = [];

            getReleases();

            vm.current = 0;
            vm.currentMain = 0;

            vm.rightClick = function () {
                if (vm.current < vm.releases.length-1)
                    vm.current = vm.current + 1;
                else
                    vm.current = 0;
            }

            vm.leftClick = function () {
                if (vm.current != 0)
                    vm.current = vm.current - 1;
                else
                    vm.current = vm.releases.length-1;
            }


            function getReleases() {
                releaseService.getAll().then(function (result) {
                    vm.releases = result.data;
                });
            }

            
        }
    ]);
})();
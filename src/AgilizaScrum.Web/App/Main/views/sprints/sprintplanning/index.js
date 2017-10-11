(function () {
    angular.module('app').controller('app.views.sprints.sprintplanning.index', [
        '$scope', '$timeout', '$uibModal', 'abp.services.app.productBack', 'abp.services.app.releaseBack',
        function ($scope, $timeout, $uibModal, productService, releaseService) {
            var vm = this;

            vm.releases = [];

            getReleases();

            function getReleases() {
                releaseService.getAll().then(function (result) {
                    vm.releases = result.data;
                });
            }

            
        }
    ]);
})();
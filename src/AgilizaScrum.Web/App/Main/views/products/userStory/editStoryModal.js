(function () {
    angular.module('app').controller('app.views.products.editStoryModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.userStory', 'id', 'user',
        function ($scope, $uibModalInstance, storyService, id, user) {
            var vm = this;

            getStory();
            vm.user = user;

            function getStory() {
                storyService.getUserStory(id).then(function (result) {
                    vm.story = result.data;
                });
            }

            vm.save = function () {
                storyService.updateStory(vm.story)
                    .then(function () {
                        abp.notify.info(App.localize('SavedSuccessfully'));
                        $uibModalInstance.close();
                    });
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss({});
            };

        }
    ]);
})();
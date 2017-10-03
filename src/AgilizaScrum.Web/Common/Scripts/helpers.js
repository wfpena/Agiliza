var App = App || {};
(function () {

    var appLocalizationSource = abp.localization.getSource('AgilizaScrum');
    App.localize = function () {
        return appLocalizationSource.apply(this, arguments);
    };

})(App);
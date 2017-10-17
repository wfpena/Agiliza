(function () {
    'use strict';

    var app = angular.module('app', [
        'ngAnimate',
        'ngSanitize',

        'ui.router',
        'ui.bootstrap',
        'ui.jq',

        'abp',
        'ui.select',
        'dndLists'
    ]);

    //Configuration for Angular UI routing.
    app.config([
        '$stateProvider', '$urlRouterProvider', '$locationProvider', '$qProvider',
        function ($stateProvider, $urlRouterProvider, $locationProvider, $qProvider) {
            $locationProvider.hashPrefix('');
            $urlRouterProvider.otherwise('/');
            $qProvider.errorOnUnhandledRejections(false);

            if (abp.auth.hasPermission('Pages.Users')) {
                $stateProvider
                    .state('users', {
                        url: '/users',
                        templateUrl: '/App/Main/views/users/index.cshtml',
                        menu: 'Users' //Matches to name of 'Users' menu in AgilizaScrumNavigationProvider
                    });
                $urlRouterProvider.otherwise('/users');
            }

            if (abp.auth.hasPermission('Pages.Roles')) {
                $stateProvider
                    .state('roles', {
                        url: '/roles',
                        templateUrl: '/App/Main/views/roles/index.cshtml',
                        menu: 'Roles' //Matches to name of 'Tenants' menu in AgilizaScrumNavigationProvider
                    });
                $urlRouterProvider.otherwise('/roles');
            }

            if (abp.auth.hasPermission('Pages.Tenants')) {
                $stateProvider
                    .state('tenants', {
                        url: '/tenants',
                        templateUrl: '/App/Main/views/tenants/index.cshtml',
                        menu: 'Tenants' //Matches to name of 'Tenants' menu in AgilizaScrumNavigationProvider
                    });
                $urlRouterProvider.otherwise('/tenants');
            }

            if (abp.auth.hasPermission('Developer')) {
                $stateProvider
                    .state('releases', {
                        url: '/releases',
                        templateUrl: '/App/Main/views/release/index.cshtml',
                        menu: 'Release'
                    })
                    .state('releaseInfo', {
                        url: '/releaseInfo/:id',
                        templateUrl: '/App/Main/views/release/releaseInfo/releaseInfo.cshtml'
                    });
                $urlRouterProvider.otherwise('/releases');
            }

            if (abp.auth.hasPermission('ProductOwner')) {
                $stateProvider
                    .state('products', {
                        url: '/products',
                        templateUrl: '/App/Main/views/products/index.cshtml',
                        menu: 'Products' //Matches to name of 'ProductBacklog' menu in AgilizaScrumNavigationProvider
                    })
                    .state('productEdit', {
                        url: '/productEdit/:id',
                        templateUrl: '/App/Main/views/products/editProduct.cshtml',
                        cache: false
                    });
                $urlRouterProvider.otherwise('/products');
            }

            $stateProvider
                .state('home', {
                    url: '/',
                    templateUrl: '/App/Main/views/home/home.cshtml',
                    menu: 'Home' //Matches to name of 'Home' menu in AgilizaScrumNavigationProvider
                })
                .state('sprints', {
                    url: '/sprints',
                    templateUrl: '/App/Main/views/sprints/sprintbacklog/sprintbacklog.cshtml'
                })
                .state('sprintplanning', {
                    url: '/sprintplanning',
                    templateUrl: '/App/Main/views/sprints/sprintplanning/index.cshtml'
                })
                .state('startsprint', {
                    url: '/startsprint',
                    templateUrl: '/App/Main/views/sprints/sprintplanning/startSprint.cshtml'
                })
                .state('about', {
                    url: '/about',
                    templateUrl: '/App/Main/views/about/about.cshtml',
                    menu: 'About' //Matches to name of 'About' menu in AgilizaScrumNavigationProvider
                });
        }
    ]);

    app.factory('PagerService', PagerService);

    function PagerService() {
        // service definition
        var service = {};

        service.GetPager = GetPager;

        return service;

        // service implementation
        function GetPager(totalItems, currentPage, pageSize) {
            // default to first page
            currentPage = currentPage || 1;

            // default page size is 10
            pageSize = pageSize || 10;

            // calculate total pages
            var totalPages = Math.ceil(totalItems / pageSize);

            var startPage, endPage;
            if (totalPages <= 10) {
                // less than 10 total pages so show all
                startPage = 1;
                endPage = totalPages;
            } else {
                // more than 10 total pages so calculate start and end pages
                if (currentPage <= 6) {
                    startPage = 1;
                    endPage = 10;
                } else if (currentPage + 4 >= totalPages) {
                    startPage = totalPages - 9;
                    endPage = totalPages;
                } else {
                    startPage = currentPage - 5;
                    endPage = currentPage + 4;
                }
            }

            // calculate start and end item indexes
            var startIndex = (currentPage - 1) * pageSize;
            var endIndex = Math.min(startIndex + pageSize - 1, totalItems - 1);

            // create an array of pages to ng-repeat in the pager control
            var pages = _.range(startPage, endPage + 1);

            // return object with all pager properties required by the view
            return {
                totalItems: totalItems,
                currentPage: currentPage,
                pageSize: pageSize,
                totalPages: totalPages,
                startPage: startPage,
                endPage: endPage,
                startIndex: startIndex,
                endIndex: endIndex,
                pages: pages
            };
        }
    }

})();
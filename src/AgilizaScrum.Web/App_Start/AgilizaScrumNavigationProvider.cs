﻿using Abp.Application.Navigation;
using Abp.Localization;
using AgilizaScrum.Authorization;

namespace AgilizaScrum.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See .cshtml and .js files under App/Main/views/layout/header to know how to render menu.
    /// </summary>
    public class AgilizaScrumNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "Home",
                        new LocalizableString("HomePage", AgilizaScrumConsts.LocalizationSourceName),
                        url: "#/",
                        icon: "fa fa-home",
                        requiresAuthentication: true
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Tenants",
                        L("Tenants"),
                        url: "#tenants",
                        icon: "fa fa-globe",
                        requiredPermissionName: PermissionNames.Pages_Tenants
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Users",
                        L("Users"),
                        url: "#users",
                        icon: "fa fa-users",
                        requiredPermissionName: PermissionNames.Pages_Users
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Roles",
                        L("Roles"),
                        url: "#users",
                        icon: "fa fa-tag",
                        requiredPermissionName: PermissionNames.Pages_Roles
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        "Products",
                        new LocalizableString("ProductBacklog", AgilizaScrumConsts.LocalizationSourceName),
                        url: "#products",
                        icon: "fa fa-tag"
                        //requiredPermissionName: PermissionNames.Pages_Roles
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        "Release",
                        new LocalizableString("ReleaseBacklog", AgilizaScrumConsts.LocalizationSourceName),
                        url: "#release",
                        icon: "fa fa-tag"
                    //requiredPermissionName: PermissionNames.Pages_Roles
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        "Sprints",
                        new LocalizableString("Sprints", AgilizaScrumConsts.LocalizationSourceName),
                        icon: "fa fa-info"
                        ).AddItem(
                        new MenuItemDefinition(
                            "SprintBacklog",
                            new LocalizableString("SprintBacklog", AgilizaScrumConsts.LocalizationSourceName),
                            url: "#sprintbacklog",
                            icon: "fa fa-users"
                            //requiredPermissionName: "SimpleTaskSystem.Permissions.UserManagement"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                            "SprintPlanning",
                            new LocalizableString("SprintPlanning", AgilizaScrumConsts.LocalizationSourceName),
                            url: "#sprintplanning",
                            icon: "fa fa-star"
                            //requiredPermissionName: "SimpleTaskSystem.Permissions.RoleManagement"
                            )
                        )
                )
                .AddItem(
                    new MenuItemDefinition(
                        "About",
                        new LocalizableString("About", AgilizaScrumConsts.LocalizationSourceName),
                        url: "#/about",
                        icon: "fa fa-info"
                        )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AgilizaScrumConsts.LocalizationSourceName);
        }
    }
}

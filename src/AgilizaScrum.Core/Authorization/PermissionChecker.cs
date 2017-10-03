using Abp.Authorization;
using AgilizaScrum.Authorization.Roles;
using AgilizaScrum.Authorization.Users;

namespace AgilizaScrum.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}

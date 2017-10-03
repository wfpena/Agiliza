using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using AgilizaScrum.Authorization.Users;
using AgilizaScrum.MultiTenancy;
using AgilizaScrum.Users;
using Microsoft.AspNet.Identity;

namespace AgilizaScrum
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class AgilizaScrumAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        protected AgilizaScrumAppServiceBase()
        {
            LocalizationSourceName = AgilizaScrumConsts.LocalizationSourceName;
        }

        protected virtual Task<User> GetCurrentUserAsync()
        {
            var user = UserManager.FindByIdAsync(AbpSession.GetUserId());
            if (user == null)
            {
                throw new ApplicationException("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
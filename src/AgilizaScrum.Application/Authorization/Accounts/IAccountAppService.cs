using System.Threading.Tasks;
using Abp.Application.Services;
using AgilizaScrum.Authorization.Accounts.Dto;

namespace AgilizaScrum.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}

using System.Threading.Tasks;
using Abp.Application.Services;
using AgilizaScrum.Sessions.Dto;

namespace AgilizaScrum.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}

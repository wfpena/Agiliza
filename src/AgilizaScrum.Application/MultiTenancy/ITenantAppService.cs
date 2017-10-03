using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AgilizaScrum.MultiTenancy.Dto;

namespace AgilizaScrum.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

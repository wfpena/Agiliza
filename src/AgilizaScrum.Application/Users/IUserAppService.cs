using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AgilizaScrum.Roles.Dto;
using AgilizaScrum.Users.Dto;

namespace AgilizaScrum.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UpdateUserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}
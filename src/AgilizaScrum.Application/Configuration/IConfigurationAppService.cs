using System.Threading.Tasks;
using Abp.Application.Services;
using AgilizaScrum.Configuration.Dto;

namespace AgilizaScrum.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
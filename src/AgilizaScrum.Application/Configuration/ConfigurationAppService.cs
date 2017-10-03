using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using AgilizaScrum.Configuration.Dto;

namespace AgilizaScrum.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : AgilizaScrumAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}

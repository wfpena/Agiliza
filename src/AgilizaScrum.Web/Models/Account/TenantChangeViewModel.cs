using Abp.AutoMapper;
using AgilizaScrum.Sessions.Dto;

namespace AgilizaScrum.Web.Models.Account
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
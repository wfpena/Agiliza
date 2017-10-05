using Abp.Application.Services;
using AgilizaScrum.ReleaseBacklog.Dtos;
using System.Collections.Generic;

namespace AgilizaScrum.ReleaseBacklog
{
    public interface IReleaseBackAppService : IApplicationService
    {
        List<ReleaseBackDto> GetAll();
        ReleaseBackDto Get(int id);
        int CreateRelease(ReleaseBackDto input);
    }
}

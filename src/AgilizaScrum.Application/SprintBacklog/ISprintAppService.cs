using Abp.Application.Services;
using AgilizaScrum.SprintBacklog.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilizaScrum.SprintBacklog
{
    public interface ISprintAppService : IApplicationService
    {
        List<SprintDto> GetAll();
        SprintDto Get(int id);
        int CreateSprint(SprintDto input);
    }
}

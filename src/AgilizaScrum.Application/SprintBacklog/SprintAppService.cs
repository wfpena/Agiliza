using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgilizaScrum.SprintBacklog.Dtos;
using AutoMapper;

namespace AgilizaScrum.SprintBacklog
{
    public class SprintAppService : ApplicationService, ISprintAppService
    {
        private readonly ISprintRepository _sprintRepository;

        public SprintAppService(ISprintRepository sprintRepository)
        {
            _sprintRepository = sprintRepository;
        }

        #region CRUD
        public List<SprintDto> GetAll()
        {
            var products = _sprintRepository.GetAll().ToList();
            return Mapper.Map<List<SprintDto>>(products);
        }

        public SprintDto Get(int id)
        {
            var sprint = _sprintRepository.Get(id);
            return Mapper.Map<SprintDto>(sprint);
        }

        public int CreateSprint(SprintDto input)
        {
            var product = new Sprint { Name = input.Name, Description = input.Description , TenantId = AbpSession.TenantId };

            return _sprintRepository.InsertAndGetId(product);
        }

        #endregion

    }
}

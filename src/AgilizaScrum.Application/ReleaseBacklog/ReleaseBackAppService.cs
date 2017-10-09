using Abp.Application.Services;
using AgilizaScrum.ReleaseBacklog.Dtos;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace AgilizaScrum.ReleaseBacklog
{
    public class ReleaseBackAppService : ApplicationService , IReleaseBackAppService
    {
        private readonly IReleaseBackRepository _releaseRepository;

        public ReleaseBackAppService(IReleaseBackRepository releaseRepository)
        {
            _releaseRepository = releaseRepository;
        }

        #region CRUDProductBacklog
        public List<ReleaseBackDto> GetAll()
        {
            var products = _releaseRepository.GetAll().ToList();
            return Mapper.Map<List<ReleaseBackDto>>(products);
        }

        public ReleaseBackDto Get(int id)
        {
            var product = _releaseRepository.Get(id);
            return Mapper.Map<ReleaseBackDto>(product);
        }

        public int CreateRelease(ReleaseBackDto input)
        {
            //We can use Logger, it's defined in ApplicationService class.
            Logger.Info("Creating a task for input: " + input);

            var product = new ReleaseBack { Name = input.Name, Description = input.Description, ProductBackId = input.ProductBackId, Priority = input.Priority };

            return _releaseRepository.InsertAndGetId(product);
        }

        #endregion

    }
}

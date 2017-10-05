using Abp.Application.Services;
using AgilizaScrum.ProductBacklog.Dtos;
using AgilizaScrum.UserStories;
using AgilizaScrum.UserStories.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilizaScrum.ProductBacklog
{
    public class ProductBackAppService : ApplicationService , IProductBackAppService
    {
        private readonly IProductBackRepository _prodRepository;
        private readonly IUserStoryRepository _storyRepository;

        public ProductBackAppService(IProductBackRepository prodRepository, IUserStoryRepository storyRepository)
        {
            _prodRepository = prodRepository;
            _storyRepository = storyRepository;
        }

        #region CRUDProductBacklog
        public List<ProductBackDto> GetAll()
        {
            var products = _prodRepository.GetAll().ToList();
            return Mapper.Map<List<ProductBackDto>>(products);
        }

        public ProductBackDto Get(int id)
        {
            var product = _prodRepository.Get(id);
            return Mapper.Map<ProductBackDto>(product);
        }

        public void CreateProduct(ProductBackDto input)
        {
            //We can use Logger, it's defined in ApplicationService class.
            Logger.Info("Creating a task for input: " + input);

            var product = new ProductBack { Name = input.Name, Description = input.Description };

            //Saving entity with standard Insert method of repositories.
            _prodRepository.Insert(product);
        }

        #endregion
    }
}

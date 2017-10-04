using Abp.Application.Services;
using AgilizaScrum.ProductBacklog.Dtos;
using AgilizaScrum.UserStories;
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

        #region CRUD ProductBacklog
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

        #region User Story
        public List<UserStoryDto> GetAllStories(int id)
        {
            var stories = _storyRepository.GetAll().Where(i => i.ProductBackId == id). ToList();
            return Mapper.Map<List<UserStoryDto>>(stories);
        }

        public UserStoryDto GetUserStory(int id)
        {
            var story = _storyRepository.Get(id);
            return Mapper.Map<UserStoryDto>(story);
        }

        public void CreateStory(UserStoryDto input)
        {
            //We can use Logger, it's defined in ApplicationService class.
            Logger.Info("Creating a task for input: " + input);

            var story = new UserStory { Name = input.Name, Description = input.Description };

            //Saving entity with standard Insert method of repositories.
            _storyRepository.Insert(story);
        }

        #endregion
    }
}

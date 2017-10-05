using Abp.Application.Services;
using AgilizaScrum.UserStories.Dtos;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace AgilizaScrum.UserStories
{
    public class UserStoryAppService : ApplicationService , IUserStoryAppService
    {
        private readonly IUserStoryRepository _storyRepository;

        public UserStoryAppService(IUserStoryRepository storyRepository)
        {
            _storyRepository = storyRepository;
        }

        #region UserStory
        public List<UserStoryDto> GetStories(int id)
        {
            var stories = _storyRepository.GetAll().Where(i => i.ProductBackId == id).ToList();
            return Mapper.Map<List<UserStoryDto>>(stories);
        }

        public List<UserStoryDto> GetCreatedStories(int id)
        {
            var stories = _storyRepository.GetAll().Where(i => i.ProductBackId == id && i.State == ProductBacklog.eState.Created).ToList();
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

            var story = new UserStory { Name = input.Name, Description = input.Description , ProductBackId = input.ProductBackId };
           
            _storyRepository.Insert(story);
        }

        public void UpdateStory(UserStoryDto input)
        {
            var story = _storyRepository.Get(input.Id);

            story.Name = input.Name;
            story.Description = input.Description;
        }

        public void DeleteStory(int id)
        {
            _storyRepository.Delete(id);
        }

        #endregion

        public void ReleasedState(List<UserStoryDto> input)
        {
            foreach(var story in input)
            {
                var st = _storyRepository.Get(story.Id);
                st.State = ProductBacklog.eState.Released;
                st.ReleaseBackId = story.ReleaseBackId;
            }
        }
    }
}

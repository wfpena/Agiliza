using Abp.Application.Services;
using AgilizaScrum.UserStories.Dtos;
using System;
using System.Collections.Generic;

namespace AgilizaScrum.UserStories
{
    public interface IUserStoryAppService : IApplicationService
    {
        UserStoryDto GetUserStory(int id);
        List<UserStoryDto> GetStories(int id);
        List<UserStoryDto> GetStoriesRelease(int id);
        List<UserStoryDto> GetCreatedStories(int id);
        void ReleasedState(List<UserStoryDto> input, int releaseId);
        void CreateStory(UserStoryDto input);
        void UpdateStory(UserStoryDto input);
        void DeleteStory(int id);

    }
}

using Abp.EntityFramework;
using AgilizaScrum.ProductBacklog;
using AgilizaScrum.UserStories;

namespace AgilizaScrum.EntityFramework.Repositories
{
    public class UserStoryRepository : AgilizaScrumRepositoryBase<UserStory> , IUserStoryRepository
    {
        public UserStoryRepository(IDbContextProvider<AgilizaScrumDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}

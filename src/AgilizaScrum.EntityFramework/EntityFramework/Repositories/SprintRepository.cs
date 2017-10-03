using Abp.EntityFramework;
using AgilizaScrum.ProductBacklog;
using AgilizaScrum.SprintBacklog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilizaScrum.EntityFramework.Repositories
{
    public class SprintRepository : AgilizaScrumRepositoryBase<Sprint> , ISprintRepository
    {
        public SprintRepository(IDbContextProvider<AgilizaScrumDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}

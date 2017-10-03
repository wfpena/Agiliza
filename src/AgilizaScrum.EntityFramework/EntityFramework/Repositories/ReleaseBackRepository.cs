using Abp.EntityFramework;
using AgilizaScrum.ProductBacklog;
using AgilizaScrum.ReleaseBacklog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilizaScrum.EntityFramework.Repositories
{
    public class ReleaseBackRepository : AgilizaScrumRepositoryBase<ReleaseBack> , IReleaseBackRepository
    {
        public ReleaseBackRepository(IDbContextProvider<AgilizaScrumDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}

using Abp.EntityFramework;
using AgilizaScrum.ProductBacklog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilizaScrum.EntityFramework.Repositories
{
    public class ProductBackRepository : AgilizaScrumRepositoryBase<ProductBack> , IProductBackRepository
    {
        public ProductBackRepository(IDbContextProvider<AgilizaScrumDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}

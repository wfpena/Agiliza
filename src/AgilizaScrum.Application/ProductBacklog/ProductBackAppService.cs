using Abp.Application.Services;
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

        public ProductBackAppService(IProductBackRepository prodRepository)
        {
            _prodRepository = prodRepository;
        }
    }
}

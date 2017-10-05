using Abp.Application.Services;
using AgilizaScrum.ProductBacklog.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilizaScrum.ProductBacklog
{
    public interface IProductBackAppService : IApplicationService
    {
        List<ProductBackDto> GetAll();
        ProductBackDto Get(int id);
        void CreateProduct(ProductBackDto input);
    }
}

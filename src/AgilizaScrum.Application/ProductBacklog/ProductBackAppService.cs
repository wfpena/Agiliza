using Abp.Application.Services;
using AgilizaScrum.ProductBacklog.Dtos;
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

        public ProductBackAppService(IProductBackRepository prodRepository)
        {
            _prodRepository = prodRepository;
        }

        public void CreateProduct(ProductBackDto input)
        {
            //We can use Logger, it's defined in ApplicationService class.
            Logger.Info("Creating a task for input: " + input);

            var product = new ProductBack { Name = input.Name, Description = input.Description };

            //Saving entity with standard Insert method of repositories.
            _prodRepository.Insert(product);
        }

        public List<ProductBackDto> GetAll()
        {
            var products = _prodRepository.GetAll().ToList();
            return Mapper.Map<List<ProductBackDto>>(products); 
        }
    }
}

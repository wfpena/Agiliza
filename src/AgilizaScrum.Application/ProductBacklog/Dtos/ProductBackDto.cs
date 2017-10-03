using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilizaScrum.ProductBacklog.Dtos
{
    public class ProductBackDto : EntityDto
    {
        public String Name { get; set; }
        public String Description { get; set; }
    }
}

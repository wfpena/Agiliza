using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilizaScrum.ReleaseBacklog.Dtos
{
    public class ReleaseBackDto : EntityDto
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public int ProductBackId { get; set; }
    }
}

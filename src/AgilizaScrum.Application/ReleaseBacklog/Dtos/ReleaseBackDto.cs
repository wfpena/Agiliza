using Abp.Application.Services.Dto;
using AgilizaScrum.enums;
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
        public ePriority Priority { get; set; }
        public int ProductBackId { get; set; }
    }
}

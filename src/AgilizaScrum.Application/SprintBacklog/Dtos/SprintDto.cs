using Abp.Application.Services.Dto;
using AgilizaScrum.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilizaScrum.SprintBacklog.Dtos
{
    public class SprintDto : EntityDto
    {
        public String Name { get; set; }
        public String Description { get; set; }
    }
}

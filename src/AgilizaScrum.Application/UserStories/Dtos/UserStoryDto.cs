using Abp.Application.Services.Dto;
using AgilizaScrum.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilizaScrum.UserStories.Dtos
{
    public class UserStoryDto : EntityDto
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public int OwnerPriority { get; set; }
        public ePriority DeveloperPriority { get; set; }
        public int ProductBackId { get; set; }
        public int? ReleaseBackId { get; set; }
    }
}

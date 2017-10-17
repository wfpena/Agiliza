using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using AgilizaScrum.enums;
using AgilizaScrum.ProductBacklog;
using AgilizaScrum.ReleaseBacklog;
using AgilizaScrum.SprintBacklog;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgilizaScrum.UserStories
{
    public class UserStory : Entity , IHasCreationTime , IMayHaveTenant
    {
        public virtual String Name { get; set; }
        public virtual String Description { get; set; }
        public virtual int OwnerPriority { get; set; }
        public virtual ePriority DeveloperPriority { get; set; }
        public virtual DateTime CreationTime { get; set; }
        public virtual eState State { get; set; }

        public virtual ProductBack ParentProductBack { get; set; }
        [ForeignKey("ParentProductBack")]
        public virtual int ProductBackId { get; set; }

        public virtual ReleaseBack ParentReleaseBack { get; set; }
        [ForeignKey("ParentReleaseBack")]
        public virtual int? ReleaseBackId { get; set; }

        public virtual Sprint ParentSprint { get; set; }
        [ForeignKey("ParentSprint")]
        public virtual int? SprintId { get; set; }

        public int? TenantId { get; set; }

        public UserStory()
        {
            CreationTime = DateTime.Now;
            State = eState.Created;

        }
    }
}

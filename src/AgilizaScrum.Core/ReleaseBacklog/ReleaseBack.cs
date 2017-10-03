﻿using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using AgilizaScrum.ProductBacklog;
using AgilizaScrum.SprintBacklog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilizaScrum.ReleaseBacklog
{
    public class ReleaseBack : Entity , IHasCreationTime
    {
        public virtual String Name { get; set; }
        public virtual String Description { get; set; }
        public virtual DateTime CreationTime { get; set; }
        public virtual eState State { get; set; }

        public virtual ProductBack ParentProductBack { get; set; }
        [ForeignKey("ParentProductBack")]
        public virtual int ProductBackId { get; set; }

        public virtual ICollection<Sprint> Sprints { get; set; }

        public ReleaseBack()
        {
            CreationTime = DateTime.Now;
            State = eState.Active;

        }

    }
}

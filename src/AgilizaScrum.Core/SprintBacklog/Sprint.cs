﻿using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using AgilizaScrum.ProductBacklog;
using AgilizaScrum.ReleaseBacklog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilizaScrum.SprintBacklog
{
    public class Sprint : Entity , IHasCreationTime
    {
        public virtual String Name { get; set; }
        public virtual String Description { get; set; }
        public virtual DateTime CreationTime { get; set; }
        public virtual eState State { get; set; }

        public virtual ReleaseBack ParentReleaseBack { get; set; }
        [ForeignKey("ParentReleaseBack")]
        public virtual int ReleaseBackId { get; set; }
        

        public Sprint()
        {
            CreationTime = DateTime.Now;
            State = eState.Active;
        }
    }
}

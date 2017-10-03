﻿using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using AgilizaScrum.SprintBacklog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilizaScrum.ProductBacklog
{
    public class ProductBack : Entity , IHasCreationTime
    {
        public virtual String Name { get; set; }
        public virtual String Description { get; set; }
        public virtual DateTime CreationTime { get; set; }
        public virtual eState State { get; set; }



        public virtual ICollection<Sprint> Sprints { get; set; }

        public ProductBack()
        {
            CreationTime = DateTime.Now;
            State = eState.Active;

        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilizaScrum.ProductBacklog
{
    public enum eState : byte
    {
        None = 0,

        /// <summary>
        /// The task is active.
        /// </summary>
        Active = 1,

        /// <summary>
        /// The task is on hold.
        /// </summary>
        OnHold = 2,

        /// <summary>
        /// The task is completed.
        /// </summary>
        Completed = 3
    }
}

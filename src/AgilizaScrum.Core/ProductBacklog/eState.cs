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
        Created = 1,
        Released = 2,
        Active = 3,
        Completed = 4
    }
}

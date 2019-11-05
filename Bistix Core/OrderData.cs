using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bistix_Core
{

    class OrderData : IorderData
    {
        public void Sync() { }
        public bool IsSynced { get; internal set; }


    }
}

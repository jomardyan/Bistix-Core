
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bistix_Core
{

interface IorderData
    {
        bool IsSynced { get; set; } 
        void Sync();
        void Config(string provider);
        void Get(string FiatCurency, string CryptoCurency);
        
    }
}
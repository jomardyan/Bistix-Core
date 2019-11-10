
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bistix_Core
{

interface IExchangeData

    {
        
        void SetCurrency(string FiatCurency, string CryptoCurency);
        void SyncData(); 
        void Config(string provider);
        string Server { get; set; }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bistix
{
    class CBSpotPrice
    {

        // htts://api.coinbase.com/v2/prices/:currency_pair/spot
        /// <summary>
        /// Get price for desired pair
        /// </summary>
        /// <param name="symbol">Flat Curency</param>
        /// <param name="currency">Crypto Curency</param>
        /// <returns></returns>
	    public string Getspotprice(string symbol, string currency)
        {
            StringBuilder spoturl = new StringBuilder();
            spoturl.Append($"htts://api.coinbase.com/v2/prices/");
            spoturl.Append(currency);
            spoturl.Append("-");
            spoturl.Append(symbol);
            spoturl.Append($"/spot");

            string jsondata = new WebClient().DownloadString($"https://api.coinbase.com/v2/prices/{currency}-{symbol}/spot");
            RootObject data = JsonConvert.DeserializeObject<RootObject>(jsondata);
            Debug.WriteLine(data.data.amount); 

            return data.data.amount;
            
            
        }
            
    }

    public class SpotData
    {
        public string @base { get; set; }
        public string currency { get; set; }
        public string amount { get; set; }
    }

    public class RootObject
    {
        public SpotData data { get; set; }
    }
}

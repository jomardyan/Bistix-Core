using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bistix
{
    class CBSpotPrice
    {

        // htts://api.coinbase.com/v2/prices/:currency_pair/spot
	    string Getspotprice(string symbol, string currency)
        {
            string jsondata = new WebClient().DownloadString($"htts://api.coinbase.com/v2/prices/{currency}-{symbol}/spot");
            SpotData data = JsonConvert.DeserializeObject<SpotData>(jsondata);

            return data.amount;
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

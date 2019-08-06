using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Bistix_Core
{
    internal class FastSellPrice
    {
        public void GetEURBTC(TextBlock textblock)

        {
            try
            {
                string jsondata = new WebClient().DownloadString("https://api.coinbase.com/v2/prices/sell?currency=EUR");
                RootObject data = JsonConvert.DeserializeObject<RootObject>(jsondata);
                textblock.Text = data.data.amount;
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }

    public class Data1
    {
        public string @base { get; set; }
        public string currency { get; set; }
        public string amount { get; set; }
    }

    public class RootObject
    {
        public Data1 data { get; set; }
    }
}
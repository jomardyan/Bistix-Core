using Newtonsoft.Json;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Text;
using System.Collections;

using System;

namespace Bistix_Core
{
    internal class FastSellPrice
    {
        public double BTCPRICE;
        public double LTCPRICE;
        
        

        public void  GetAndSetBTCEUR(TextBlock textblock)

        {
            
            try
            {
                string jsondata = new WebClient().DownloadString("https://api.coinbase.com/v2/prices/BTC-EUR/sell");
                RootObject data = JsonConvert.DeserializeObject<RootObject>(jsondata);
                textblock.Text = data.data.amount;
                BTCPRICE = double.Parse(data.data.amount);



            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }

            
            
        }

        public void  GetAndSetLTCEUR(TextBlock textblock)

        {
            try
            {
                string jsondata = new WebClient().DownloadString("https://api.coinbase.com/v2/prices/LTC-EUR/sell");
                RootObject data = JsonConvert.DeserializeObject<RootObject>(jsondata);
                textblock.Text =data.data.amount;
                LTCPRICE = double.Parse(data.data.amount);

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
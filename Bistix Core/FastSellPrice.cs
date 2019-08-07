using Newtonsoft.Json;
using System.Net;
using System.Windows;
using System.Windows.Controls;

namespace Bistix_Core
{
    internal class FastSellPrice
    {
        public void GetAndSetBTCEUR(TextBlock textblock)

        {
            try
            {
                string jsondata = new WebClient().DownloadString("https://api.coinbase.com/v2/prices/BTC-EUR/sell");
                RootObject data = JsonConvert.DeserializeObject<RootObject>(jsondata);
                textblock.Text = data.data.amount.ToString();
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void GetAndSetLTCEUR(TextBlock textblock)

        {
            try
            {
                string jsondata = new WebClient().DownloadString("https://api.coinbase.com/v2/prices/LTC-EUR/sell");
                RootObject data = JsonConvert.DeserializeObject<RootObject>(jsondata);
                textblock.Text =data.data.amount.ToString();
                
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
        public int amount { get; set; }
    }

    public class RootObject
    {
        public Data1 data { get; set; }
    }
}
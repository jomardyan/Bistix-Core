using Newtonsoft.Json;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Text;
using System.Collections;

using System;
using System.Windows.Media;

namespace Bistix_Core
{
    internal class FastGetSellPrice
    {
        //EUR
        public double BTCEURPRICE;
        public double LTCEURPRICE;
        //USD
        public double BTCUSDPRICE;
        public double LTCUSDPRICE;



        public void  GetPrice(TextBlock textblock, string crypto, string currency)

        {
            
            try
            {
                string jsondata = new WebClient().DownloadString($"https://api.coinbase.com/v2/prices/{crypto}-{currency}/sell");
                CoinBaseMainData data = JsonConvert.DeserializeObject<CoinBaseMainData>(jsondata);

                if (currency == "USD")
                {
                    textblock.Text = data.data.amount + " $";

                }
                else if (currency == "EUR")
                {
                    textblock.Text = data.data.amount + " €";
                }


                //Set Price Property

                if (crypto == "BTC" & currency =="EUR" )
                {
                    BTCEURPRICE = double.Parse(data.data.amount);
                }
                else if (crypto == "LTC" & currency == "EUR")
                {
                    LTCEURPRICE = double.Parse(data.data.amount);

                }
                else if (crypto == "BTC" & currency == "USD")
                {
                    BTCUSDPRICE = double.Parse(data.data.amount);
                }
                else if (crypto == "LTC" & currency == "USD")
                {
                    LTCUSDPRICE = double.Parse(data.data.amount);
                }


            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }

            
            
        }


        public void SetArrow(MahApps.Metro.IconPacks.PackIconModern icon, double LastPrice, double NewPrice)
        {
            if (LastPrice > NewPrice)
            {
                SolidColorBrush ColorBrush = new SolidColorBrush();
                ColorBrush.Color = Color.FromRgb(235, 64, 52);
                icon.Foreground = ColorBrush;
                icon.Kind = MahApps.Metro.IconPacks.PackIconModernKind.ArrowDown;
            }
            else if (LastPrice < NewPrice)
            {
                SolidColorBrush ColorBrush = new SolidColorBrush();
                ColorBrush.Color = Color.FromRgb(52, 235, 76);
                icon.Foreground = ColorBrush;
                icon.Kind = MahApps.Metro.IconPacks.PackIconModernKind.ArrowUp;
            }


        }

    }

    public class CoinBaseData
    {
        public string @base { get; set; }
        public string currency { get; set; }
        public string amount { get; set; }
    }

    public class CoinBaseMainData
    {
        public CoinBaseData data { get; set; }
    }
}
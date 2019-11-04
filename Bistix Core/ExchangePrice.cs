using Newtonsoft.Json;
using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Bistix_Core
{
    public class ExchangePrice
    {
        internal decimal  BTCEURPRICE;
        internal decimal  LTCEURPRICE;
        internal decimal  BTCUSDPRICE;
        internal decimal  LTCUSDPRICE;
        

        /* public string GetPriceBTC(string currency)

        {
            try
            {
                string jsondata = new WebClient().DownloadString("https://api.coinbase.com/v2/exchange-rates?currency=BTC");
                btcrate RateData = JsonConvert.DeserializeObject<btcrate>(jsondata);
                string value = "";
                switch (currency)
                {
                    case "EUR":
                        value = RateData.data.rates.EUR;
                        break;

                    case "USD":
                        value = RateData.data.rates.USD;
                        break;

                    case "PLN":

                        value = RateData.data.rates.PLN;
                        break;
                }
                return value;
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return "";
        }

        public string GetPriceLTC(string currency)

        {
            try
            {
                string jsondata = new WebClient().DownloadString("https://api.coinbase.com/v2/exchange-rates?currency=LTC");
                btcrate RateData = JsonConvert.DeserializeObject<btcrate>(jsondata);

                string value = "";
                switch (currency)
                {
                    case "EUR":
                        value = RateData.data.rates.EUR;
                        break;

                    case "USD":
                        value = RateData.data.rates.USD;
                        break;

                    case "PLN":

                        value = RateData.data.rates.PLN;
                        break;
                }
                return value;
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return "";
        }
        */

        public void GetPrice(TextBlock textblock, string crypto, string currency)

        {
            try
            {
                string jsondata = new WebClient().DownloadString($"https://api.coinbase.com/v2/exchange-rates?currency={crypto}");
                btcrate data = JsonConvert.DeserializeObject<btcrate>(jsondata);

                if (currency == "USD")
                {
                    textblock.Text = Math.Round(data.data.rates.USD, 2) + " $";
                }
                else if (currency == "EUR")
                {
                    textblock.Text = Math.Round(data.data.rates.EUR, 2) + " €";
                }

                //Set Price Property

                if (crypto == "LTC")
                {
                    LTCEURPRICE = (decimal)Math.Round(data.data.rates.EUR, 2);
                    LTCUSDPRICE = (decimal)Math.Round(data.data.rates.USD, 2);
                }
                else if (true)
                {
                    BTCEURPRICE = (decimal)Math.Round(data.data.rates.EUR, 2);
                    BTCUSDPRICE = (decimal)Math.Round(data.data.rates.USD, 2);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void SetArrow(MahApps.Metro.IconPacks.PackIconModern icon, decimal LastPrice, decimal NewPrice, out decimal tbtext)
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
            tbtext = NewPrice;
        }
    }
}
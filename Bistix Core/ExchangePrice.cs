using Newtonsoft.Json;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Bistix_Core
{
    public class ExchangePrice
    {
        internal double BTCEURPRICE;
        internal double LTCEURPRICE;
        internal double BTCUSDPRICE;
        internal double LTCUSDPRICE;

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
            string jsondata = new WebClient().DownloadString($"https://api.coinbase.com/v2/exchange-rates?currency={crypto}");

            btcrate data = JsonConvert.DeserializeObject<btcrate>(jsondata);

            if (currency == "USD")
            {
                textblock.Text = data.data.rates.USD + " $";
            }
            else if (currency == "EUR")
            {
                textblock.Text = data.data.rates.EUR + " €";
            }

            //Set Price Property

            if (crypto == "LTC")
            {
                LTCEURPRICE = data.data.rates.EUR;
                LTCUSDPRICE = data.data.rates.USD;
            }
            else if (true)
            {
                BTCEURPRICE = data.data.rates.EUR;
                BTCUSDPRICE = data.data.rates.USD;
            }
        }

        public void SetArrow(MahApps.Metro.IconPacks.PackIconModern icon, double LastPrice, double NewPrice, out double tbtext)
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
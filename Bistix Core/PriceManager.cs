using Newtonsoft.Json;
using System.Net;
using System.Windows;
using System.Windows.Controls;

namespace Bistix_Core
{
    public class PriceManager
    {
        public string GetPriceBTC(string currency)

        {
            try
            {
                string jsondata = new WebClient().DownloadString("https://api.coinbase.com/v2/exchange-rates?currency=BTC");
                btcrate data = JsonConvert.DeserializeObject<btcrate>(jsondata);
                string value = "";
                switch (currency)
                {
                    case "EUR":
                        value = data.data.rates.EUR;
                        break;

                    case "USD":
                        value = data.data.rates.USD;
                        break;

                    case "PLN":

                        value = data.data.rates.PLN;
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
                btcrate data = JsonConvert.DeserializeObject<btcrate>(jsondata);

                string value = "";
                switch (currency)
                {
                    case "EUR":
                        value = data.data.rates.EUR;
                        break;

                    case "USD":
                        value = data.data.rates.USD;
                        break;

                    case "PLN":

                        value = data.data.rates.PLN;
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

        public void SetPrice(TextBlock box, string symbol, string curency)
        {
            box.Text = GetPriceBTC("EUR");
        }

        public void SetPrice(TextBlock box)
        {
            box.Text = GetPriceBTC("EUR");
        }
    }
}
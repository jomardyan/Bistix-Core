using Newtonsoft.Json;
using System.Net;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Media;

namespace Bistix
{
    internal class FastGetSellPriceCoinbase
    {
        //EUR
        public double Btceurprice;

        public double Ltceurprice;

        //USD
        public double Btcusdprice;

        public double Ltcusdprice;

        public void GetPrice(TextBlock textblock, string crypto, string currency)

        {
            string className = MethodBase.GetCurrentMethod().DeclaringType.Name;

            string jsondata = new WebClient().DownloadString($"https://api.coinbase.com/v2/prices/{crypto}-{currency}/sell");

            CoinBaseMainData data = JsonConvert.DeserializeObject<CoinBaseMainData>(jsondata);

            if (currency == "USD")
            {
                textblock.Text = data.Data.Amount + " $";
            }
            else if (currency == "EUR")
            {
                textblock.Text = data.Data.Amount + " €";
            }

            //Set Price Property

            if (crypto == "BTC" & currency == "EUR")
            {
                Btceurprice = data.Data.Amount;
            }
            else if (crypto == "LTC" & currency == "EUR")
            {
                Ltceurprice = data.Data.Amount;
            }
            else if (crypto == "BTC" & currency == "USD")
            {
                Btcusdprice = data.Data.Amount;
            }
            else if (crypto == "LTC" & currency == "USD")
            {
                Ltcusdprice = data.Data.Amount;
            }
        }

        public void SetArrow(MahApps.Metro.IconPacks.PackIconModern icon, double lastPrice, double newPrice, out double tbtext)
        {
            if (lastPrice > newPrice)
            {
                SolidColorBrush colorBrush = new SolidColorBrush();
                colorBrush.Color = Color.FromRgb(235, 64, 52);
                icon.Foreground = colorBrush;
                icon.Kind = MahApps.Metro.IconPacks.PackIconModernKind.ArrowDown;
            }
            else if (lastPrice < newPrice)
            {
                SolidColorBrush colorBrush = new SolidColorBrush();
                colorBrush.Color = Color.FromRgb(52, 235, 76);
                icon.Foreground = colorBrush;
                icon.Kind = MahApps.Metro.IconPacks.PackIconModernKind.ArrowUp;
            }
            tbtext = newPrice;
        }
    }

    public class CoinBaseData
    {
        public string Base { get; set; }
        public string Currency { get; set; }
        public double Amount { get; set; }
    }

    public class CoinBaseMainData
    {
        public CoinBaseData Data { get; set; }
    }
}
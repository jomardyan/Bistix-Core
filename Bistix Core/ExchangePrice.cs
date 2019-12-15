using Newtonsoft.Json;
using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Bistix
{
    public class ExchangePrice
    {
        internal decimal  Btceurprice;
        internal decimal  Ltceurprice;
        internal decimal  Btcusdprice;
        internal decimal  Ltcusdprice;

        public void GetPrice(TextBlock textblock, string crypto, string currency)

        {
            try
            {
                string jsondata = new WebClient().DownloadString($"https://api.coinbase.com/v2/exchange-rates?currency={crypto}");
                Btcrate data = JsonConvert.DeserializeObject<Btcrate>(jsondata);

                if (currency == "USD")

                {
                    textblock.Text = Math.Round(data.Data.Rates.Usd, 2) + " $";
                }
                else if (currency == "EUR")
                {
                    textblock.Text = Math.Round(data.Data.Rates.Eur, 2) + " €";
                }

                //Set Price Property

                if (crypto == "LTC")
                {
                    Ltceurprice = (decimal)Math.Round(data.Data.Rates.Eur, 2);
                    Ltcusdprice = (decimal)Math.Round(data.Data.Rates.Usd, 2);
                }
                else if (true)
                {
                    Btceurprice = (decimal)Math.Round(data.Data.Rates.Eur, 2);
                    Btcusdprice = (decimal)Math.Round(data.Data.Rates.Usd, 2);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void SetArrow(MahApps.Metro.IconPacks.PackIconModern icon, decimal lastPrice, decimal newPrice, out decimal tbtext)
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
}
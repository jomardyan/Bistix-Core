using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Bistix_Core
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double btceurval = 0;
        private double ltceurval = 0;
        private double btcusdval = 0;
        private double ltcusdval = 0;

        public MainWindow()
        {
            InitializeComponent();

            #region Time-Tick

            DispatcherTimer TimeTimer = new System.Windows.Threading.DispatcherTimer();
            TimeTimer.Tick += new EventHandler(TimeTimer_Tick);
            TimeTimer.Interval = new TimeSpan(0, 0, 1);
            TimeTimer.Start();

            #endregion Time-Tick

            FastGetSellPriceCoinbase pricex = new FastGetSellPriceCoinbase();
            Task[] task = new Task[1];
            pricex.GetPrice(BTCEUR_VAL, "BTC", "EUR");
            pricex.GetPrice(LTCEURVAL, "LTC", "EUR");
            pricex.GetPrice(BTCUSD_VAL, "BTC", "USD");
            pricex.GetPrice(LTCUSDVAL, "LTC", "USD");

            void TimeTimer_Tick(object sender, EventArgs e)
            {
                TimeBOX.Text = DateTime.Now.ToLongTimeString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void TagleRefreshData_Checked(object sender, RoutedEventArgs e)
        {
            #region Price-Tick

            DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 2);
            dispatcherTimer.Start();

            #endregion Price-Tick
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            FastGetSellPriceCoinbase price = new FastGetSellPriceCoinbase();
            price.GetPrice(BTCEUR_VAL, "BTC", "EUR");
            price.SetArrow(BTCEURARROW, btceurval, price.BTCEURPRICE);
            price.GetPrice(LTCEURVAL, "LTC", "EUR");
            price.SetArrow(LTCARROW, ltceurval, price.LTCEURPRICE);
            price.GetPrice(BTCUSD_VAL, "BTC", "USD");
            price.SetArrow(BTCUSDARROW, btcusdval, price.BTCUSDPRICE);
            price.GetPrice(LTCUSDVAL, "LTC", "USD");
            price.SetArrow(LTCUSDARROW, ltcusdval, price.LTCUSDPRICE);

            btceurval = price.BTCEURPRICE;
            ltceurval = price.LTCEURPRICE;
            btcusdval = price.BTCUSDPRICE;
            ltcusdval = price.LTCUSDPRICE;
        }
    }
}
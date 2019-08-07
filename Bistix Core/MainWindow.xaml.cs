using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace Bistix_Core
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            double btceurval = 0;
            double ltceurval = 0;
            double btcusdval = 0;
            double ltcusdval = 0;


            InitializeComponent();

            #region Price-Tick 
            DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);

            dispatcherTimer.Interval = new TimeSpan(0, 0, 2);
            dispatcherTimer.Start();
            #endregion

            #region Time-Tick 
            DispatcherTimer TimeTimer = new System.Windows.Threading.DispatcherTimer();
            TimeTimer.Tick += new EventHandler(TimeTimer_Tick);
            TimeTimer.Interval = new TimeSpan(0, 0, 1);
            TimeTimer.Start();
            #endregion

            FastSellPrice pricex = new FastSellPrice();
            pricex.GetPrice(BTCEUR_VAL,"BTC", "EUR");
            pricex.GetPrice(LTCEURVAL, "LTC", "EUR");
            pricex.GetPrice(BTCUSD_VAL, "BTC", "USD");
            pricex.GetPrice(LTCUSDVAL, "LTC", "USD");

            void dispatcherTimer_Tick(object sender, EventArgs e)
            {
                
                

                FastSellPrice price = new FastSellPrice();
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

            void TimeTimer_Tick(object sender, EventArgs e)
            {

                TimeBOX.Text = DateTime.Now.ToString();
               
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
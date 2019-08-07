using System;
using System.Windows;
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
            int btcval = 0;
            int ltcval = 0;

            InitializeComponent();

            DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 3);
            dispatcherTimer.Start();

            DispatcherTimer TimeTimer = new System.Windows.Threading.DispatcherTimer();
            TimeTimer.Tick += new EventHandler(TimeTimer_Tick);
            TimeTimer.Interval = new TimeSpan(0, 0, 1);
            TimeTimer.Start();

            FastSellPrice pricex = new FastSellPrice();
            pricex.GetAndSetBTCEUR(BTC_VAL);
            pricex.GetAndSetLTCEUR(LTC_VAL);
            

            void dispatcherTimer_Tick(object sender, EventArgs e)
            {
                FastSellPrice price = new FastSellPrice();
                price.GetAndSetBTCEUR(BTC_VAL);
                price.GetAndSetLTCEUR(LTC_VAL);
                

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
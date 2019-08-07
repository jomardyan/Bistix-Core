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
            InitializeComponent();

            DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 2);
            dispatcherTimer.Start();

            void dispatcherTimer_Tick(object sender, EventArgs e)
            {
                // lblSeconds.Content = DateTime.Now.Second;
                FastSellPrice price = new FastSellPrice();
                price.GetAndSetBTCEUR(BTC_VAL);
                price.GetAndSetLTCEUR(LTC_VAL);

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
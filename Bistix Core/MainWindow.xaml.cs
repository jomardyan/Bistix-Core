using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
        private DispatcherTimer dispatcherTimer = new DispatcherTimer();

        public int GetSliderValue()
        {
            return (int)IntervalSlider.Value;
        }

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
            ExchangePrice exchange = new ExchangePrice();
            exchange.GetPrice(BTCEUR_VAL, "BTC", "EUR");
            exchange.GetPrice(LTCEURVAL, "LTC", "EUR");
            exchange.GetPrice(BTCUSD_VAL, "BTC", "USD");
            exchange.GetPrice(LTCUSDVAL, "LTC", "USD");

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

            InitRefresh(RefreshProgress, GetSliderValue());
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, GetSliderValue());
            dispatcherTimer.Start();

            #endregion Price-Tick
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if ((bool)TagleRefreshData.IsChecked)
            {
                InitRefresh(RefreshProgress, GetSliderValue());
            }
            ExchangePrice exchangePrice = new ExchangePrice();
            //BTC > EUR
            exchangePrice.GetPrice(BTCEUR_VAL, "BTC", "EUR");
            exchangePrice.SetArrow(BTCEURARROW, btceurval, exchangePrice.BTCEURPRICE, out btceurval);
            //LTC > EUR
            exchangePrice.GetPrice(LTCEURVAL, "LTC", "EUR");
            exchangePrice.SetArrow(LTCARROW, ltceurval, exchangePrice.LTCEURPRICE, out ltceurval);
            //BTC > USD
            exchangePrice.GetPrice(BTCUSD_VAL, "BTC", "USD");
            exchangePrice.SetArrow(BTCUSDARROW, btcusdval, exchangePrice.BTCUSDPRICE, out btcusdval);
            // LTC > USD
            exchangePrice.GetPrice(LTCUSDVAL, "LTC", "USD");
            exchangePrice.SetArrow(LTCUSDARROW, ltcusdval, exchangePrice.LTCUSDPRICE, out ltcusdval);
        }

        // Call this method from the constructor of the form.
        private void InitRefresh(ProgressBar progressBar, int SliderValue)
        {
            if (progressBar.IsInitialized == true)
            {
                progressBar.BeginAnimation(ProgressBar.ValueProperty, null);
                Duration duration = new Duration(TimeSpan.FromSeconds(SliderValue));
                DoubleAnimation doubleanimation = new DoubleAnimation(100.0, duration);
                progressBar.BeginAnimation(ProgressBar.ValueProperty, doubleanimation);
            }
        }

        private void IntervalSlider_ManipulationCompleted(object sender, System.Windows.Input.ManipulationCompletedEventArgs e)
        {
            dispatcherTimer.Interval = new TimeSpan(0, 0, GetSliderValue());
        }

        private void IntervalSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            dispatcherTimer.Interval = new TimeSpan(0, 0, GetSliderValue());
            if (RefreshProgress != null & (bool)TagleRefreshData.IsChecked)
            {
                InitRefresh(RefreshProgress, GetSliderValue());
            }
        }
    }
}
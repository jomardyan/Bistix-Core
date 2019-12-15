using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using Bistix.Windows;

namespace Bistix
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private decimal _btceurval = 0;
        private decimal _ltceurval = 0;
        private decimal _btcusdval = 0;
        private decimal _ltcusdval = 0;
        private DispatcherTimer _dispatcherTimer = new DispatcherTimer();


        public int GetSliderValue()
        {
            return (int)IntervalSlider.Value;
        }

        public MainWindow()
        {


            InitializeComponent();
            ChromiumWebBrowser.Address = "\\BTCUSB.html";
            void TimeTimerTick(object sender, EventArgs e)
            {
                TimeBOX.Text = DateTime.Now.ToLongTimeString();
            }
            DispatcherTimer timeTimer = new System.Windows.Threading.DispatcherTimer();
            timeTimer.Tick += new EventHandler(TimeTimerTick);
            timeTimer.Interval = new TimeSpan(0, 0, 1);
            timeTimer.Start();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void TagleRefreshData_Checked(object sender, RoutedEventArgs e)
        {
            #region Price-Tick

            InitRefresh(RefreshProgress, GetSliderValue());
            _dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            _dispatcherTimer.Interval = new TimeSpan(0, 0, GetSliderValue());
            _dispatcherTimer.Start();

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
            exchangePrice.SetArrow(BTCEURARROW, _btceurval, exchangePrice.Btceurprice, out _btceurval);
            //LTC > EUR
            exchangePrice.GetPrice(LTCEURVAL, "LTC", "EUR");
            exchangePrice.SetArrow(LTCARROW, _ltceurval, exchangePrice.Ltceurprice, out _ltceurval);
            //BTC > USD
            exchangePrice.GetPrice(BTCUSD_VAL, "BTC", "USD");
            exchangePrice.SetArrow(BTCUSDARROW, _btcusdval, exchangePrice.Btcusdprice, out _btcusdval);
            // LTC > USD
            exchangePrice.GetPrice(LTCUSDVAL, "LTC", "USD");
            exchangePrice.SetArrow(LTCUSDARROW, _ltcusdval, exchangePrice.Ltcusdprice, out _ltcusdval);
        }

        // Call this method from the constructor of the form.
        private void InitRefresh(ProgressBar progressBar, int sliderValue)
        {
            if (progressBar.IsInitialized == true)
            {
                progressBar.BeginAnimation(ProgressBar.ValueProperty, null);
                Duration duration = new Duration(TimeSpan.FromSeconds(sliderValue));
                DoubleAnimation doubleanimation = new DoubleAnimation(100.0, duration);
                progressBar.BeginAnimation(ProgressBar.ValueProperty, doubleanimation);
            }
        }

        private void IntervalSlider_ManipulationCompleted(object sender, System.Windows.Input.ManipulationCompletedEventArgs e)
        {
            _dispatcherTimer.Interval = new TimeSpan(0, 0, GetSliderValue());
        }

        private void IntervalSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _dispatcherTimer.Interval = new TimeSpan(0, 0, GetSliderValue());
            if (RefreshProgress != null & (bool)TagleRefreshData.IsChecked)
            {
                InitRefresh(RefreshProgress, GetSliderValue());
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                Initprice();
            }
            finally
            {

            }

        }

        /// <summary>
        /// Start initialization of MainWindows Prices
        /// </summary>
        private void Initprice()
        {
            ExchangePrice exchange = new ExchangePrice();
            exchange.GetPrice(BTCEUR_VAL, "BTC", "EUR");
            exchange.GetPrice(LTCEURVAL, "LTC", "EUR");
            exchange.GetPrice(BTCUSD_VAL, "BTC", "USD");
            exchange.GetPrice(LTCUSDVAL, "LTC", "USD");


            CBSpotPrice spot = new CBSpotPrice();
            SporTest.Text = spot.Getspotprice("USD", "BTC");

        }

        private void TagleRefreshData_Unchecked(object sender, RoutedEventArgs e)
        {
        }

        private void UIElement_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ConfigurationWindows coWindow = new ConfigurationWindows();
            coWindow.Show();
        }
    }
} 
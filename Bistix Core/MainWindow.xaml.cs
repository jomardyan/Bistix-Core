using System;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Media;

namespace Bistix_Core
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            double btcval = 0;
            double ltcval = 0;

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
            pricex.GetAndSetBTCEUR(BTC_VAL);
            pricex.GetAndSetLTCEUR(LTC_VAL);
            

            void dispatcherTimer_Tick(object sender, EventArgs e)
            {
                
                


                FastSellPrice price = new FastSellPrice();
                price.GetAndSetBTCEUR(BTC_VAL);
                price.GetAndSetLTCEUR(LTC_VAL);
                

                if (btcval > price.BTCPRICE)
                {
                    SolidColorBrush BTCCOLOR = new SolidColorBrush();
                    BTCCOLOR.Color = Color.FromRgb(235, 64, 52);
                    BTCARROW.Foreground = BTCCOLOR;
                    BTCARROW.Kind = MahApps.Metro.IconPacks.PackIconModernKind.ArrowDown;
                }
                else if (btcval < price.BTCPRICE)
                {
                    SolidColorBrush BTCCOLOR = new SolidColorBrush();
                    BTCCOLOR.Color = Color.FromRgb(52, 235, 76);
                    BTCARROW.Foreground = BTCCOLOR;
                    BTCARROW.Kind = MahApps.Metro.IconPacks.PackIconModernKind.ArrowUp;

                }

                if (ltcval > price.LTCPRICE)
                {
                    SolidColorBrush BTCCOLOR = new SolidColorBrush();
                    BTCCOLOR.Color = Color.FromRgb(235, 64, 52);
                    BTCARROW.Foreground = BTCCOLOR;
                    BTCARROW.Kind = MahApps.Metro.IconPacks.PackIconModernKind.ArrowDown;
                }
                else if (ltcval < price.LTCPRICE)
                {
                    SolidColorBrush BTCCOLOR = new SolidColorBrush();
                    BTCCOLOR.Color = Color.FromRgb(52, 235, 76);
                    BTCARROW.Foreground = BTCCOLOR;
                    BTCARROW.Kind = MahApps.Metro.IconPacks.PackIconModernKind.ArrowUp;

                }

                btcval = price.BTCPRICE;
                ltcval = price.LTCPRICE;


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
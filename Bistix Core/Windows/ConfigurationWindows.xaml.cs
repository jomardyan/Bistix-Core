﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bistix.Windows
{
    /// <summary>
    /// Interaction logic for ConfigurationWindows.xaml
    /// </summary>
    public partial class ConfigurationWindows : Window
    {
        public ConfigurationWindows()
        {
            InitializeComponent();
        }
        
    }


    public class Cf {
        public bool State { get; private set; }



    }

}

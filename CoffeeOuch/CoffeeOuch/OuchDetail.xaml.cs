﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace CoffeeOuch
{
    public partial class OuchDetail : PhoneApplicationPage
    {
        public static OuchData ouchData;

        public OuchDetail()
        {
            InitializeComponent();
            ouchData = new OuchData();
            DataContext = OuchData.menuOuchJsonData;
            LLS.ItemsSource = OuchData.selectedItem.Solutions;
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace CoffeeOuch
{
    public partial class Coffee : PhoneApplicationPage
    {
        public Coffee()
        {
            InitializeComponent();
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        private void Coffee_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            WebBrowserTask wbt = new Microsoft.Phone.Tasks.WebBrowserTask();
            wbt.Uri = new Uri("http://www.starbucks.ca/");
            wbt.Show();
        }
    }
}
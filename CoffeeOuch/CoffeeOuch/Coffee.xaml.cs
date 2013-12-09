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

        public static CoffeeData coffeeData;

        public Coffee()
        {
            InitializeComponent();
            coffeeData = new CoffeeData();
            DataContext = CoffeeData.menuJsonData;
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        private void Coffee_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            CoffeeData.CategoryItem item = ((FrameworkElement)e.OriginalSource).DataContext as CoffeeData.CategoryItem;
            CoffeeData.selectedItem = item; // save the category item selected here
            String site = item.Website;

            WebBrowserTask wbt = new Microsoft.Phone.Tasks.WebBrowserTask();
            wbt.Uri = new Uri(site);
            wbt.Show();
        }
    }
}
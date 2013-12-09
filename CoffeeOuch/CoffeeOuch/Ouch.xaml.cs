using System;
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
    public partial class Ouch : PhoneApplicationPage
    {
        public static OuchData ouchData;

        public Ouch()
        {
            InitializeComponent();
            ouchData = new OuchData();
            DataContext = OuchData.menuOuchJsonData;
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        private void Option_BTN_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            OuchData.CategoryItem item = ((FrameworkElement)e.OriginalSource).DataContext as OuchData.CategoryItem;
            OuchData.selectedItem = item; // save the category item selected here
            if (item != null) // if fast-clicking, it is possible to get here with nothing selected.  Ignore
                NavigationService.Navigate(new Uri("/OuchDetail.xaml", UriKind.Relative));
        }

        private void OptionMap_BTN_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Map.xaml", UriKind.Relative));
        }
    }
}
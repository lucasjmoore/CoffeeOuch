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

        private void CallAFriendButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PhoneNumberChooserTask phoneNumberChooserTask;
            phoneNumberChooserTask = new PhoneNumberChooserTask();
            phoneNumberChooserTask.Completed += new EventHandler<PhoneNumberResult>(phoneNumberChooserTask_Completed);
            phoneNumberChooserTask.Show();

          
        }

        private void EmailUs_Button_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask();

            emailComposeTask.Subject = "Coffee...Ouch! suggestions and comments";
            emailComposeTask.Body = "Hey, There's this really great coffee shop named ____  that isn't on your list. Great job on the app though. Signed -Your name    (This is just a sample email, feel free to use the layout we've given you, or write your own custom one! We'd love to hear from you.)";
            emailComposeTask.To = "000magic@gmail.com";

            emailComposeTask.Show();
        }

        void phoneNumberChooserTask_Completed(object sender, PhoneNumberResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                //Code to start a new call using the retrieved phone number.
                PhoneCallTask phoneCallTask = new PhoneCallTask();
                phoneCallTask.DisplayName = e.DisplayName;
                phoneCallTask.PhoneNumber = e.PhoneNumber;
                phoneCallTask.Show();
            }
        }
    }
}
using Microsoft.Phone.Tasks;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization;

namespace CoffeeOuch
{
    public class CoffeeData
    {
        public static MenuResponse menuJsonData = null;

        public CoffeeData()
        {
            LoadMenuDataLocal();
        }

        [DataContract]
        public class CategoryItem
        {
            [DataMember]
            public string Title { get; set; }

            [DataMember]
            public string Website { get; set; } 

            [DataMember]
            public string Image { get; set; }
        }


        public class MenuResponse
        {
            [DataMember]
            public string MainCategories { get; set; }

            [DataMember]
            public ObservableCollection<CategoryItem> Categories { get; set; }
        }


        
        public void LoadMenuDataLocal()
        {
            using (StreamReader r = new StreamReader("Assets/coffee_shops.json"))
             {
                  string json = r.ReadToEnd();
                  if (!string.IsNullOrEmpty(json))
                  {
                      menuJsonData = JsonConvert.DeserializeObject<MenuResponse>(json);
                  }
             }
        }
        
        private void Coffee_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
             WebBrowserTask wbt = new Microsoft.Phone.Tasks.WebBrowserTask();
             wbt.Uri = new Uri("http://www.starbucks.ca/");
             wbt.Show();
         }
      



    }
}

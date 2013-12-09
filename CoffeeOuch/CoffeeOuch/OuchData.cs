using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization;

namespace CoffeeOuch
{
    public class OuchData
    {
        public static MenuResponse menuOuchJsonData = null;
        public static CategoryItem selectedItem { get; set; } 

        public OuchData()
        {
            OuchLoadMenuDataLocal();
        }

        [DataContract]
        public class SolutionItem
        {
            [DataMember]
            public string Desc { get; set; }

            [DataMember]
            public string Image { get; set; }

        }

        [DataContract]
        public class CategoryItem
        {
            [DataMember]
            public string Title { get; set; }

            [DataMember]
            public string Image { get; set; }

            [DataMember]
            public ObservableCollection<SolutionItem> Solutions { get; set; }
        }


        public class MenuResponse
        {
            [DataMember]
            public string OuchCategoryTitle { get; set; }

            [DataMember]
            public ObservableCollection<CategoryItem> Categories { get; set; }
        }



        public void OuchLoadMenuDataLocal()
        {
            using (StreamReader StreamReaderOuch = new StreamReader("Assets/ouch_categories.json")) 
            {
                string json = StreamReaderOuch.ReadToEnd();
                if (!string.IsNullOrEmpty(json))
                {
                    menuOuchJsonData = JsonConvert.DeserializeObject<MenuResponse>(json);
                }
            }
        }






    }
}

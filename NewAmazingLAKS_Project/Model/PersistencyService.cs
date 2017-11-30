using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;
using Newtonsoft.Json;

namespace NewAmazingLAKS_Project.Model
{
    class PersistencyService
    {
        private static string JsonFileName = "kundebase.json";

        //async metode originalt, men uden wait (redundant?)
        public static void SaveKundeListeAsJsonAsync(ObservableCollection<Customer> kundeListe)
        {
            string kundeListeJsonString = JsonConvert.SerializeObject(kundeListe);
            SerializeKundeListeFileAsync(kundeListeJsonString, JsonFileName);
        }

        public static async Task<List<Customer>> LoadKundeListeFromJsonAsync()
        {
            string kundeListeJsonString = await DeserializeKundeListeFileAsync(JsonFileName);
            if (kundeListeJsonString != null)
                return (List<Customer>)JsonConvert.DeserializeObject(kundeListeJsonString, typeof(List<Customer>));
            return null;
        }



        private static async void SerializeKundeListeFileAsync(string kundeListeJsonString, string fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(localFile, kundeListeJsonString);
        }


        private static async Task<string> DeserializeKundeListeFileAsync(string fileName)
        {
            try
            {
                StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return await FileIO.ReadTextAsync(localFile);
            }
            catch (FileNotFoundException ex)
            {
                MessageDialogHelper.Show("Første gang du loader? - Tilføj og gem nogle kunder før du loader", "File not Found");
                return null;
            }
        }


        public class MessageDialogHelper
        {
            public static async void Show(string content, string title)
            {
                MessageDialog messageDialog = new MessageDialog(content, title);
                await messageDialog.ShowAsync();
            }
        }
    }
}

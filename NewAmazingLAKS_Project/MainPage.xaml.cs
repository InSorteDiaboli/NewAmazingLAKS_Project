using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NewAmazingLAKS_Project
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        
        public MainPage()
        {
            this.InitializeComponent();
        }


        private int PreviousIndex;
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView lv = sender as ListView;

            if (PreviousIndex >= 0)
            {
                ListViewItem prevItem = (lv.ContainerFromIndex(PreviousIndex)) as ListViewItem;
                prevItem.ContentTemplate = Resources["NoSelectDataTemplate"] as DataTemplate;
            }

            ListViewItem item = (lv.ContainerFromIndex(lv.SelectedIndex)) as ListViewItem;
            if (item != null)
            {
                item.ContentTemplate = Resources["SelectDataTemplate"] as DataTemplate;
                //lv.IsItemClickEnabled = false;
            }
            else
            {
                item = (lv.ContainerFromIndex(PreviousIndex)) as ListViewItem;
                item.ContentTemplate = Resources["NoSelectDataTemplate"] as DataTemplate;
            }
            PreviousIndex = lv.SelectedIndex;
        }
    }
}

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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NewAmazingLAKS_Project
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditOrderProduct : Page
    {
        public EditOrderProduct()
        {
            this.InitializeComponent();
        }

        private async void IconGridView_ItemClick(object sender, ItemClickEventArgs e) //refresh
        {
            var frame = (Frame)Window.Current.Content;
            frame.Navigate(typeof(NewAmazingLAKS_Project.EditOrderProduct));
        }

        private async void Deselect_click(object sender, ItemClickEventArgs e) //Kode til at deselecte
        {
            var gridView = sender as ListView;
            if (e.ClickedItem == gridView.SelectedItem)
            {
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => gridView.SelectedItem = null);
                gridView.SelectedItem = null;
            }
        }

        private void CalendarDatePicker_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            tb1.Text = OrdDate.Date.ToString();
        }
        private void CalendarDatePicker2_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            tb2.Text = LevDate.Date.ToString();
        }
        private void CalendarDatePicker3_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            tb3.Text = FilDate.Date.ToString();
        }
    }
}

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
using App1.Model;
using App1.ViewModel;                   
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MainViewModel model;
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            model = new MainViewModel();
            this.DataContext = model;
        }
        //обработчик события
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //если модель загружена выполняет условие
            if (!model.IsLoaded)
            {
                //ф-ция загрузки rss документа с параметром в качестве ссылки
                model.LoadRss("http://news.liga.net/all/rss.xml");
            }
        }

        private void ListView_Selection(object sender, SelectionChangedEventArgs e)
        {
             if(listNews.SelectedItem != null)
            {
                Item item = listNews.SelectedItem as Item;
                Frame.Navigate(typeof(ReadNews), item);
            }
        }
    }
}

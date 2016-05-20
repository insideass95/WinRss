using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Model;
using System.Net.Http;
using System.Xml.Serialization;
using System.ComponentModel;

namespace App1.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
{
        private Rss _rss;

        //ключ значение
        public Rss Rss
        {
            get
            {
                return this._rss;
            }
            set
            {
                this._rss = value;
                NotifyPropertyChanged("Rss");
            }
        }
        public bool IsLoaded { get; set; }

        //в качестве параметра ссылка
        public async void LoadRss(string url)
        {
            //доступ через http
            HttpClient client = new HttpClient();
            using (var stream = await client.GetStreamAsync(url))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Rss));
                this.Rss = serializer.Deserialize(stream) as Rss;
                IsLoaded = true;

            }
        }
        //указывается метод обработки события
        public event PropertyChangedEventHandler PropertyChanged;
        //используется для уведомления клиентов, обычно клиентов – участников привязки, об изменении значения свойства.
        public void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}

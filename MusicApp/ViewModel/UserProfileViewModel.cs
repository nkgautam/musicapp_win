using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicApp.DataBase;

namespace MusicApp.ViewModel
{
   public class UserProfileViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<RecordTable> ListRecord
        {
            get; set;
        }

        public UserProfileViewModel()
        {
            ListRecord = new ObservableCollection<RecordTable>();
            RaisePropertyChanged("ListRecord");
        }

        RecordDatabaseHelper helper = new RecordDatabaseHelper();
        public async void LoadData(string emailID)
        {
            ListRecord.Clear();
            var result = await helper.GetData(emailID);
            if (result != null)
            {
                foreach (var item in result)
                {
                    item.Id = ListRecord.Count + 1;
                    System.Diagnostics.Debug.WriteLine(item.Id+"--"+ item.EmailID+"--"+item.Instrument+"--"+item.Start+"--"+item.End);
                    ListRecord.Add(item);
                }
               
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

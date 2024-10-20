using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Labb3_Gym.Models;
using System.Windows.Data;
using Labb3_Gym.Views;
using System.Windows;

namespace Labb3_Gym.ViewModels
{
      public class BookingViewModel : INotifyPropertyChanged
      {
            private string sessionName;
            private ICollectionView _sortedSessions;
            public ICollectionView SortedSessions => _sortedSessions;
            public ObservableCollection<Sessions> Sessions { get; set; }
            public bool SelectedSession { get; set; }
  
            public string SessionName
            {
                get => sessionName;
                set
                {
                    sessionName = value;
                    OnPropertyChanged(sessionName);

                }

            }

            public BookingViewModel()
            {
                Sessions = new ObservableCollection<Sessions>();
                LoadSessions();
                _sortedSessions = CollectionViewSource.GetDefaultView(Sessions);
                _sortedSessions.SortDescriptions.Add(new SortDescription("Time", ListSortDirection.Ascending));

               //var SessionBookCommand = new RelayCommand<object>(o => OnSessionBookCommand());
            }
      

            public void LoadSessions()
            {
                Sessions.Add(new Sessions { SessionType = "Yoga", date = DateTime.Today, Trainer = "Jennie", Time = "12:00", FilledSlots = 3, TotalSlots = 5}); 
                Sessions.Add(new Sessions { SessionType = "Cardio", date = DateTime.Today, Trainer = "Erik", Time = "12:30" });
                Sessions.Add(new Sessions { SessionType = "Cardio", date = DateTime.Today, Trainer = "Erik", Time = "11:30" });
                Sessions.Add(new Sessions { SessionType = "PowerLifting", date = DateTime.Today, Trainer = "Chuck Norris", Time = "10:00" });
                Sessions.Add(new Sessions { SessionType = "Yoga", date = DateTime.Today, Trainer = "Jennie", Time = "10:30" });
                Sessions.Add(new Sessions { SessionType = "Spinning", date = DateTime.Today, Trainer = "Jessica", Time = "13:30" });
                Sessions.Add(new Sessions { SessionType = "Spinning", date = DateTime.Today, Trainer = "Dersim", Time = "14:30",FilledSlots = 5, TotalSlots = 5 });
                Sessions.Add(new Sessions { SessionType = "PowerLifting", date = DateTime.Today, Trainer = "Dersim1", Time = "16:00" });
                Sessions.Add(new Sessions { SessionType = "PowerLifting", date = DateTime.Today, Trainer = "Dersim12", Time = "17:00" });
                AddNewSession();
                OnPropertyChanged("Sessions");
            }



            public void AddNewSession()
            {
                var newSession = new Sessions
                {
                    SessionType = "Pilates",
                    Trainer = "Anna",
                    date = DateTime.Today,
                    Time = "14:00",
                    FilledSlots = 2, // Full session
                    TotalSlots = 5
                };

                var newSession1 = new Sessions
                {
                    SessionType = "Pilates1",
                    Trainer = "Dersim",
                    date = DateTime.Today,
                    Time = "15:00",
                    FilledSlots = 3, // Full session
                    TotalSlots = 5
                };

                Sessions.Add(newSession);
                Sessions.Add(newSession1);
              
                OnPropertyChanged(nameof(Sessions));
               
            }

       




            public event PropertyChangedEventHandler PropertyChanged;

            protected void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
      }
}

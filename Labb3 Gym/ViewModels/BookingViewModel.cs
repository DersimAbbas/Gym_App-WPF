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
using System.Windows.Input;

namespace Labb3_Gym.ViewModels
{
      public class BookingViewModel : INotifyPropertyChanged
      {
            public Users _user { get; set; }
            public BookingManager _bookingManager { get; set; }
            private string sessionName;
            private ICollectionView _sortedSessions;
            public ICollectionView SortedSessions => _sortedSessions;
            public ObservableCollection<Sessions> Sessions { get; set; }
            private Sessions _selectedSession;
            public ICommand BookCommand { get; }
            public ICommand CancelCommand { get; }
            public event PropertyChangedEventHandler PropertyChanged;

            public Sessions SelectedSession
            {
                get => _selectedSession;
                set
                {
                    _selectedSession = value;
                    OnPropertyChanged(nameof(SelectedSession));
                }
            }


            public string SessionName
            {
                get => sessionName;
                set
                {
                    sessionName = value;
                    OnPropertyChanged(sessionName);

                }

            }

            public BookingViewModel(BookingManager bookingManager)
            {
                this._bookingManager = bookingManager;
                this._user = _bookingManager.currentUser;
                Sessions = new ObservableCollection<Sessions>();
                LoadSessions();
                _sortedSessions = CollectionViewSource.GetDefaultView(Sessions);
                _sortedSessions.SortDescriptions.Add(new SortDescription("Time", ListSortDirection.Ascending));
                BookCommand = new RelayCommand<Sessions>(BookSession, CanBookSession);
                CancelCommand = new RelayCommand<Sessions>(CancelSession, CanCancelSession);
            }
            

            public void LoadSessions()
            {
                Sessions.Add(new Sessions { SessionType = "Yoga", date = DateTime.Today, Trainer = "Jennie", Time = "12:00", FilledSlots = 3, TotalSlots = 5}); 
                Sessions.Add(new Sessions { SessionType = "Cardio", date = DateTime.Today, Trainer = "Erik", Time = "12:30",FilledSlots = 1, TotalSlots = 5});
                Sessions.Add(new Sessions { SessionType = "Cardio", date = DateTime.Today, Trainer = "Erik", Time = "11:30", FilledSlots = 2, TotalSlots = 5});
                Sessions.Add(new Sessions { SessionType = "PowerLifting", date = DateTime.Today, Trainer = "Chuck Norris", Time = "11:00", FilledSlots = 4, TotalSlots = 5});
                Sessions.Add(new Sessions { SessionType = "Yoga", date = DateTime.Today, Trainer = "Jennie", Time = "10:30", FilledSlots = 4, TotalSlots = 5 });
                Sessions.Add(new Sessions { SessionType = "Spinning", date = DateTime.Today, Trainer = "Jessica", Time = "13:30", FilledSlots = 3, TotalSlots = 5 });
                Sessions.Add(new Sessions { SessionType = "Spinning", date = DateTime.Today, Trainer = "Dersim", Time = "14:30",FilledSlots = 5, TotalSlots = 5 });
       
                
                AddNewSession();
                OnPropertyChanged(nameof(Sessions));
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
                    SessionType = "Pilates",
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

            private void BookSession(Object parameter)
            {
                _bookingManager.BookSessions(SelectedSession);
                OnPropertyChanged(nameof(SelectedSession));
                _sortedSessions.Refresh();
                
            }

            private bool CanBookSession(object parameter)
            {
                return _bookingManager.CanBookSession(SelectedSession);
            }

            private void CancelSession(Object parameter)
            {
                
                if (SelectedSession != null && SelectedSession.FilledSlots > 0)
                {
                    _bookingManager.CancelSessions(SelectedSession);
                    OnPropertyChanged(nameof(SelectedSession)); // Notify the ListView to refresh
                    OnPropertyChanged(nameof(Sessions));
                }
            }


            private bool CanCancelSession(object parameter)
            {
                return SelectedSession != null && SelectedSession.FilledSlots > 0;
            }

            protected void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
      }
}

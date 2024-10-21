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

            public BookingViewModel()
            {
                _bookingManager = BookingManager.Instance;
                _user = _bookingManager.currentUser;
                Sessions = _bookingManager.AvailableSessions;  // Use the sessions from BookingManager
                _sortedSessions = CollectionViewSource.GetDefaultView(Sessions);
                _sortedSessions.SortDescriptions.Add(new SortDescription("Time", ListSortDirection.Ascending));
                BookCommand = new RelayCommand<Sessions>(BookSession, CanBookSession);
                CancelCommand = new RelayCommand<Sessions>(CancelSession, CanCancelSession);
            }
    
            

            



            /*public void AddNewSession()
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
               
            }*/

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

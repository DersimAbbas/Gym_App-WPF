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
            public ObservableCollection<Sessions> Sessions { get; set; }
            private Sessions _selectedSession;
            public ICommand BookCommand { get; }
            public ICommand CancelCommand { get; }
            public ICommand SearchCommand { get; }
            private ObservableCollection<Sessions> filteredSessions { get; set; }
            public event PropertyChangedEventHandler PropertyChanged;
            private string _searchQuery;
            
            public string SearchQuery
            {
                get => _searchQuery;
                set
                {
                    _searchQuery = value;
                    OnPropertyChanged(nameof(SearchQuery));
                    
                }
            }    
            
            public Sessions SelectedSession
            {
                get => _selectedSession;
                set
                {
                    _selectedSession = value;
                    OnPropertyChanged(nameof(SelectedSession));
                }
            }

            public ObservableCollection<Sessions> FilteredSessions
            {
                get => filteredSessions;
                set
                {
                    filteredSessions = value;
                    OnPropertyChanged(nameof(FilteredSessions));
                }
            }

            public BookingViewModel()
            {
                _bookingManager = BookingManager.Instance;
                _user = _bookingManager.currentUser;
                Sessions = _bookingManager.AvailableSessions;  // Use the sessions from BookingManager
                BookCommand = new RelayCommand<Sessions>(BookSession, CanBookSession);
                CancelCommand = new RelayCommand<Sessions>(CancelSession, CanCancelSession);
                SearchCommand = new RelayCommand<Sessions>(SearchSession);
                FilteredSessions = new ObservableCollection<Sessions>(Sessions);
            }
            
            public void SearchSession(object parameter)
            {
                if (string.IsNullOrWhiteSpace(SearchQuery))
                {
                    FilteredSessions = new ObservableCollection<Sessions>(Sessions);

                }
                else
                {
                    var filtered = Sessions.Where(s =>
                    s.SessionType.ToLower().Contains(SearchQuery.ToLower()) || // filter by session type "cardio/yoga"
                    s.Time.Contains(SearchQuery) || s.date.ToString("yyyy-MM-dd").Contains(SearchQuery.ToLower()) || // filter by time HH-mm and year/mont/date
                    s.Trainer.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase)).ToList(); // filter by trainer name
                    
                    FilteredSessions.Clear();
                    foreach (var session in filtered)
                    {
                        FilteredSessions.Add(session);
                    }
                }
                
                OnPropertyChanged(nameof(FilteredSessions));
            }
                  
            private void BookSession(Object parameter)
            {
                
            
                _bookingManager.BookSessions(SelectedSession);
                OnPropertyChanged(nameof(SelectedSession));
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
                    OnPropertyChanged(nameof(FilteredSessions));
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

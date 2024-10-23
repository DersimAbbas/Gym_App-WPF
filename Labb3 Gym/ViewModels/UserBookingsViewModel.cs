using Labb3_Gym.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Labb3_Gym.ViewModels
{
   public class UserBookingsViewModel : INotifyPropertyChanged
   {
      
        private  BookingManager _bookingManager;
        private Sessions _selectedSession;
        private Users _currentUser;
        public ICommand CancelBookedCommand { get; }
        public ICommand SearchBookedCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;
        private string _searchQuery;
        private ObservableCollection<Sessions> filteredBookedSessions { get; set; }

        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                OnPropertyChanged(nameof(SearchQuery));

            }
        }

        public ObservableCollection<Sessions> FilteredBookedSessions
        {
            get => filteredBookedSessions;
            set
            {
                filteredBookedSessions = value;
                OnPropertyChanged(nameof(FilteredBookedSessions));
            }
        }

        public Sessions SelectedBookedSession
        {
            get => _selectedSession;
            set
            {
                _selectedSession = value;
                OnPropertyChanged(nameof(SelectedBookedSession));
            }
        }

        public UserBookingsViewModel()
        {
            _bookingManager = BookingManager.Instance;
            _currentUser = _bookingManager.currentUser;
            SearchBookedCommand = new RelayCommand<Sessions>(SearchBookedSession);
            CancelBookedCommand = new RelayCommand<Sessions>(CancelBookedSession, CanCancelBookedSession);
            FilteredBookedSessions = new ObservableCollection<Sessions>(_currentUser.BookedSession);
        }

        public void SearchBookedSession(object parameter)
        {
            if (string.IsNullOrWhiteSpace(SearchQuery))
            {
                FilteredBookedSessions = new ObservableCollection<Sessions>(_currentUser.BookedSession);

            }
            else
            {
                var filtered = _bookingManager.currentUser.BookedSession.Where(s =>
                s.SessionType.ToLower().Contains(SearchQuery.ToLower()) || // filter by session type "cardio/yoga"
                s.Time.Contains(SearchQuery) || s.date.ToString("yyyy-MM-dd").Contains(SearchQuery.ToLower()) || // filter by time HH-mm and year/mont/date
                s.Trainer.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase)).ToList(); // filter by trainer name

                FilteredBookedSessions.Clear();
                foreach (var Bookedsession in filtered)
                {
                    FilteredBookedSessions.Add(Bookedsession);
                }
            }

            OnPropertyChanged(nameof(FilteredBookedSessions));
        }

        private void CancelBookedSession(Object parameter)
        {

            if (SelectedBookedSession != null && _currentUser._bookedSession.Count > 0)
            {
                
                _bookingManager.CancelSessions(SelectedBookedSession);
                OnPropertyChanged(nameof(SelectedBookedSession)); // Notify the ListView to refresh
                OnPropertyChanged(nameof(_currentUser.BookedSession));
                
            }
        }

        private bool CanCancelBookedSession(object parameter)
        {
            return SelectedBookedSession != null && SelectedBookedSession.FilledSlots > 0;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
   }
}


        


    
   
    
   


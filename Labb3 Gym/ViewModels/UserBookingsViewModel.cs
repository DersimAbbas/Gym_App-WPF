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
        private string sessionName;
        private  BookingManager _bookingManager;
        private ICollectionView _sortedbookedSessions;
        public ICollectionView SortedBookedSessions => _sortedbookedSessions;
        private Sessions _selectedSession;
        private Users _currentUser;
        public ICommand CancelBookedCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        public Sessions SelectedBookedSession
        {
            get => _selectedSession;
            set
            {
                _selectedSession = value;
                OnPropertyChanged(nameof(SelectedBookedSession));
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

        public UserBookingsViewModel()
        {
            _bookingManager = BookingManager.Instance;
            _currentUser = _bookingManager.currentUser;
           
            _sortedbookedSessions = CollectionViewSource.GetDefaultView(_currentUser.BookedSession);
            _sortedbookedSessions.SortDescriptions.Add(new SortDescription("Time", ListSortDirection.Ascending));
            CancelBookedCommand = new RelayCommand<Sessions>(CancelBookedSession, CanCancelBookedSession);
        }



        public void LoadSessions()
        {
          
            OnPropertyChanged(nameof(Sessions));


            
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

    
   
    
   


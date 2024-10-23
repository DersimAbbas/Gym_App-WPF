using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Labb3_Gym.Models
{
    public class Users : ObservableObject
    {
        public string CurrentUser { get; set; }
        public string Name { get; set; }
        public ObservableCollection<Sessions> _bookedSession { get; set; }

        public ObservableCollection<Sessions> BookedSession
        {
            get => _bookedSession;
            set
            {
                _bookedSession = value;
                OnPropertyChanged(nameof(BookedSession));
            }
        }
    }

    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }








}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Labb3_Gym.ViewModels;

namespace Labb3_Gym.Models
{
    public class Sessions : INotifyPropertyChanged
    {
        public string SessionType { get; set; }
        public string Trainer { get; set; }
        public DateTime date { get; set; }
        public string Time { get; set; }
        public int TotalSlots { get; set; } = 5; // Example default max slots
        private int filledSlots { get; set; } // Number of filled slots
        public Guid SessionId { get; set; } 
        
        
        public int FilledSlots
        {
            get => filledSlots;
            set
            {
                if (filledSlots != value)
                {
                    filledSlots = value;
                    OnPropertyChanged(nameof(FilledSlots));
                    OnPropertyChanged(nameof(IsFull));
                                                           
                }
            }

        }

        public Sessions()
        {
            SessionId = Guid.NewGuid();
        }

        
        public bool IsFull => FilledSlots >= TotalSlots;


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}

            
          
        
        
        
        

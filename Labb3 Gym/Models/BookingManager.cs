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


namespace Labb3_Gym.Models
{
    public class BookingManager 
    {
        private static BookingManager _instance;
        public static BookingManager Instance => _instance ??= new BookingManager();
        public Users currentUser { get; set; }
        public ObservableCollection<Sessions> AvailableSessions { get; set; }
        public int IdCounter = 1;

        public BookingManager()
        {
            if (currentUser == null)
            {
                currentUser = new Users();
            }
            currentUser.BookedSession = new ObservableCollection<Sessions>();
            AvailableSessions = new ObservableCollection<Sessions>();
            LoadSessions();
        }

        private void LoadSessions()
        {
            AvailableSessions.Add(new Sessions(ref IdCounter) { SessionType = "Yoga", date = DateTime.Today, Trainer = "Jennie", Time = "12:00", FilledSlots = 3, TotalSlots = 5 });
            AvailableSessions.Add(new Sessions(ref IdCounter) { SessionType = "Cardio", date = DateTime.Today, Trainer = "Erik", Time = "12:30", FilledSlots = 1, TotalSlots = 5 });
            AvailableSessions.Add(new Sessions(ref IdCounter) { SessionType = "Cardio", date = DateTime.Today, Trainer = "Erik", Time = "11:30", FilledSlots = 2, TotalSlots = 5 });
            AvailableSessions.Add(new Sessions(ref IdCounter) { SessionType = "PowerLifting", date = DateTime.Today, Trainer = "Chuck Norris", Time = "11:00", FilledSlots = 4, TotalSlots = 5 });
            AvailableSessions.Add(new Sessions(ref IdCounter) { SessionType = "Yoga", date = DateTime.Today, Trainer = "Jennie", Time = "10:30", FilledSlots = 4, TotalSlots = 5 });
            AvailableSessions.Add(new Sessions(ref IdCounter) { SessionType = "Spinning", date = DateTime.Today, Trainer = "Jessica", Time = "13:30", FilledSlots = 3, TotalSlots = 5 });
            AvailableSessions.Add(new Sessions(ref IdCounter) { SessionType = "Spinning", date = DateTime.Today, Trainer = "Dersim", Time = "14:30", FilledSlots = 5, TotalSlots = 5 });

        
        }



        public void BookSessions(Sessions session)
        {
            if (session!= null & session.FilledSlots <session.TotalSlots)
            {
                //if(sessionId == CurrentUser.BookedSession.Any/firstordefault(SessionId => N(
               
                session.FilledSlots++;
                currentUser.BookedSession.Add(session);
               
            }
           
        }

        public void CancelSessions(Sessions session)
        {
            if (session != null & session.FilledSlots > 0)
            {
                session.FilledSlots--;
                currentUser.BookedSession.Remove(session);
            }
        }

        public bool CanBookSession(Sessions session)
        {
            return session != null && session.FilledSlots <session.TotalSlots;
        }

        public bool CanCancelSessions(Sessions session)
        {
            return session != null && session.FilledSlots > 0;
        }


        


    }
}

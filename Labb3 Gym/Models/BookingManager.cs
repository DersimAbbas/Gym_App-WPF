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
        public Users currentUser;
        
        public BookingManager(Users user)
        {
            currentUser = new Users("Dersim");
            currentUser.BookedSession = new ObservableCollection<Sessions>();
        }

        public void BookSessions(Sessions session)
        {
            if (session!= null & session.FilledSlots <session.TotalSlots)
            {
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

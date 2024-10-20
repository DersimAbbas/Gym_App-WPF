using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb3_Gym.ViewModels;
using Labb3_Gym;


namespace Labb3_Gym.Models
{
    public class BookingManager 
    {
        public Sessions session { get; set; }
        public bool canBook = true;
        
        public BookingManager()
        {

        }


        /*public void OnSessionBookCommand()
        {
          
            
            if (session.SelectedSession == null)
            {
                canBook = false;
            }
            else if(session..)
        }*/
    
    }
}

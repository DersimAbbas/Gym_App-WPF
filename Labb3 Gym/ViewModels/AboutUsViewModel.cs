using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Labb3_Gym.Models;
using System.Windows.Data;
using Labb3_Gym;


namespace Labb3_Gym.ViewModels
{
   public class AboutUsViewModel : INotifyPropertyChanged
   {
        public string AboutUsText { get; set; }
        public BookingManager _bookingManager { get; set; }

        public AboutUsViewModel(BookingManager bookingmanager)
        {
            _bookingManager = BookingManager.Instance;
            
            AboutUsText = "At Hundra Gymmet, we believe that success in fitness isn’t about being perfect; " +
                     "it's about giving 100% in every moment. Our gym is more than just a place to work out — " +
                     "it’s a community built around dedication, perseverance, and a relentless pursuit of personal greatness.\n\n" +
                    "Founded by two fitness enthusiasts with a passion for pushing limits, " +
                    "Hundra Gymmet was created to be the ultimate destination for those who want to go beyond the ordinary. " +
                    "Our philosophy is simple: it’s all or nothing. Whether you’re hitting the weights, spinning, or doing cardio, " +
                    "we challenge our members to give their all in every session.\n\n" +
                    "What sets us apart? We’re not just about providing state-of-the-art equipment and top-tier trainers. " +
                    "We’re about fostering a supportive environment where everyone, no matter their fitness level, " +
                    "feels empowered to push their boundaries and achieve new personal records.\n\n" +
                    "At Hundra Gymmet, you’ll find:\n" +
                    "• A variety of training programs to fit every goal.\n" +
                    "• Expert trainers dedicated to helping you unlock your potential.\n" +
                    "• A community that fuels your drive and holds you accountable.\n" +
                    "• A space where effort, not just results, is celebrated.\n\n" +
                    "Join us and discover what you’re capable of. Because at Hundra Gymmet, it’s always 100% or nothing.";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

   }
}















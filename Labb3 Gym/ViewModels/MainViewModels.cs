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
    public class MainViewModels : INotifyPropertyChanged
    {
     
        private string introText;

        public string IntroText
        {
            get => introText;
            set
            {
                introText = value;
                OnPropertyChanged(nameof(IntroText));
            }
        }
        


        public MainViewModels()
        {
            
            IntroText = "Welcome to Hundra Gymmet – Where 100% Effort is the Only Way!\n\n" +
                         "At Hundra Gymmet, we believe in the power of commitment and dedication. " +
                         "Our philosophy is simple: give it your all, or nothing at all. " +
                          "Unlike other gyms, we’re not just about fitness; " +
                          "we’re about pushing limits and unlocking your full potential. " +
                           "Here, every workout is a step towards greatness, and we’re committed to supporting you every step of the way.\n\n" +
                           "What makes us stand out? It’s our relentless drive for excellence " +
                           "and our unwavering belief that every member has what it takes to reach new heights. " +
                           "When you train at Hundra Gymmet, you’re part of a community that shares your passion, " +
                           "fuels your determination, and inspires you to go beyond the ordinary. " +
                           "Because here, it’s 100% or nothing. Join us and discover what you’re truly capable of!";
        }

 
        
    



       
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    
    
    }
}

using Labb3_Gym.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Labb3_Gym.Models;

namespace Labb3_Gym.Views
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public BookingManager _bookingManager { get; set; }

        public HomePage(BookingManager bookingManager)
        {
            InitializeComponent();
            _bookingManager = BookingManager.Instance;
            this.DataContext = new MainViewModels();
        }

        private void JoinUs_Click(object sender, RoutedEventArgs e)
        {
            
            NavigationService.Navigate(new LedigaPass());
        }
   
        private void AboutUs_Click(object sender, RoutedEventArgs e)
        {
            IntroTextBorder.Visibility = Visibility.Collapsed;
            NavigationService.Navigate(new AboutUsPage());
        }
    }
}

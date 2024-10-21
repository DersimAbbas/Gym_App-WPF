using System.Text;
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
using Labb3_Gym.ViewModels;
using Labb3_Gym.Views;

namespace Labb3_Gym
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public BookingManager _bookingManager { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            _bookingManager = BookingManager.Instance;
            MainFrame.Navigate(new HomePage(_bookingManager));
        }
        
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new HomePage(_bookingManager));
        }

        private void UserBooking_Click(object sender, RoutedEventArgs e)
        {
           
            MainFrame.Navigate(new AvbokaTider());
        }
       
    }
    
    
    
}
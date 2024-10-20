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
using Labb3_Gym.ViewModels;
using Labb3_Gym;

namespace Labb3_Gym.Views
{
    /// <summary>
    /// Interaction logic for LedigaPass.xaml
    /// </summary>
    public partial class LedigaPass : Page
    {
        public LedigaPass()
        {
            InitializeComponent();
            this.DataContext = new BookingViewModel();
        }

        private void Book_Click(object sender, RoutedEventArgs e)
        {

        }
        
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

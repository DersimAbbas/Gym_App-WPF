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
using Labb3_Gym.Models;
namespace Labb3_Gym.Views
{
    /// <summary>
    /// Interaction logic for AvbokaTider.xaml
    /// </summary>
    public partial class AvbokaTider : Page
    {
        public AvbokaTider()
        {
            InitializeComponent();

            this.DataContext = new UserBookingsViewModel();
        }
    }
}

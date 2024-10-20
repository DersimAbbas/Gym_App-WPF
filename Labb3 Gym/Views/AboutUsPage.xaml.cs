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

namespace Labb3_Gym.Views
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class AboutUsPage : Page
    {

        public string AboutUsText {  get; set; }
        
        public AboutUsPage()
        {
            InitializeComponent();
            this.DataContext = new AboutUsViewModel();
        }

          

        private void Join_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new LedigaPass());
        }








    }
 

}
        





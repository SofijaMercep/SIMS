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

namespace SIMS.Views
{
    /// <summary>
    /// Interaction logic for Doktor.xaml
    /// </summary>
    public partial class Doktor : Page
    {
        public Doktor()
        {
            InitializeComponent();
        }

        private void btnLekovi_Click(object sender, RoutedEventArgs e)
        {
            
            contentFrame.Navigate(new OdobreniLekovi());
        }

        private void btnOdobravanje_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            var app = Application.Current as App;
            var window = app.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive) as MainWindow;
            var page = new Login();
            window.mainFrame.Navigate(page);
        }
    }
}

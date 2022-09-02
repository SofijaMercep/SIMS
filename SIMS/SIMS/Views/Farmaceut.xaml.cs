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
    /// Interaction logic for Farmaceut.xaml
    /// </summary>
    public partial class Farmaceut : Page
    {
        public Farmaceut()
        {
            InitializeComponent();
        }

        private void btnLijekovi_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new OdobreniLijekovi());
        }

        private void btnOdobravanje_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new OdobravanjeLijekova());
        }

        private void btnOdbijeni_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new OdbijeniLijekovi());
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            var app = Application.Current as App;
            app.LoggedUser = null;
            var window = app.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive) as MainWindow;
            var page = new Login();
            window.mainFrame.Navigate(page);
        }
    }
}

using SIMS.Controllers;
using SIMS.Models;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private int tryLeft = 3;

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var app = Application.Current as App;
            var user = app.UserController.Login(email.Text, password.Password);

            if (user != null)
            {
                var window = app.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive) as MainWindow;
                if (user.Role.Equals(UserRole.Doktor))
                {
                    window.mainFrame.Navigate(new Doktor());
                }
                else if (user.Role.Equals(UserRole.Farmaceut))
                {

                }
                else
                {

                }

                return;
            }

            tryLeft--;

            if (tryLeft == 0)
            {
                App.Current.Shutdown();
            } else
            {
                MessageBox.Show(String.Format("Neuspesan login. Preostalo jos {0} pokusaja", tryLeft));

            }


        }
    }
}

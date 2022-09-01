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
    /// Interaction logic for DodavanjeKorisnika.xaml
    /// </summary>
    public partial class DodavanjeKorisnika : Page
    {
        public DodavanjeKorisnika()
        {
            InitializeComponent();

            List<UserRole> userRoles = new List<UserRole>();
            userRoles.Add(UserRole.Farmaceut);

            userRoles.Add(UserRole.Doktor);
            userRoles.Add(UserRole.Upravnik);
            Role.ItemsSource = userRoles;
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(Name.Text) ||
                String.IsNullOrEmpty(Surname.Text) ||
                String.IsNullOrEmpty(Email.Text) ||
                String.IsNullOrEmpty(Phone.Text) ||
                String.IsNullOrEmpty(jmbg.Text) ||
                String.IsNullOrEmpty(Password.Text) ||
                String.IsNullOrEmpty(Role.Text) ||
                String.IsNullOrEmpty(jmbg.Text))
            {
                MessageBox.Show("Polja nisu popunjena");
                return;
            }

            try
            {
                var app = Application.Current as App;
                User u = new User();
                u.Name = Name.Text;
                u.LastName = Surname.Text;
                u.Email = Email.Text;
                u.Password = Password.Text;
                u.Jmbg = jmbg.Text;
                u.PhoneNumber = Phone.Text;
                u.Role = (UserRole)Role.SelectedItem;
                u.Blocked = false;

                app.UserController.Save(u);

                MessageBox.Show("Korisnik uspešno sačuvan");
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }
    }
    
}

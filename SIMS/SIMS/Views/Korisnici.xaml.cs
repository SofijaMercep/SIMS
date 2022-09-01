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
    /// Interaction logic for Korisnici.xaml
    /// </summary>
    public partial class Korisnici : Page
    {
        private List<User> users;
        public Korisnici()
        {
            InitializeComponent();
            List<UserRole> list = new List<UserRole>();
            list.Add(UserRole.Farmaceut);
            list.Add(UserRole.Doktor);
            list.Add(UserRole.Upravnik);

            var app = Application.Current as App;
            users = app.UserController.GetAllUsers();
            dgMain.ItemsSource = users;

            RoleFilter.ItemsSource = list;
            RoleFilter.SelectionChanged += (object sender, SelectionChangedEventArgs args) =>
            {
                var help = users.Where(x => x.Role.Equals(RoleFilter.SelectedItem)).ToList();
                dgMain.ItemsSource = help;
            };
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (dgMain.IsLoaded == true)
            {
                User user = (User)((CheckBox)e.Source).DataContext;
                var app = Application.Current as App;
                app.UserController.BlockUser(user);
            }
            
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (dgMain.IsLoaded == true)
            {
                User user = (User)((CheckBox)e.Source).DataContext;
                var app = Application.Current as App;
                app.UserController.UnblockUser(user);
            }
        }
    }
}

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
    /// Interaction logic for OdobravanjeLijekova.xaml
    /// </summary>
    public partial class OdobravanjeLijekova : Page
    {
        private List<Drug> drugs;
        public OdobravanjeLijekova()
        {
            InitializeComponent();

            var app = Application.Current as App;

            this.drugs = app.DrugController.GetPending(app.LoggedUser);
            DataGridMain.ItemsSource = this.drugs;
        }

        private void Accept_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (DataGridMain.IsLoaded == true)
            {
                var app = Application.Current as App;
                var drug = (Drug)((CheckBox)e.Source).DataContext;
                bool isAccepted = app.DrugController.Accept(drug, app.LoggedUser);
                if (isAccepted == true)
                {
                    drugs = drugs.Where(d => d.ID != drug.ID).ToList();
                    DataGridMain.ItemsSource = drugs;
                }
            }
        }

        private void Accept_CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (DataGridMain.IsLoaded == true)
            {
                var app = Application.Current as App;
                app.DrugController.RemoveAcceptedFlag(app.LoggedUser, (Drug)((CheckBox)e.Source).DataContext);
            }
        }

        private void Reject_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (DataGridMain.IsLoaded == true)
            {
                var dialog = new Dialog();

                if (dialog.ShowDialog() == true)
                {
                    var app = Application.Current as App;
                    Drug drug = (Drug)((CheckBox)e.Source).DataContext;

                    app.DrugController.Reject(drug.ID, dialog.ResponseText, app.LoggedUser.Name + " " + app.LoggedUser.LastName);

                    drugs = drugs.Where(d => d.ID != drug.ID).ToList();
                    DataGridMain.ItemsSource = drugs;
                } else
                {
                    ((CheckBox)sender).IsChecked = false;
                }

            }

        }
    }
}

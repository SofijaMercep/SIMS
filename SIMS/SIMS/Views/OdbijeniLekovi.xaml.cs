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
    /// Interaction logic for OdbijeniLekovi.xaml
    /// </summary>
    public partial class OdbijeniLekovi : Page
    {
        private DrugController controller;
        private List<Drug> drugs;
        public OdbijeniLekovi()
        {
            InitializeComponent();

            var app = Application.Current as App;

            controller = app.DrugController;
            this.drugs = app.DrugController.GetAllAccepted();
            DrugsGrid.ItemsSource = drugs;
            search.TextChanged += (object sender, TextChangedEventArgs args) =>
            {
                if (sifra.IsSelected)
                {
                    drugs = controller.FilterDrugs("sifra", search.Text.ToLower(), false);
                }
                else if (naziv.IsSelected)
                {
                    drugs = controller.FilterDrugs("naziv", search.Text.ToLower(), false);
                }
                else if (proizvodjac.IsSelected)
                {
                    drugs = controller.FilterDrugs("proizvodjac", search.Text.ToLower(), false);
                }
                else if (cena.IsSelected)
                {
                    drugs = controller.FilterDrugs("cena", search.Text.ToLower(), false);
                }
                else if (kolicina.IsSelected)
                {
                    drugs = controller.FilterDrugs("kolicina", search.Text.ToLower(), false);
                }
                else if (sastojci.IsSelected)
                {
                    drugs = controller.FilterDrugs("sastojci", search.Text.ToLower(), false);
                }
                else
                {
                    drugs = controller.GetAllAccepted();
                }

                DrugsGrid.ItemsSource = drugs;
            };
        }

        private void sifra_Selected(object sender, RoutedEventArgs e)
        {
            drugs = controller.FilterDrugs("sifra", search.Text.ToLower(), false);
            DrugsGrid.ItemsSource = drugs;
        }

        private void naziv_Selected(object sender, RoutedEventArgs e)
        {
            drugs = controller.FilterDrugs("naziv", search.Text.ToLower(), false);
            DrugsGrid.ItemsSource = drugs;
        }

        private void proizvodjac_Selected(object sender, RoutedEventArgs e)
        {
            drugs = controller.FilterDrugs("proizvodjac", search.Text.ToLower(), false);
            DrugsGrid.ItemsSource = drugs;
        }

        private void cena_Selected(object sender, RoutedEventArgs e)
        {
            drugs = controller.FilterDrugs("cena", search.Text.ToLower(), false);
            DrugsGrid.ItemsSource = drugs;
        }

        private void kolicina_Selected(object sender, RoutedEventArgs e)
        {
            drugs = controller.FilterDrugs("kolicina", search.Text.ToLower(), false);
            DrugsGrid.ItemsSource = drugs;
        }

        private void sastojci_Selected(object sender, RoutedEventArgs e)
        {
            drugs = controller.FilterDrugs("sastojci", search.Text.ToLower(), false);
            DrugsGrid.ItemsSource = drugs;
        }
    }
}

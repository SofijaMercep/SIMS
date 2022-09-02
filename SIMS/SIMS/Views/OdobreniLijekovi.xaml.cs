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
    /// Interaction logic for OdobreniLijekovi.xaml
    /// </summary>
    public partial class OdobreniLijekovi : Page
    {
        List<Drug> drugs;
        private DrugController controller;
        public OdobreniLijekovi()
        {

            InitializeComponent();

            var app = Application.Current as App;

            controller = app.DrugController;
            this.drugs = app.DrugController.GetAllAccepted();
            DrugsGrid.ItemsSource = drugs;
            search.TextChanged += (object sender, TextChangedEventArgs args) =>
            {
                if (String.IsNullOrEmpty(search.Text))
                {
                    DrugsGrid.ItemsSource = app.DrugController.GetAllAccepted();
                    return;
                }

                if (sifra.IsSelected)
                {
                    drugs = controller.FilterDrugs("sifra", search.Text.ToLower(), true);
                }
                else if (naziv.IsSelected)
                {
                    drugs = controller.FilterDrugs("naziv", search.Text.ToLower(), true);
                }
                else if (proizvodjac.IsSelected)
                {
                    drugs = controller.FilterDrugs("proizvodjac", search.Text.ToLower(), true);
                }
                else if (cijena.IsSelected)
                {
                    drugs = controller.FilterDrugs("cijena", search.Text.ToLower(), true);
                }
                else if (kolicina.IsSelected)
                {
                    drugs = controller.FilterDrugs("kolicina", search.Text.ToLower(), true);
                } else if (sastojci.IsSelected)
                {
                    drugs = controller.FilterDrugs("sastojci", search.Text.ToLower(), true);
                } else {
                    drugs = controller.GetAllAccepted();
                }

                DrugsGrid.ItemsSource = drugs;
            };
        }

        private void sifra_Selected(object sender, RoutedEventArgs e)
        {
            drugs = controller.FilterDrugs("sifra", search.Text.ToLower(), true);
            DrugsGrid.ItemsSource = drugs;
        }

        private void naziv_Selected(object sender, RoutedEventArgs e)
        {
            drugs = controller.FilterDrugs("naziv", search.Text.ToLower(), true);
            DrugsGrid.ItemsSource = drugs;
        }

        private void proizvodjac_Selected(object sender, RoutedEventArgs e)
        {
            drugs = controller.FilterDrugs("proizvodjac", search.Text.ToLower(), true);
            DrugsGrid.ItemsSource = drugs;
        }

        private void cijena_Selected(object sender, RoutedEventArgs e)
        {
            drugs = controller.FilterDrugs("cijena", search.Text.ToLower(), true);
            DrugsGrid.ItemsSource = drugs;
        }

        private void kolicina_Selected(object sender, RoutedEventArgs e)
        {
            drugs = controller.FilterDrugs("kolicina", search.Text.ToLower(), true);
            DrugsGrid.ItemsSource = drugs;
        }

        private void sastojci_Selected(object sender, RoutedEventArgs e)
        {
            drugs = controller.FilterDrugs("sastojci", search.Text.ToLower(), true);
            DrugsGrid.ItemsSource = drugs;
        }
    }
}

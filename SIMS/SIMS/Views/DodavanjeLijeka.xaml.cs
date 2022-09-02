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
    /// Interaction logic for DodavanjeLijeka.xaml
    /// </summary>
    public partial class DodavanjeLijeka : Page
    {
        public DodavanjeLijeka()
        {
            InitializeComponent();

            var app = Application.Current as App;
            Components.ItemsSource = app.DrugComponentController.GetAllComponents(); 
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(Name.Text) ||
                String.IsNullOrEmpty(Price.Text) ||
                String.IsNullOrEmpty(ID.Text) ||
                String.IsNullOrEmpty(Producer.Text) ||
                String.IsNullOrEmpty(Quantity.Text))
            {
                MessageBox.Show("Polja nisu popunjena");
                return;
            }

            if (Components.SelectedItems.Count == 0)
            {
                MessageBox.Show("Lijek mora da sadrzi sastojke");
                return;
            }

            int id;
            double price;
            int quantity;
            try
            {
                id = int.Parse(ID.Text);
                price = double.Parse(Price.Text);
                quantity = int.Parse(Quantity.Text);
            }
            catch
            {
                MessageBox.Show("Neispravan unos");
                return;
            }

            var components = new Dictionary<string, DrugComponent>();
            foreach (var component in Components.SelectedItems)
            {
                var castedIngredient = (DrugComponent)component;
                components.Add(castedIngredient.Name, castedIngredient);
            }

            var drug = new Drug();
            drug.ID = id;
            drug.Name = Name.Text;
            drug.Producer = Producer.Text;
            drug.Price = price;
            drug.AvailableQuantity = quantity;
            drug.Accepted = false;
            drug.Rejected = false;
            drug.Components = components;

            try
            {
                var app = Application.Current as App;
                app.DrugController.Add(drug);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lijek vec postoji");
                return;
            }

            MessageBox.Show("Uspesno sacuvano");

            InitializeComponent();
        }
    
    }
}

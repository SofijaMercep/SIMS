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
    /// Interaction logic for PorucivanjeLekova.xaml
    /// </summary>
    public partial class PorucivanjeLekova : Page
    {
        public PorucivanjeLekova()
        {
            InitializeComponent();
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            if (Quantity.Text == "")
            {
                MessageBox.Show("Kolicina nije uneta");
                return;
            }

            int quantity;
            try
            {
                quantity = int.Parse(Quantity.Text);
                if (quantity <= 0)
                {
                    MessageBox.Show("Kolicina mora da bude veca od 0");
                }
            }
            catch
            {
                MessageBox.Show("Neispravan unos kolicine");
                return;
            }

            if (Drugs.SelectedIndex == -1)
            {
                MessageBox.Show("Lek nije izabran");
                return;
            }

            var drug = (Drug)Drugs.SelectedItem;
            var date = Date.SelectedDate;

            var app = Application.Current as App;
            if (date is null)
            {
                app.DrugController.IncreaseStock(drug.ID, quantity);
                MessageBox.Show("Povecana kolicina");
            }
            else
            {
                Order order = new Order();
                order.Drug = drug.ID;
                order.Quantity = quantity;
                app.OrderController.CreateOrder(order);
            }

            InitializeComponent();
        }
    }
}

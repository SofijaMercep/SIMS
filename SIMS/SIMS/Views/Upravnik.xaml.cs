﻿using System;
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
    /// Interaction logic for Administrator.xaml
    /// </summary>
    public partial class Upravnik : Page
    {
        public Upravnik()
        {
            InitializeComponent();
        }

        private void Registracija_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new DodavanjeKorisnika());
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            var app = Application.Current as App;
            app.LoggedUser = null;
            var window = app.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive) as MainWindow;
            var page = new Login();
            window.mainFrame.Navigate(page);
        }

        private void Korisnici_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new Korisnici());
        }

        private void NoviLijek_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new DodavanjeLijeka());
        }

        private void Lijekovi_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new OdobreniLijekovi());
        }

        private void Porudzbine_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new PorucivanjeLijekova());
        }
    }
}

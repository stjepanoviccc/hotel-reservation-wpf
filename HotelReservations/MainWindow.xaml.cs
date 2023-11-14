﻿using HotelReservations.Windows;
using HotelReservations.Model;
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

namespace HotelReservations
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RoomsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var roomsWindow = new Rooms();
            roomsWindow.Show();
        }

        private void RoomTypeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var roomTypeWindow = new RoomTypes();
            roomTypeWindow.Show();
        }

        private void UsersMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var usersWindow = new Users();
            usersWindow.Show();
        }

        private void PricesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var pricesWindow = new Prices();
            pricesWindow.Show();
        }

        private void ReservationsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var reservationsWindow = new Reservations();
            reservationsWindow.Show();
        }
    }
}

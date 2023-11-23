using HotelReservations.Model;
using HotelReservations.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HotelReservations.Windows
{
    /// <summary>
    /// Interaction logic for AddEditReservations.xaml
    /// </summary>
    public partial class AddEditReservations : Window
    {
        private ReservationService reservationService;
        private Reservation contextReservation;
        private ICollectionView view;
        public bool isEditing;

        // this will be for creating reservation by picking room
        public AddEditReservations(Reservation? res = null)
        {
            if (res == null)
            {
                contextReservation = new Reservation();
                isEditing = false;
            }
            else
            {
                contextReservation = res.Clone();
                isEditing = true;
            }
            InitializeComponent();
            reservationService = new ReservationService();
            this.DataContext = contextReservation;
            AdjustWindow(res);
            FillData();
            this.DataContext = contextReservation;
        }

        private void AdjustWindow(Reservation? res = null)
        {
            if (res != null)
            {
                Title = "Edit Reservation";
            }
            else
            {
                Title = "Add Reservation";
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            // validation passed
            reservationService.SaveReservation(contextReservation);
            DialogResult = true;
            Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        public void FillData()
        {
            var rooms = Hotel.GetInstance().Rooms.Where(room => room.IsActive).ToList();
            // latter guests will be added depending on resList ID!;
            var guests = Hotel.GetInstance().Guests.Where(guest => guest.IsActive).ToList();

            view = CollectionViewSource.GetDefaultView(rooms);
            RoomsDataGrid.ItemsSource = null;
            RoomsDataGrid.ItemsSource = view;
            RoomsDataGrid.IsSynchronizedWithCurrentItem = true;
            RoomsDataGrid.SelectedItem = null;

            view = CollectionViewSource.GetDefaultView(guests);
            GuestsDataGrid.ItemsSource = null;
            GuestsDataGrid.ItemsSource = view;
            GuestsDataGrid.IsSynchronizedWithCurrentItem = true;
            GuestsDataGrid.SelectedItem = null;
        }

        private void RoomsDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.ToLower() == "IsActive".ToLower())
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }

        private void GuestsDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            /* 
            if (!isEditing)
            {
                if (e.PropertyName.ToLower() == "ReservationId".ToLower())
                {
                    e.Column.Visibility = Visibility.Collapsed;
                }
            } */
            if (e.PropertyName.ToLower() == "IsActive".ToLower())
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }

        private void AddGuestButton_Click(object sender, RoutedEventArgs e)
        {
            var addGuestWindow = new AddEditGuest();
            Hide();
            if (addGuestWindow.ShowDialog() == true)
            {
                FillData();
            }
            Show();
        }
        private void EditGuestButton_Click(object sender, RoutedEventArgs e)
        {
            Guest chosenGuest = (Guest)GuestsDataGrid.SelectedItem;
            if (chosenGuest == null)
            {
                MessageBox.Show("Please select a Guest.", "Select Guest", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            var editGuestWindow = new AddEditGuest(chosenGuest);
            Hide();
            if (editGuestWindow.ShowDialog() == true)
            {
                FillData();
            }
            Show();
        }

        private void DeleteGuestButton_Click(object sender, RoutedEventArgs e)
        {
            var chosenGuest = (Guest)GuestsDataGrid.SelectedItem;
            if (chosenGuest == null)
            {
                MessageBox.Show("Please select a Guest.", "Select Guest", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            var deleteGuestWindow = new DeleteGuest(chosenGuest);
            Hide();
            if (deleteGuestWindow.ShowDialog() == true)
            {
                FillData();
            }
            Show();
        }
    }
}

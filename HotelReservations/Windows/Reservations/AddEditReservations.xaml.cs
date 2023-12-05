using HotelReservations.Model;
using HotelReservations.Service;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

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
            AdjustWindow(res);
            FillData(res);
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

        public void FillData(Reservation? res = null, Guest? newGuest = null)
        {
            var guests = Hotel.GetInstance().Guests.Where(g => g.IsActive && g.ReservationId == 0);
            if (isEditing)
            {
                guests = Hotel.GetInstance().Guests?.Where(g => g.ReservationId == contextReservation.Id && g.IsActive) ?? Enumerable.Empty<Guest>();
                var ress = res;
            }

            if (newGuest != null)
            {
                guests.Prepend(newGuest);
            }

            var rooms = Hotel.GetInstance().Rooms.Where(room => room.IsActive).ToList();

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
            if (e.PropertyName.ToLower() == "IsActive".ToLower())
            {
                e.Column.Visibility = Visibility.Collapsed;
            }

            if (e.PropertyName.ToLower() == "Id".ToLower())
            {
                e.Column.Visibility = Visibility.Collapsed;
            }

            if (e.PropertyName.ToLower() == "ReservationId".ToLower())
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

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Room selectedRoom = RoomsDataGrid.SelectedItem as Room;
            DateTime? startDate = StartDatePicker.SelectedDate;
            DateTime? endDate = EndDatePicker.SelectedDate;

            if (selectedRoom == null)
            {
                MessageBox.Show("Please select a room.");
                return;
            }

            if (!startDate.HasValue || !endDate.HasValue)
            {
                MessageBox.Show("Please select both start and end dates.");
                return;
            }

            // Not in the past
            if (startDate < DateTime.Today)
            {
                MessageBox.Show("Start date cannot be in the past.");
                return;
            }

            // Is Start date less than or equal to the end date
            if (startDate > endDate)
            {
                MessageBox.Show("Start date must be equal or earlier than end date.");
                return;
            }
            reservationService.SaveReservation(contextReservation, selectedRoom);
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}

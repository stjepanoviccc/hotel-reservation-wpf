using HotelReservations.Model;
using HotelReservations.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace HotelReservations.Windows
{
    /// <summary>
    /// Interaction logic for Reservations.xaml
    /// </summary>
    public partial class Reservations : Window
    {
        private ICollectionView view;
        public Reservations()
        {
            InitializeComponent();
            FillData();
        }

        public void FillData()
        {
            var reservationService = new ReservationService();
            var reservations = Hotel.GetInstance().Reservations.Where(res => res.IsActive).ToList();

            view = CollectionViewSource.GetDefaultView(reservations);
            view.Filter = DoFilter;

            ReservationsDataGrid.ItemsSource = null;
            ReservationsDataGrid.ItemsSource = view;
            ReservationsDataGrid.IsSynchronizedWithCurrentItem = true;
            ReservationsDataGrid.SelectedItem = null;
        }

        private bool DoFilter(object resObject)
        {
            var res = resObject as Reservation;

            var roomNumberSearchParam = RoomNumberSearchTextBox.Text;

            if (res.RoomNumber.Contains(roomNumberSearchParam))
            {
                return true;
            }

            return false;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var addReservationWindow = new AddEditReservations();
            Hide();
            if (addReservationWindow.ShowDialog() == true)
            {
                FillData();
            }
            Show();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Reservation chosenReservation = (Reservation)ReservationsDataGrid.SelectedItem;
            if (chosenReservation == null)
            {
                MessageBox.Show("Please select a Reservation.", "Select Reservation", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            var editReservationWindow = new AddEditReservations(chosenReservation);
            Hide();
            if (editReservationWindow.ShowDialog() == true)
            {
                FillData();
            }
            Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var chosenReservation = (Reservation)ReservationsDataGrid.SelectedItem;
            if (chosenReservation == null)
            {
                MessageBox.Show("Please select a Reservation.", "Select Reservation", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            var deleteReservationsWindow = new DeleteReservations(chosenReservation);
            Hide();
            if (deleteReservationsWindow.ShowDialog() == true)
            {
                FillData();
            }
            Show();
        }

        private void SearchTB_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void ReservationsDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.ToLower() == "IsActive".ToLower())
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }
    }
}

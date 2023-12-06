using HotelReservations.Model;
using HotelReservations.Service;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace HotelReservations.Windows
{
    /// <summary>
    /// Interaction logic for ActiveReservations.xaml
    /// </summary>
    public partial class ActiveReservations : Window
    {
        private ICollectionView view;

        public ActiveReservations()
        {
            InitializeComponent();
            FillData();
        }

        public void FillData()
        {
            var reservationService = new ReservationService();
            var reservations = Hotel.GetInstance().Reservations.Where(res => res.IsActive).ToList();

            ReservationsDataGrid.ItemsSource = null; // Clear existing items

            foreach (var reservation in reservations)
            {
                ReservationsDataGrid.Items.Add(reservation);

            }

            ReservationsDataGrid.IsSynchronizedWithCurrentItem = true;
            ReservationsDataGrid.SelectedItem = null;
        }
    }
}

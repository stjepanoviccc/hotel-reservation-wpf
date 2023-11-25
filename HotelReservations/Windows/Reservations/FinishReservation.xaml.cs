using HotelReservations.Model;
using HotelReservations.Service;
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
using System.Windows.Shapes;

namespace HotelReservations.Windows
{
    /// <summary>
    /// Interaction logic for FinishReservation.xaml
    /// </summary>
    public partial class FinishReservation : Window
    {
        private ReservationService reservationService;
        private Reservation resToFinish;
        public FinishReservation(Reservation finishReservation)
        {
            InitializeComponent();
            reservationService = new ReservationService();
            resToFinish = finishReservation;
        }

        private void FinishBtn_Click(object sender, RoutedEventArgs e)
        {
            var totalPrice = reservationService.FinishReservation(resToFinish);

            MessageBox.Show($"You must pay: {totalPrice}", "Payment Information", MessageBoxButton.OK, MessageBoxImage.Information);

            DialogResult = true;
            Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}

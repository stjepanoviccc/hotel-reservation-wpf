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
    /// Interaction logic for EditReservations.xaml
    /// </summary>
    public partial class EditReservations : Window
    {
        private ReservationService reservationService;
        private Reservation contextReservation;

        public EditReservations(Reservation res)
        {
            contextReservation = res.Clone();
            InitializeComponent();
            reservationService = new ReservationService();
            this.DataContext = contextReservation;
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
    }
}

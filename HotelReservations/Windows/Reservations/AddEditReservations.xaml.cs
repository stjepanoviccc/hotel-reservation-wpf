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
    /// Interaction logic for AddEditReservations.xaml
    /// </summary>
    public partial class AddEditReservations : Window
    {

        private ReservationService reservationService;
        private Reservation contextReservation;
        private bool isEditing;
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
            this.DataContext = contextReservation;
        }

        public void AdjustWindow(Reservation? res = null)
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

    }
}

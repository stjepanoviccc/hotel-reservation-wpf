using HotelReservations.Model;
using HotelReservations.Service;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddEditGuest.xaml
    /// </summary>
    public partial class AddEditGuest : Window
    {
        private GuestService guestService;
        private Guest contextGuest;
        private bool isEditing;
        public AddEditGuest(Guest? guest = null)
        {
            if (guest == null)
            {
                contextGuest = new Guest();
                isEditing = false;
            }
            else
            {
                contextGuest = guest.Clone();
                isEditing = true;
            }
            InitializeComponent();
            guestService = new GuestService();
            this.DataContext = contextGuest;
            AdjustWindow(guest);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (contextGuest.Name == "")
            {
                MessageBox.Show("Name can't be empty string.", "Name Empty", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (contextGuest.Surname == "")
            {
                MessageBox.Show("Surname can't be empty string.", "Surname Empty", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (string.IsNullOrEmpty(contextGuest.JMBG) || contextGuest.JMBG.Length != 13 || !contextGuest.JMBG.All(char.IsDigit))
            {
                MessageBox.Show("Wrong format for JMBG", "JMBG Format", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            // validation passed

            if (!isEditing)
            {
                guestService.SaveGuest(contextGuest);
            }
            else
            {
                guestService.SaveGuest(contextGuest, true);
            }

        //    DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void AdjustWindow(Guest? guest = null)
        { 
            if (guest != null)
            {
                Title = "Edit Guest";
            }
            else
            {
                Title = "Add Guest";
            }
        }
    }
}

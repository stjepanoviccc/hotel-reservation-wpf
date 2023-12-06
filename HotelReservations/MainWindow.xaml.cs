using HotelReservations.Model;
using HotelReservations.Windows;
using System.Windows;
using System.Windows.Controls;

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

        private void LogoutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // clear auth
            Hotel.GetInstance().loggedInUser = new User();

            MainStackPanel.Visibility = Visibility.Visible;
            GeneralMenu.Visibility = Visibility.Hidden;

            UsernameTextBox.Text = string.Empty;
            PasswordBox.Password = string.Empty;

            MessageBox.Show("Logged out", "Logout Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var username = UsernameTextBox.Text;
            var password = PasswordBox.Password;

            var findUser = Hotel.GetInstance().Users.Find(user => user.Username == username && user.Password == password);
            if (findUser == null)
            {
                MessageBox.Show("Try again.", "Login Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MainStackPanel.Visibility = Visibility.Hidden;
                GeneralMenu.Visibility = Visibility.Visible;

                // now checking which menu item to show

                // administrator doesnt have permission for working with reservations, rest is available.
                if(findUser.UserType == UserType.Administrator)
                {
                    RoomsMenuItem.Visibility = Visibility.Visible;
                    RoomTypeMenuItem.Visibility = Visibility.Visible;
                    UsersMenuItem.Visibility = Visibility.Visible;
                    PricesMenuItem.Visibility = Visibility.Visible;
                    ReservationsMenuItem.Visibility = Visibility.Hidden;
                };

                // if user is receptionist, it will have access to worki with reservations only.
                if(findUser.UserType == UserType.Receptionist)
                {
                    RoomsMenuItem.Visibility = Visibility.Hidden;
                    RoomTypeMenuItem.Visibility = Visibility.Hidden;
                    UsersMenuItem.Visibility = Visibility.Hidden;
                    PricesMenuItem.Visibility = Visibility.Hidden;
                    ReservationsMenuItem.Visibility = Visibility.Visible;
                };

                MessageBox.Show("Logged in. Welcome " + username + ".", "Login Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // setting auth user
                Hotel.GetInstance().loggedInUser = findUser;

            }
        }
    }
}
